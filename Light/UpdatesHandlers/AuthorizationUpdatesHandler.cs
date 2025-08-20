using Light.LightAuthorizationStateUpdatesDispatcher;
using System;
using System.Diagnostics;
using TdApi = Telegram.Td.Api;

namespace Light.UpdatesHandlers

{
    public class AuthorizationUpdatesHandler : IUpdatesHandler
    {
        private readonly IUpdatesHandler _nextUpdatesHandler;
        private readonly IAuthorizationStateUpdatesDispatcher _authorizationStateUpdatesDispatcher;

        public AuthorizationUpdatesHandler(
            IUpdatesHandler nextUpdatesHandler,
            IAuthorizationStateUpdatesDispatcher authorizationStateUpdatesDispatcher)
        {
            _nextUpdatesHandler = nextUpdatesHandler;
            _authorizationStateUpdatesDispatcher = authorizationStateUpdatesDispatcher;

            if (nextUpdatesHandler != null)
            {
                _nextUpdatesHandler = nextUpdatesHandler;
            }
        }

        public void HandleUpdates(TdApi.BaseObject updates)
        {
            if (updates is TdApi.UpdateAuthorizationState authState)
            {
                _authorizationStateUpdatesDispatcher.SetAuthorizationState(GetAuthorizationStateFrom(authState));
            }

            if (_nextUpdatesHandler != null)
            {
                _nextUpdatesHandler.HandleUpdates(updates);
            }


        }

        private AuthorizationState GetAuthorizationStateFrom(TdApi.UpdateAuthorizationState authUpdates)
        {
            //Debug
            var fmtString = string.Format("\n-----------------------------------------\nAuthorization states Updates - handled:\n{0}\n-----------------------------------------\n", authUpdates.ToString());
            Debug.WriteLine(fmtString);
            //end Debug

            if (authUpdates.AuthorizationState is TdApi.AuthorizationStateWaitTdlibParameters)
            {
                return AuthorizationState.WaitStartupParameters();
            }
            else if (authUpdates.AuthorizationState is TdApi.AuthorizationStateWaitPhoneNumber)
            {
                return AuthorizationState.WaitPhoneNumber();
            }
            else if (authUpdates.AuthorizationState is TdApi.AuthorizationStateWaitCode wc)
            {
                if (wc.CodeInfo.Type is TdApi.AuthenticationCodeTypeTelegramMessage tgmes)
                {
                    return AuthorizationState.WaitTelegramMessageCode(wc.CodeInfo.PhoneNumber, tgmes.Length);
                }
                else if (wc.CodeInfo.Type is TdApi.AuthenticationCodeTypeSms sms)
                {
                    return AuthorizationState.WaitSmsCode(wc.CodeInfo.PhoneNumber, sms.Length);
                }
                else if (wc.CodeInfo.Type is TdApi.AuthenticationCodeTypeCall call)
                {
                    return AuthorizationState.WaitCallCode(wc.CodeInfo.PhoneNumber, call.Length);
                }
                else if (wc.CodeInfo.Type is TdApi.AuthenticationCodeTypeFlashCall fcall)
                {
                    return AuthorizationState.WaitFlashCall(wc.CodeInfo.PhoneNumber, fcall.Pattern);
                }
                else if (wc.CodeInfo.Type is TdApi.AuthenticationCodeTypeMissedCall mc)
                {
                    return AuthorizationState.WaitMissedCall(wc.CodeInfo.PhoneNumber, mc.PhoneNumberPrefix, mc.Length);
                }
                else
                {
                    string fmt = string.Format("unknown type : {0}", authUpdates.AuthorizationState);
                    throw new Exception(fmt);
                }

            }
            else if (authUpdates.AuthorizationState is TdApi.AuthorizationStateWaitPassword waitPassword)
            {
                return AuthorizationState.WaitPassword(
                    waitPassword.HasPassportData,
                    waitPassword.HasRecoveryEmailAddress,
                    waitPassword.RecoveryEmailAddressPattern,
                    waitPassword.PasswordHint);
            }
            else if (authUpdates.AuthorizationState is TdApi.AuthorizationStateReady)
            {
                return AuthorizationState.Ready();
            }
            else
            {
                string fmt = string.Format("unknown type : {0}", authUpdates.AuthorizationState);
                throw new Exception(fmt);
            }
        }
    }
}
