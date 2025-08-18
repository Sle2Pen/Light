using Light.Commands;
using Light.NavigationServices;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Light.ViewModels
{
    public class AuthorizationRootViewModel : BaseViewModel
    {
        //AuthorizationModel _authorizationModel;
        private readonly INavigationService _authorizationNavigationService;

        public AuthorizationRootViewModel(INavigationService authorizationNavigationService)
        {
            _authorizationNavigationService = authorizationNavigationService;

            SelectEmailAuthorizationCommand = new RelayCommand(SelectEmailAuthorization);
            SelectPhoneNumberAuthorizationCommand = new RelayCommand(SelectPhoneNumberAuthorization);
        }

        

        public ICommand SelectEmailAuthorizationCommand { get; }
        public ICommand SelectPhoneNumberAuthorizationCommand { get; }

        public override Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        private void SelectEmailAuthorization()
        {
            //_authorizationNavigationService.Navigate<EmailAuthorizationViewModel>();
        }

        private void SelectPhoneNumberAuthorization()
        {
            _authorizationNavigationService.Navigate<PhoneNumberAuthorizationViewModel>();
        }
    }
}
