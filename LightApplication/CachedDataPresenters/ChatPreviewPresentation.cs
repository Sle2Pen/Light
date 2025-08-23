using System;
using System.Collections.Generic;
using System.Text;

namespace LightApplication.CachedDataPresenters
{
    public class ChatPreviewPresentation
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool IsContainPhoto { get; set; }
        public int PhotoId { get; set; }
        public string PhotoPath { get; set; }
        public int LastMessageTime { get; set; }
        //last message etc
        public int UnreadCount { get; set; }
        public int UnreadMentionCount { get; set; }
        public int UnreadReactionCount { get; set; }
        public bool IsOutgoingMessage { get; set; }
        public MessagePreviewPresentation MessagePreview { get; set; }

        public int OrderPosition { get; set; }
    }
}
