using LightApplication.LightCachedDataRepositories;
using LightApplication.LightMessageInfo;
using System.Collections.Generic;

namespace LightCachedRepositories.MessageRepository
{
    //// В кеше
    //List<MessageInfo> _messageInfos;
    //Dictionary<long, TextContent> _textContents;
    //Dictionary<long, PhotoContent> _photoContents;
    //Dictionary<long, VoiceNoteContent> _voiceContents;
    //// ...

    public class Messages : IMessages
    {
        public List<MessageInfo> _messageInfoCollection;

        public Messages()
        {
            _messageInfoCollection = new List<MessageInfo>();
        }

        public int Count => _messageInfoCollection.Count;
        
        public void AddTextMessageInfo(TextMessageInfo newTextMessage)
        {
            _messageInfoCollection.Add(newTextMessage.MessageInfo);
        }

        public MessageInfo GetMessageInfoWithId(long messageId)
        {
            throw new System.NotImplementedException();
        }

        public TextContent GetTextContentWithMessageId(long messageId)
        {
            throw new System.NotImplementedException();
        }

        public bool IsAlreadyContainMessageWithId(long messageId)
        {
            if (_messageInfoCollection.Count == 0)
            {
                return false;
            }
            else
            {
                return _messageInfoCollection.Exists(message => message.MessageId == messageId);
            }
        }

        //public Message GetMessageWithId(long messageId)=>_messageCollection.Find(message => message.Id == messageId);
    }
}
