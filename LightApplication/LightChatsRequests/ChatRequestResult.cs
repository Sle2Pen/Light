using LightApplication.LightChatsRequests;

namespace Light.LightChatsRequests
{
    public class ChatRequestResult
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool IsContainPhoto { get; set; }
        public int SmallPhotoId { get; set; }
        public string SmallPhotoPath { get; set; }
        public int RealPhotoId { get; set; }
        public string RealPhotoPath { get; set; }
        //public string ContentPreview { get; set; }
        public int UnreadCount { get; set; }
        public int UnreadMentionCount { get; set; }
        public int UnreadReactionCount { get; set; }
        public int LastMessageTime { get; set; }
        public bool IsOutgoingMessage { get; set; }

        public MessageResult LastMessage { get; set; }  
    }
    
}
