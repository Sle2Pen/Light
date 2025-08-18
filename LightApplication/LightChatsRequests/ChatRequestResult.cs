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
        public string LastMessageDate { get; set; }
        public string LastMessageTime { get; set; }
    }


}
