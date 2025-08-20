using Light.UpdatesHandlers;
using System.Diagnostics;
using TdApi = Telegram.Td.Api;

namespace Light.LightConnectionUpdatesHandler
{
    public class ConnectionUpdatesHandler : IUpdatesHandler
    {
        private readonly IUpdatesHandler _nextUpdatesHandler;

        public ConnectionUpdatesHandler(IUpdatesHandler nextUpdatesHandler = null)
        {
            if (nextUpdatesHandler != null)
            {
                _nextUpdatesHandler = nextUpdatesHandler;
            }
        }

        public void HandleUpdates(TdApi.BaseObject updates)
        {
            if (updates is TdApi.UpdateConnectionState)
            {
                //Debug
                var fmtString = string.Format("\n-----------------------------------------\nConntection states Updates - not handled:\n{0}\n-----------------------------------------\n", updates.ToString());
                Debug.WriteLine(fmtString);
                //end Debug

                //var update = (updates as TdApi.UpdateConnectionState).State;

                //if (update is TdApi.ConnectionStateConnecting)
                //{
                //    _connectionUpdatesService.OnStateChanged(new UpdateDto<TdConnectionState>("Connection", TdConnectionState.Connecting));
                //}
                //else if (update is TdApi.ConnectionStateReady)
                //{
                //    _connectionUpdatesService.OnStateChanged(new UpdateDto<TdConnectionState>("Connection", TdConnectionState.Ready));
                //}
                //else if (update is TdApi.ConnectionStateUpdating)
                //{
                //    _connectionUpdatesService.OnStateChanged(new UpdateDto<TdConnectionState>("Connection", TdConnectionState.Updating));
                //}
                //else if (update is TdApi.ConnectionStateWaitingForNetwork)
                //{
                //    _connectionUpdatesService.OnStateChanged(new UpdateDto<TdConnectionState>("Connection", TdConnectionState.WaitingForNetwork));
                //}
                //else if (update is TdApi.ConnectionStateConnectingToProxy)
                //{
                //    _connectionUpdatesService.OnStateChanged(new UpdateDto<TdConnectionState>("Connection", TdConnectionState.ConnectingToProxy));
                //}

            }
            else if (_nextUpdatesHandler != null)
            {
                _nextUpdatesHandler.HandleUpdates(updates);
            }
        }
    }
}
