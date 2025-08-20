using System;

namespace Light.LightAuthorizationStateUpdatesDispatcher
{
    public interface IAuthorizationStateUpdatesDispatcher
    {
        event EventHandler<AuthorizationStateChangedEventArgs> AuthorizationStateChanged;

        AuthorizationState CurrentAuthorizationState { get; }

        void SetAuthorizationState(AuthorizationState newAuthorizationState);
    }

    public class AuthorizationStateChangedEventArgs : EventArgs
    {
        public AuthorizationStateChangedEventArgs(AuthorizationState previousState, AuthorizationState newState)
        {
            PreviousState = previousState;
            NewState = newState;
        }

        public AuthorizationState PreviousState { get; }
        public AuthorizationState NewState { get; }
    }
}
