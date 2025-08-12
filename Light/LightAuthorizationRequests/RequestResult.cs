namespace Light.LightAuthorizationRequests
{
    public class RequestResult
    {
        public RequestResultType Result { get; set; }
        public RequestResultErrorPayload Payload { get; set; }
    }

    public class RequestResultErrorPayload
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
    }

    public enum RequestResultType
    {
        Success,
        Fail
    }
}
