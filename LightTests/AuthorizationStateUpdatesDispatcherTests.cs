using Light.LightAuthorizationStateUpdatesDispatcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LightTests
{
    [TestClass]
    public class AuthorizationStateUpdatesDispatcherTests
    {
        [TestMethod]
        public void CurrentAuthorizationState_NoAuthorizationState_ResultNull()
        {
            var authorizationStateReceiver = new AuthorizationStateUpdatesDispatcher(AuthorizationState.Empty());

            Assert.IsTrue(AuthorizationState.Empty().Equals(authorizationStateReceiver.CurrentAuthorizationState));
        }

        [TestMethod]
        public void SetAuthorizationState_InitialCurrentStateIsEmpty_ResultEqualsNewAuthorizationState()
        {
            var authorizationStateReceiver = new AuthorizationStateUpdatesDispatcher(AuthorizationState.Empty());
            var state = AuthorizationState.WaitStartupParameters();

            authorizationStateReceiver.SetAuthorizationState(state);

            Assert.AreEqual(state, authorizationStateReceiver.CurrentAuthorizationState);
        }

        [TestMethod]
        public void OnStateChanged_NewAuthorizationState_ResultSubsrciberGetsEvent()
        {
            var authorizationStateUpdatesDispatcher = new AuthorizationStateUpdatesDispatcher(AuthorizationState.Empty());
            var state = AuthorizationState.WaitStartupParameters();
            authorizationStateUpdatesDispatcher.SetAuthorizationState(state);
            var subscriber = new FakeSubscriber(authorizationStateUpdatesDispatcher);
            var controlState = AuthorizationState.Closed();

            authorizationStateUpdatesDispatcher.SetAuthorizationState(controlState);

            Assert.IsTrue(subscriber.IsGets);
            Assert.AreEqual(state, subscriber.PreviousState);
            Assert.AreEqual(controlState, subscriber.CurrentState);
            Assert.AreEqual(controlState, authorizationStateUpdatesDispatcher.CurrentAuthorizationState);
        }

        [TestMethod]
        public void OnStateChanged_SameAuthorizationState_ResultSubsrciberNotGetEvent()
        {
            var state = AuthorizationState.WaitStartupParameters();
            var authorizationStateUpdatesDispatcher = new AuthorizationStateUpdatesDispatcher(state);
            var subscriber = new FakeSubscriber(authorizationStateUpdatesDispatcher);

            authorizationStateUpdatesDispatcher.SetAuthorizationState(state);

            Assert.IsFalse(subscriber.IsGets);
            Assert.AreEqual(state, authorizationStateUpdatesDispatcher.CurrentAuthorizationState);
        }

    }

    public class FakeSubscriber
    {
        private readonly IAuthorizationStateUpdatesDispatcher _authorizationStateUpdatesDispatcher;

        public FakeSubscriber(IAuthorizationStateUpdatesDispatcher authorizationStateUpdatesDispatcher)
        {
            _authorizationStateUpdatesDispatcher = authorizationStateUpdatesDispatcher;
            _authorizationStateUpdatesDispatcher.AuthorizationStateChanged += FakeSubscriberOnAuthorizationStateChanged;

            IsGets = false;
        }

        public bool IsGets { get; set; }
        public AuthorizationState PreviousState { get; set; }
        public AuthorizationState CurrentState { get; set; }

        private void FakeSubscriberOnAuthorizationStateChanged(object sender, AuthorizationStateChangedEventArgs e)
        {
            _authorizationStateUpdatesDispatcher.AuthorizationStateChanged -= FakeSubscriberOnAuthorizationStateChanged;
            IsGets = !IsGets;
            PreviousState = e.PreviousState;
            CurrentState = e.NewState;
        }
    }
}
