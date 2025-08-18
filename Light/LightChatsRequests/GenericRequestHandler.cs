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
            SetInternalResult(@object);

            _tcs.TrySetResult(_result);
        }

        protected abstract void SetInternalResult(TdApi.BaseObject @object);
    }
}
