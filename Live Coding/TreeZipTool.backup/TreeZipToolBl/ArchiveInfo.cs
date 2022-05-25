using LischkeEdv.Extensions;
using System.ComponentModel;
using System.IO;

namespace TreeZipToolBl
{
    public class ArchiveInfo : INotifyPropertyChanged
    {
        public ArchiveInfo(string fileName)
        {
            this.FileInfo = new FileInfo(fileName);
            this.Status = ArchiveStatus.Pending;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get => this.FileInfo.FullName; }
        public string Size { get => this.FileInfo.Length.ToByteString(); }
        public FileInfo FileInfo { get; private set; }
        public string Message { get; set; }
        public string Password { get; set; }
        public ArchiveStatus Status { get; set; }
        public bool ToBeSkipped { get; set; }

    }

    public enum ArchiveStatus
    {
        Analysing,
        Pending,
        Extracting,
        Done,
        Failed,
        Skipped,
        Cancelled
    }
}