using Light.UpdatesHandlers;
using LightApplication.LightUpdates;
using TdApi = Telegram.Td.Api;

namespace Light.LightFileUpdatesHandler
{
    public class FileUpdatesHandler : IUpdatesHandler
    {
        private readonly FileUpdatesDispatcher _fileUpdatesDispatcher;
        private readonly IUpdatesHandler _nextUpdatesHandler;

        public FileUpdatesHandler(
            FileUpdatesDispatcher fileUpdatesDispatcher, 
            IUpdatesHandler nextUpdatesHandler=null)
        {
            _fileUpdatesDispatcher = fileUpdatesDispatcher;

            if (nextUpdatesHandler != null)
            {
                _nextUpdatesHandler = nextUpdatesHandler;
            }
        }

        public void HandleUpdates(TdApi.BaseObject updates)
        {
            if(updates is TdApi.UpdateFile fileUpdate)
            {
                var fileInfoUpdate = GetFileInfoUpdate(fileUpdate);
                _fileUpdatesDispatcher.SetUpdate(fileInfoUpdate);
            }

            if (_nextUpdatesHandler != null)
            {
                _nextUpdatesHandler.HandleUpdates(updates);
            }
        }

        private FileUpdate GetFileInfoUpdate(TdApi.UpdateFile fileUpdate)
        {
            return new FileUpdate
            {
                Id=fileUpdate.File.Id,
                Path= fileUpdate.File.Local.Path
            };
        }
    }
}
