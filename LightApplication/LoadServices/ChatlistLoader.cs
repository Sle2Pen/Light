using System;
using System.Threading.Tasks;
using Light.LightChatsRequests;
using LightApplication.CachedDataRepositories;
using LightApplication.LightFileRequests;
using LightApplication.UpdateDispatchers;

namespace LightApplication.LoadServices
{
    public class ChatlistLoader:IChatlistLoader
    {
        private readonly IChatsRequests _chatsRequests;
        private readonly IFilesRequests _filesRequests;
        private readonly ICachedChats _chatsCache;
        private readonly IChatUpdatesDispatcher _chatsUpdatesDispatcher;

        public ChatlistLoader(
            IChatsRequests chatsRequests, 
            IFilesRequests filesRequests, 
            ICachedChats chatsCache, 
            IChatUpdatesDispatcher chatsUpdatesDispatcher)
        {
            _chatsRequests = chatsRequests;
            _filesRequests = filesRequests;
            _chatsCache = chatsCache;
            _chatsUpdatesDispatcher = chatsUpdatesDispatcher;
        }

        public async Task LoadChatsByLimitFromOffsetAsync(int offset = 0, int limit = 50)
        {
            if (_chatsCache.Count == 0)
            {
                var result= await _chatsRequests.LoadChatIdsFromTelegramAsync();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        var chatResult = await _chatsRequests.LoadChatFromTelegramAsync(item);

                        //if()

                        _chatsUpdatesDispatcher.SendChatLoadedUpdate();
                    }
                }
                
            }
        }
    }
}
