using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeZipToolBl;

namespace LischkeEdv
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            List<string> extensions = new List<string>();
            foreach (string item in Properties.Settings.Default.ArchiveExtensions)
            {
                extensions.Add(item);
            }

            this.ArchiveManager = new ArchiveManager(extensions, Properties.Settings.Default.SevenZipLibPath)
            {
                DegreeOfParallelism = Properties.Settings.Default.DegreeOfParallelism,
                DeleteAfterSuccess = Properties.Settings.Default.DeleteAfterSuccess,
                ExtractToSubDir = Properties.Settings.Default.ExtractToSubDir,
                WorkingPath = Properties.Settings.Default.WorkingPath
            };

            this.ArchiveManager.Log = LogIt;

            this.BrowseForPath = new RelayCommand(p => CanBrowseForPath(), a => BrowseForPathAction());
            this.GetArchivesList = new RelayCommand(p => CanGetArchivesList(), a => GetArchivesListAction());
            this.ExtractArchives = new RelayCommand(p => CanExctractArchives(), a => ExtractArchivesAction());
            this.CancelExtraction = new RelayCommand(p => CanCancelExtraction(), a => CancelExtractionAction());
            this.CloseIt = new RelayCommand(p => CanClose(), a => CloseAction());
            this.OpenFileLocation = new RelayCommand(p => CanOpenFileLocation(), a => OpenFileLocationAction());
        }

        private bool CanOpenFileLocation()
        {
            return this.SelectedArchive != null;
        }

        private void OpenFileLocationAction()
        {
            Process.Start("explorer.exe", Path.GetDirectoryName(this.SelectedArchive.FileInfo.FullName));
        }

        private void LogIt(string logString)
        {
            this.Log = $"{this.Log}{Environment.NewLine}{logString}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool CanClose()
        {
            return true;
        }

        private void CloseAction()
        {
            Properties.Settings.Default.DegreeOfParallelism = this.ArchiveManager.DegreeOfParallelism;
            Properties.Settings.Default.DeleteAfterSuccess = this.ArchiveManager.DeleteAfterSuccess;
            Properties.Settings.Default.ExtractToSubDir = this.ArchiveManager.ExtractToSubDir;
            Properties.Settings.Default.WorkingPath = this.ArchiveManager.WorkingPath;

            Properties.Settings.Default.Save();
        }

        private bool CanGetArchivesList()
        {
            return Directory.Exists(this.ArchiveManager.WorkingPath) && !this.ArchiveManager.ArchiveEnumerationRunning;
        }

        private async void GetArchivesListAction()
        {
            await this.ArchiveManager.EnumerateArchivesAsync();
        }

        private bool CanCancelExtraction()
        {
            return this.ArchiveManager.ExtractionRunning;
        }

        private void CancelExtractionAction()
        {
            this.ArchiveManager.CancelExtraction();
        }

        private bool CanExctractArchives()
        {
            if (this.ArchiveManager.Archives != null)
            {
                if (this.ArchiveManager.Archives.Any(ar => ar.Status == ArchiveStatus.Pending || ar.Status == ArchiveStatus.Cancelled))
                {
                    return true;
                }
            }
            return false;
        }

        private async void ExtractArchivesAction()
        {
            await this.ArchiveManager.ExtractFilesAsync();
        }

        private bool CanBrowseForPath()
        {
            return true;
        }

        private void BrowseForPathAction()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
            {
                SelectedPath = this.ArchiveManager.WorkingPath,
                ShowNewFolderButton = false
            };


            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.ArchiveManager.WorkingPath = folderBrowserDialog.SelectedPath;
            }
        }

        public RelayCommand GetArchivesList { get; set; }
        public RelayCommand ExtractArchives { get; set; }
        public RelayCommand CancelExtraction { get; set; }
        public RelayCommand BrowseForPath { get; set; }
        public RelayCommand CloseIt { get; set; }
        public RelayCommand OpenFileLocation { get; set; }
        public ArchiveManager ArchiveManager { get; set; }

        public ArchiveInfo SelectedArchive { get; set; }

        public string Log { get; set; }
    }
}
