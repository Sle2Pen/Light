using Light.LightAuthorizationRequests;
using Light.LightAuthorizationStateUpdatesDispatcher;
using Light.Pages;
using Light.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Light.NavigationServices
{
    public class AuthorizationNavigationService : INavigationService
    {
        private readonly Frame _rootFrame;
        private readonly IAuthorizationRequests _authorizationRequests;
        private readonly IAuthorizationStateUpdatesDispatcher _authorizationStateUpdatesDispatcher;

        public AuthorizationNavigationService(
            Frame rootFrame,
            IAuthorizationRequests authorizationRequests,
            IAuthorizationStateUpdatesDispatcher authorizationStateUpdatesDispatcher)
        {
            _rootFrame = rootFrame;
            _authorizationRequests = authorizationRequests;
            _authorizationStateUpdatesDispatcher = authorizationStateUpdatesDispatcher;
        }

        public void Navigate<TAuthorizationViewModel>(object model = null, Action whenDone = null)
            where TAuthorizationViewModel : BaseViewModel
        {
            Page page = CreateAuthorizationApplicationPage(typeof(TAuthorizationViewModel));

            _rootFrame.Content = page;

            Window.Current.Activate();
        }

        private Page CreateAuthorizationApplicationPage(Type viewModelType)
        {
            if (viewModelType == typeof(AuthorizationRootViewModel))
            {
                return new AuthorizationRootPage(new AuthorizationRootViewModel(this));
            }
            else if (viewModelType == typeof(PhoneNumberAuthorizationViewModel))
            {
                return new PhoneNumberInputAuthorizationPage(
                    new PhoneNumberAuthorizationViewModel(
                        _authorizationStateUpdatesDispatcher,
                        _authorizationRequests,
                        this));
            }
            else if (viewModelType == typeof(CodeAuthorizationViewModel))
            {
                return new CodeInputAuthorizationPage(
                    new CodeAuthorizationViewModel(
                        _authorizationStateUpdatesDispatcher,
                        _authorizationRequests,
                        this));
            }
            else if (viewModelType == typeof(PasswordAuthorizationViewModel))
            {
                return new PasswordInputAuthorizationPage(
                    new PasswordAuthorizationViewModel(
                        _authorizationStateUpdatesDispatcher,
                        _authorizationRequests,
                        this));
            }
            else
            {
                throw new Exception("Unknown view model");
            }
        }

        private void SetFrameRootContent(Page rootPage)
        {
            _rootFrame.Content = rootPage;

        }
    }
}
