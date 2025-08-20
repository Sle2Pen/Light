using TdApi = Telegram.Td.Api;
using Td = Telegram.Td;

namespace Light.TdlibClient
{
    public interface ISynchronizationClient
    {
        void Run();
        void Stop();
        void ResetClient();
        void SendRequest(TdApi.Function requestFunction, Td.ClientResultHandler requestHandler);
    }
}
