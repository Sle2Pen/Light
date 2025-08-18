using Light.LightChatsRequests;
using LightApplication.LightCachedDataRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LightApplication.LightUseCases
{
    public class LoadChatlistUseCase
    {
        private readonly IChatsRequests _chatsRequests;
        private readonly IChats _chats;

        public LoadChatlistUseCase(
            IChatsRequests chatsRequests,
            IChats chats)
        {
            _chatsRequests = chatsRequests;
            _chats = chats;
        }

        public async Task<IEnumerable<ChatPreviewPresentation>> LoadInitialChatsAsync()
        {
            var list = new List<ChatPreviewPresentation>();

            var mudChats = await _chatsRequests.LoadChatsFromTelegramAsync();

            foreach (var item in mudChats)
            {
                var chat = new ChatPreviewPresentation
                {
                    Id = item.Id,
                    Title = item.Title,
                    IsContainPhoto=item.IsContainPhoto,
                    LastMessageDate = item.LastMessageDate,
                    LastMessageTime = item.LastMessageTime
                };
                
                if (chat.IsContainPhoto)
                {
                    chat.PhotoId = item.SmallPhotoId;
                    chat.PhotoPath = item.SmallPhotoPath;
                }

                list.Add(chat);
            }

            return list;
        }
    }
}
