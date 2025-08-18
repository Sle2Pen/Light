using System;
using System.Collections.Generic;
using System.Text;

namespace LightApplication.LightUpdates
{
    public class FileUpdatesDispatcher
    {
        public event EventHandler<FileUpdateEventArgs> FileUpdated;

        public void SetUpdate(FileUpdate fileUpdate)
        {
            OnFileUpdated(fileUpdate);
        }

        private void OnFileUpdated(FileUpdate fileUpdate)
        {
            FileUpdated?.Invoke(this, new FileUpdateEventArgs(fileUpdate.Id, fileUpdate.Path));
        }
    }

    public class FileUpdateEventArgs:EventArgs
    {
        public FileUpdateEventArgs(long id, string path)
        {
            Id = id;
            Path = path;
        }

        public long Id { get; }
        public string Path { get; }
    }
}
