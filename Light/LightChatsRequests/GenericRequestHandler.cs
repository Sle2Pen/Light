using TdApi = Telegram.Td.Api;
using Td = Telegram.Td;
using System.Threading.Tasks;

namespace Light.LightChatsRequests
{
    public abstract class GenericRequestHandler<TRequest> : Td.ClientResultHandler
    {
        private readonly TaskCompletionSource<TRequest> _tcs = new TaskCompletionSource<TRequest>();

        public Task<TRequest> Task => _tcs.Task;
        protected TRequest _result;

        public void OnResult(TdApi.BaseObject @object)
        {

            //if (@object is TdApi.Error error)
            //{
            //    _result = new RequestResult
            //    {
            //        Result = RequestResultType.Fail,
            //        Payload = new RequestResultErrorPayload
            //        {
            //            ErrorCode = error.Code,
            //            Message = error.Message
            //        }
            //    };
            //}

            //if (@object is TdApi.Ok)
            //{
            //    _result = new RequestResult
            //    {
            //        Result = RequestResultType.Success
            //    };
            //}

            SetInternalResult(@object);

            _tcs.TrySetResult(_result);
        }

        protected abstract void SetInternalResult(TdApi.BaseObject @object);
    }
}
