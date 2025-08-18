using LightApplication.LightCachedDataRepositories;
using LightApplication.LightMessageInfo;

namespace LightApplication.LightMessageUpdater
{
    public class MessageUpdater : IMessageUpdater
    {
        private readonly IMessages _messages;

        public MessageUpdater(IMessages messages)
        {
            _messages = messages;
        }

        public void TextMessageUpdate(TextMessageInfo messageInfo)
        {
            if (_messages.IsAlreadyContainMessageWithId(messageInfo.MessageInfo.MessageId))
            {

            }
            else
            {

            }
        }
    }
}
