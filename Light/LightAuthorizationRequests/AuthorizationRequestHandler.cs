using TdApi = Telegram.Td.Api;
using Td = Telegram.Td;
using System.Threading.Tasks;

namespace Light.LightAuthorizationRequests
{
    public class AuthorizationRequestHandler : Td.ClientResultHandler//,IRequestHandlerResult
    {
        private readonly TaskCompletionSource<RequestResult> _tcs = new TaskCompletionSource<RequestResult>();

        public Task<RequestResult> Task => _tcs.Task;
        private RequestResult _result;

        public void OnResult(TdApi.BaseObject @object)
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

            _tcs.TrySetResult(_result);
        }
    }
}
