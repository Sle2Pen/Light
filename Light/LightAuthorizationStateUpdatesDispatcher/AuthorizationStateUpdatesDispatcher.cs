using System;

namespace Light.LightAuthorizationStateUpdatesDispatcher
{
    public class AuthorizationStateUpdatesDispatcher : IAuthorizationStateUpdatesDispatcher
    {
        public AuthorizationStateUpdatesDispatcher(AuthorizationState initialAuthorizationState)
        {
            CurrentAuthorizationState = initialAuthorizationState;
        }

        public event EventHandler<AuthorizationStateChangedEventArgs> AuthorizationStateChanged;

        public AuthorizationState CurrentAuthorizationState { get; private set; }

        public void SetAuthorizationState(AuthorizationState newAuthorizationState)
        {
            if (newAuthorizationState != CurrentAuthorizationState)
            {
                var previousState = CurrentAuthorizationState;
                CurrentAuthorizationState = newAuthorizationState;

                OnAuthorizationStateChanged(previousState);
            }
        }

        private void OnAuthorizationStateChanged(AuthorizationState previousState)
        {
            AuthorizationStateChanged?.Invoke(
                this,
                new AuthorizationStateChangedEventArgs(
                    previousState,
                    CurrentAuthorizationState));
        }
    }
}
