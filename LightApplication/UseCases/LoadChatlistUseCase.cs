using Light.LightChatsRequests;
using LightApplication.CachedDataPresenters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LightApplication.UseCases
{
    public class LoadChatlistUseCase
    {
        private readonly IChatsRequests _chatsRequests;

        public LoadChatlistUseCase(
            IChatsRequests chatsRequests)
        {
            _chatsRequests = chatsRequests;
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
                    IsContainPhoto = item.IsContainPhoto,
                    UnreadCount = item.UnreadCount,
                    UnreadMentionCount = item.UnreadMentionCount,
                    UnreadReactionCount = item.UnreadMentionCount,
                    LastMessageTime = item.LastMessageTime,
                    IsOutgoingMessage=item.IsOutgoingMessage,
                    MessagePreview=new MessagePreviewPresentation
                    {
                        Id=item.LastMessage.Id,
                        ChatId=item.Id,
                        Date=item.LastMessage.Date,
                        //EditDate=,
                        IsOutgoing=item.LastMessage.IsOutgoing,
                        SendingStatus=MessageSendingStatus.Delivered,
                        PreviewContent=item.LastMessage.MessageContent//потом изменить эту херню
                    }
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
