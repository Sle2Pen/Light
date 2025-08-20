using System.Diagnostics;
using TdApi = Telegram.Td.Api;

namespace Light.UpdatesHandlers
{
    public class NullUpdatesHandler : IUpdatesHandler
    {
        public void HandleUpdates(TdApi.BaseObject updates)
        {
            Debug.WriteLine(updates.ToString());
        }
    }
}
