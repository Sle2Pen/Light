using LightApplication.LightMessageInfo;

namespace LightApplication.LightCachedDataRepositories
{
    public interface IMessages
    {
        int Count { get; }

        bool IsAlreadyContainMessageWithId(long messageId);

        void AddTextMessageInfo(TextMessageInfo newTextMessage);

        MessageInfo GetMessageInfoWithId(long messageId);
        TextContent GetTextContentWithMessageId(long messageId);
    }
}
