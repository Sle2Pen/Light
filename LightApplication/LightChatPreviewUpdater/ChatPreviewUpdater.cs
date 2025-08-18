using LightApplication.LightCachedDataRepositories;

namespace LightApplication.LightLastChatMessageUpdater
{
    public class ChatPreviewUpdater
    {
        private readonly IChats _chats;
        private readonly IMessages _messages;

        public ChatPreviewUpdater(
            IChats chats, 
            IMessages messages)
        {
            _chats = chats;
            _messages = messages;
        }
    }
}
