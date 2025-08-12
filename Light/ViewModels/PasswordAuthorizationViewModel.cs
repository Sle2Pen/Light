using Light.Commands;
using Light.LightAuthorizationRequests;
using Light.LightAuthorizationStateUpdatesDispatcher;
using Light.NavigationServices;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Light.ViewModels
{
    public class PasswordAuthorizationViewModel : BaseViewModel
    {
        private readonly IAuthorizationStateUpdatesDispatcher _authorizationStateUpdatesDispatcher;
        private readonly IAuthorizationRequests _authorizationRequests;
        private readonly INavigationService _authorizationNavigationService;

        private string _inputString;
        private string _errorMessage;

        public PasswordAuthorizationViewModel(
            IAuthorizationStateUpdatesDispatcher authorizationStateUpdatesDispatcher,
            IAuthorizationRequests authorizationRequests,
            INavigationService authorizationNavigationService)
        {
            _authorizationStateUpdatesDispatcher = authorizationStateUpdatesDispatcher;
            _authorizationRequests = authorizationRequests;
            _authorizationNavigationService = authorizationNavigationService;

            _inputString = string.Empty;
            _errorMessage = string.Empty;

            SendCommand = new AsyncRelayCommand(SendPasswordAsync);
            GoToRootCommand = new RelayCommand(GoToRoot);
        }

        protected override void InitializeViewModel(object model, Action whenDone)
        {
            throw new NotImplementedException();
        }

        private void GoToRoot()
        {
            _authorizationNavigationService.Navigate<AuthorizationRootViewModel>();
        }

        private async Task SendPasswordAsync()
        {
            var request = new AuthorizationRequest
            {
                TextPayload = InputString
            };

            var result = await _authorizationRequests.SendPasswordAsync(request);

            if (result.Result == RequestResultType.Fail)
            {
                var formattedString = string.Format(
                    "Error code = {0}\nError message: {1}",
                    result.Payload.ErrorCode,
                    result.Payload.Message);

                ErrorMessage = formattedString;
            }
        }

        public string PasswordHint
        {
            get => _authorizationStateUpdatesDispatcher.CurrentAuthorizationState.PasswordHint;
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

        //public string PasswordHint
        //{
        //    get => _userPhoneNumberAuthorization.PasswordHint;
        //    //set
        //    //{
        //    //    _inputString = value;
        //    //    OnPropertyChanged();
        //    //}
        //}

        public ICommand SendCommand { get; }
        public ICommand GoToRootCommand { get; }
    }
}
