using Light.Commands;
using Light.LightAuthorizationRequests;
using Light.LightAuthorizationStateUpdatesDispatcher;
using Light.NavigationServices;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Light.ViewModels
{
    public class PhoneNumberAuthorizationViewModel : BaseViewModel
    {
        private readonly IAuthorizationStateUpdatesDispatcher _authorizationStateUpdatesDispatcher;
        private readonly IAuthorizationRequests _authorizationRequests;
        private readonly INavigationService _authorizationNavigationService;

        private string _inputString;
        private string _errorMessage;

        public PhoneNumberAuthorizationViewModel(
            IAuthorizationStateUpdatesDispatcher authorizationStateUpdatesDispatcher,
            IAuthorizationRequests authorizationRequests,
            INavigationService authorizationNavigationService)
        {
            _authorizationStateUpdatesDispatcher = authorizationStateUpdatesDispatcher;
            _authorizationRequests = authorizationRequests;
            _authorizationNavigationService = authorizationNavigationService;
            _authorizationStateUpdatesDispatcher.AuthorizationStateChanged += DispatcherOnAuthorizationStateChanged;

            _inputString = string.Empty;
            _errorMessage = string.Empty;

            SendCommand = new AsyncRelayCommand(SendPhoneAsync);
            GoToRootCommand = new RelayCommand(GoToRoot);
        }

        private void DispatcherOnAuthorizationStateChanged(object sender, AuthorizationStateChangedEventArgs e)
        {
            if (e.NewState.IsAwaitingCode)
            {
                _authorizationStateUpdatesDispatcher.AuthorizationStateChanged -= DispatcherOnAuthorizationStateChanged;
                _authorizationNavigationService.Navigate<CodeAuthorizationViewModel>();
            }
        }
        

        private void GoToRoot()
        {
            _authorizationNavigationService.Navigate<AuthorizationRootViewModel>();
        }

        private async Task SendPhoneAsync()
        {
            var request = new AuthorizationRequest
            {
                TextPayload = InputString
            };

            var result = await _authorizationRequests.SendPhoneNumberAsync(request);

            if (result.Result == RequestResultType.Fail)
            {
                var formattedString = string.Format(
                    "Error code = {0}\nError message: {1}",
                    result.Payload.ErrorCode,
                    result.Payload.Message);

                ErrorMessage = formattedString;
            }
        }

        public override Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public string InputString
        {
            get => _inputString;
            set
            {
                _inputString = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand SendCommand { get; }
        public ICommand GoToRootCommand { get; }
    }
}
