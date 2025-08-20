using Light.LightChatsRequests;
using Light.TdlibClient;
using LightApplication.LightFileRequests;
using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace Light.LightFileRequests
{
    public class FilesRequests:IFilesRequests
    {
        private readonly ISynchronizationClient _synchronizationClientService;

        public FilesRequests(ISynchronizationClient synchronizationClientService)
        {
            _synchronizationClientService = synchronizationClientService;
        }

        public async Task DownloadAvatarAsync(int avatarId)
        {
            var chatPhotoHandler = new SimpleRequestHandler();
            var chatPhotoRequest = new TdApi.DownloadFile
            {
                FileId = avatarId,
                Priority = 1
            };

            _synchronizationClientService.SendRequest(chatPhotoRequest,chatPhotoHandler);

            var result = await chatPhotoHandler.Task;
        }
    }
}
