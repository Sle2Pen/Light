using Light.UpdatesHandlers;
using System.Threading;
using Td = Telegram.Td;
using TdApi = Telegram.Td.Api;

namespace Light.TdlibUpdatesReceiver
{
    public class UpdatesReceiver : Td.ClientResultHandler
    {
        private readonly SynchronizationContext _synchronizationContext;
        private readonly IUpdatesHandler _updatesHandler;

        public UpdatesReceiver(
            SynchronizationContext synchronizationContext = null,
            IUpdatesHandler updatesHandler = null)
        {
            _synchronizationContext = synchronizationContext;

            if (updatesHandler != null)
            {
                _updatesHandler = updatesHandler;
            }
        }

        private bool AreConditionsForProcessingUpdatesMet()
        {
            return _updatesHandler != null && _synchronizationContext != null;
        }

        public void OnResult(TdApi.BaseObject @object)
        {
            if (AreConditionsForProcessingUpdatesMet())
            {
                _synchronizationContext.Post(state =>
                {
                    _updatesHandler.HandleUpdates(@object);
                }, null);
            }
        }

    }
}
