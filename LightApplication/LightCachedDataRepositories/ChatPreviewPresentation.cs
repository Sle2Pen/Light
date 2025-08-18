using System;
using System.Collections.Generic;
using System.Text;

namespace LightApplication.LightCachedDataRepositories
{
    public class ChatPreviewPresentation
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool IsContainPhoto { get; set; }
        public int PhotoId { get; set; }
        public string PhotoPath { get; set; }
        //public string ContentPreview { get; set; }
        public string LastMessageDate { get; set; }
        public string LastMessageTime { get; set; }
        //last message etc
    }
}
