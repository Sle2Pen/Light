using TdApi = Telegram.Td.Api;

namespace Light.UpdatesHandlers
{
    public interface IUpdatesHandler
    {
        void HandleUpdates(TdApi.BaseObject updates);
    }
}
