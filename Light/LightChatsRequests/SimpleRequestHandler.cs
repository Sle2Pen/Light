using Light.LightAuthorizationRequests;
using TdApi = Telegram.Td.Api;

namespace Light.LightChatsRequests
{
    public class SimpleRequestHandler : GenericRequestHandler<RequestResult>
    {
        protected override void SetInternalResult(TdApi.BaseObject @object)
        {
            if (@object is TdApi.Error error)
            {
                _result = new RequestResult
                {
                    Result = RequestResultType.Fail,
                    Payload = new RequestResultErrorPayload
                    {
                        ErrorCode = error.Code,
                        Message = error.Message
                    }
                };
            }

            if (@object is TdApi.Ok)
            {
                _result = new RequestResult
                {
                    Result = RequestResultType.Success
                };
            }
        }
    }
}
