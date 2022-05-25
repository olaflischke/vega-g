using LischkeEdv.Extensions;
using SevenZip;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TreeZipToolBl
{
    public class ArchiveManager : INotifyPropertyChanged
    {
        private string sevenZipLibPath;
        private CancellationTokenSource cancellationTokenSource;
        private object aggLock = new object();
        private int successfullyExtracted;
        private int skipped;
        private int failed;

        public event PropertyChangedEventHandler PropertyChanged;

        public ArchiveManager(IEnumerable<string> archiveFileExtensions, string sevenZipLibPath)
        {
            this.ArchiveFileExtensions = archiveFileExtensions;
            this.sevenZipLibPath = sevenZipLibPath;
            this.ExtractionRunning = false;
        }

        public string WorkingPath { get; set; }
        public ObservableCollection<ArchiveInfo> Archives { get; set; }
        public IEnumerable<string> ArchiveFileExtensions { get; set; }
        public int DegreeOfParallelism { get; set; }
        public bool ExtractToSubDir { get; set; }
        public bool DeleteAfterSuccess { get; set; }
        public Action<string> Log { get; set; }
        public bool ArchiveEnumerationRunning { get; set; }
        public bool ExtractionRunning { get; set; }

        public async Task EnumerateArchivesAsync()
        {
            LogIt("Enumerating archives in path, please wait...");
            this.ArchiveEnumerationRunning = true;
            List<ArchiveInfo> archives = await Task.Run(() => EnumerateArchives(this.WorkingPath));
            this.ArchiveEnumerationRunning = false;
            this.Archives = new ObservableCollection<ArchiveInfo>(archives);
            LogIt($"{this.Archives.Count} archive{(this.Archives.Count > 0 ? "s" : "")} found. {(this.Archives.Count > 0 ? "Review the list below, add passwords where neccessary, and click 'Extract' to go on." : "")}");
        }

        private List<ArchiveInfo> EnumerateArchives(string path)
        {
            List<ArchiveInfo> archives = Directory.GetFiles(path)
                                    .Where(fi => this.ArchiveFileExtensions.Contains(Path.GetExtension(fi)))
                                    .Select(fi => new ArchiveInfo(fi))
                                    .ToList();

            foreach (string item in Directory.GetDirectories(path))
            {
                archives.AddRange(EnumerateArchives(item));
            }

            return archives;
        }

        public void CancelExtraction()
        {
            LogIt("Cancelling operations (finishing running extractions)...");
            cancellationTokenSource.Cancel();
        }

        public async Task ExtractFilesAsync()
        {
            await Task.Run(() => ExtractFiles());
        }

        public void ExtractFiles()
        {
            LogIt("Starting Extraction...");

            this.ExtractionRunning = true;
            cancellationTokenSource = new CancellationTokenSource();

            ParallelOptions po = new ParallelOptions() { MaxDegreeOfParallelism = this.DegreeOfParallelism, CancellationToken = cancellationTokenSource.Token };

            try
            {
                Parallel.ForEach(this.Archives, po, (currentArchive) =>
                {
                    if (currentArchive.ToBeSkipped)
                    {
                        currentArchive.Status = ArchiveStatus.Skipped;
                        currentArchive.Message = "Skipped.";
                        lock (aggLock)
                        {
                            this.skipped++;
                        }
                    }
                    else
                    {
                        ExtractFile(currentArchive);
                        lock (aggLock)
                        {
                            if (currentArchive.Status == ArchiveStatus.Done)
                            {
                                this.successfullyExtracted++;
                            }
                            if (currentArchive.Status == ArchiveStatus.Failed)
                            {
                                this.failed++;
                            }
                        }
                    }
                    po.CancellationToken.ThrowIfCancellationRequested();
                });
            }
            catch (OperationCanceledException ex)
            {
                LogIt($"Operation cancelled. Nevertheless {successfullyExtracted} archive{(successfullyExtracted > 1 ? "s" : "")} extracted, {failed} archive{(failed > 1 ? "s" : "")} failed.");
            }
            catch (AggregateException ae)
            {
                var ignoredExceptions = new List<Exception>();
                // This is where you can choose which exceptions to handle.
                foreach (var ex in ae.Flatten().InnerExceptions)
                {
                    if (ex is ArgumentException)
                        LogIt(ex.Message);
                    else
                        ignoredExceptions.Add(ex);
                }
                if (ignoredExceptions.Count > 0) //throw new AggregateException(ignoredExceptions);
                {
                    foreach (var item in ignoredExceptions)
                    {
                        LogIt(item.Message);
                    }
                }
            }
            finally
            {
                cancellationTokenSource.Dispose();
                this.ExtractionRunning = false;
            }
            LogIt($"{successfullyExtracted} archive{(successfullyExtracted > 1 ? "s" : "")} extracted, {failed} archive{(failed > 1 ? "s" : "")} failed, {skipped} archive{(skipped > 1 ? "s" : "")} skipped.");
        }

        private void ExtractFile(ArchiveInfo archive)
        {
            archive.Status = ArchiveStatus.Extracting;

            string targetDir = (this.ExtractToSubDir
                ? Path.Combine(archive.FileInfo.DirectoryName, Path.GetFileNameWithoutExtension(archive.FileInfo.FullName))
                : archive.FileInfo.DirectoryName);

            SevenZipExtractor.SetLibraryPath(sevenZipLibPath);
            SevenZipExtractor ext = null;

            archive.Message = $"Extracting to {targetDir}";

            try
            {
                if (String.IsNullOrEmpty(archive.Password))
                {
                    using (ext = new SevenZipExtractor(archive.FileInfo.FullName))
                    {
                        ext.ExtractArchive(targetDir);
                    }
                }
                else
                {
                    using (ext = new SevenZipExtractor(archive.FileInfo.FullName, archive.Password))
                    {
                        ext.ExtractArchive(targetDir);
                    }
                }
                archive.Message = $"Extracted to {targetDir}";

                if (this.DeleteAfterSuccess)
                {
                    if (archive.FileInfo.IsInUse())
                    {
                        archive.Message = $"{archive.Message}, but not deleted because file is still in use.";
                    }
                    else
                    {
                        File.Delete(archive.FileInfo.FullName);
                        archive.Message = $"{archive.Message}, archive deleted.";
                    }
                }

                archive.Status = ArchiveStatus.Done;
            }
            catch (Exception ex)
            {
                archive.Message = ex.Message;
                archive.Status = ArchiveStatus.Failed;
                LogIt($"Failed: {archive.FileInfo.FullName}");
            }
        }

        private void LogIt(string logString)
        {
            Log($"{DateTime.Now:hh:mm}: {logString}");
        }
    }
}
