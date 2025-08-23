using Light.LightAuthorizationRequests;
using Light.TdlibClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace Light.LightChatsRequests
{
    public class ChatsRequests: IChatsRequests
    {
        private readonly ISynchronizationClient _synchronizationClientService;

        public ChatsRequests(ISynchronizationClient synchronizationClientService)
        {
            _synchronizationClientService = synchronizationClientService;
        }

        public async Task<ChatRequestResult> LoadChatFromTelegramAsync(long item)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<long>> LoadChatIdsFromTelegramAsync(int offset = 0, int limit = 50)
        {
            var loadHandler = new SimpleRequestHandler();
            var request = new TdApi.LoadChats
            {
                ChatList = new TdApi.ChatListMain(),
                Limit = limit
            };

            _synchronizationClientService.SendRequest(request, loadHandler);
            var result = await loadHandler.Task;

            if (result.Result == RequestResultType.Success)
            {
                

                var getChatsHandler = new GetChatsRequestHandler();
                var getChatsRequest = new TdApi.GetChats { Limit = 50 };
                _synchronizationClientService.SendRequest(getChatsRequest, getChatsHandler);

                var getChatsResult = await getChatsHandler.Task;

                var list = new List<long>(getChatsResult.IdCollection);
                return list;
            }

            return null;
        }

        public async Task<IEnumerable<ChatRequestResult>> LoadChatsFromTelegramAsync(int offset = 0, int limit = 50)
        {
            var list = new List<ChatRequestResult>();

            var loadHandler = new SimpleRequestHandler();
            var request = new TdApi.LoadChats
            {
                ChatList = new TdApi.ChatListMain(),
                Limit = 100
            };

            _synchronizationClientService.SendRequest(request, loadHandler);
            var result = await loadHandler.Task;

            if (result.Result == RequestResultType.Success)
            {
                var getChatsHandler = new GetChatsRequestHandler();
                var getChatsRequest = new TdApi.GetChats { Limit = 50 };
                _synchronizationClientService.SendRequest(getChatsRequest, getChatsHandler);

                var getChatsResult = await getChatsHandler.Task;

                foreach (var item in getChatsResult.IdCollection)
                {
                    var getChatInfoHandler = new GetChatRequestHandler();
                    var getChatRequest = new TdApi.GetChat { ChatId = item };

                    _synchronizationClientService.SendRequest(getChatRequest, getChatInfoHandler);

                    var getChatResult = await getChatInfoHandler.Task;

                    list.Add(getChatResult);
                }
            }

            return list;
        }
    }
}
