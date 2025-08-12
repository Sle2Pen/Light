using TdApi = Telegram.Td.Api;

namespace Light.LightSynchronizationServices
{
    public interface IUpdatesHandler
    {
        void HandleUpdates(TdApi.BaseObject updates);
    }
}
