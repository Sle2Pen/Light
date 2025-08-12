using System;
using System.Diagnostics;
using Light.LightSynchronizationServices;
using TdApi = Telegram.Td.Api;

namespace Light.LightUserUpdatesHandler
{
    public class UserUpdatesHandler: IUpdatesHandler
    {
        private readonly IUpdatesHandler _nextUpdatesHandler;

        public UserUpdatesHandler(IUpdatesHandler nextUpdatesHandler = null)
        {
            if (nextUpdatesHandler != null)
            {
                _nextUpdatesHandler = nextUpdatesHandler;
            }
        }

        public void HandleUpdates(TdApi.BaseObject updates)
        {
            if (updates is TdApi.UpdateUser userUpdates)
            {
                //_authorizationStateUpdatesDispatcher.SetAuthorizationState(
                GetStateFrom(userUpdates);
                    //);
            }
            else if (_nextUpdatesHandler != null)
            {
                _nextUpdatesHandler.HandleUpdates(updates);
            }

            
        }

        private void GetStateFrom(TdApi.UpdateUser userUpdates)
        {
            //Debug
            var fmtString = string.Format("\n-----------------------------------------\nUser  Updates - handled:\n{0}\n-----------------------------------------\n", userUpdates.ToString());
            Debug.WriteLine(fmtString);
            //end Debug

        }
    }
}
