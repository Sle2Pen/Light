using Light.Pages;
using Light.ViewModels;
using LightApplication.LightUpdates;
using LightApplication.UseCases;
using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Light.NavigationServices
{
    public class ApplicationNavigationService
    {
        private readonly Page _previousPage;
        private readonly Frame _rootFrame;
        private readonly LoadChatlistUseCase _loadChatlistUseCase;
        private readonly LoadChatAvatarsUseCase _loadChatAvatarsUseCase;
        private readonly FileUpdatesDispatcher _fileUpdatesDispatcher;

        public ApplicationNavigationService(
            Frame rootFrame, 
            LoadChatlistUseCase loadChatlistUseCase, 
            LoadChatAvatarsUseCase loadChatAvatarsUseCase, 
            FileUpdatesDispatcher fileUpdatesDispatcher)
        {
            _rootFrame = rootFrame;
            _loadChatlistUseCase = loadChatlistUseCase;
            _loadChatAvatarsUseCase = loadChatAvatarsUseCase;
            _fileUpdatesDispatcher = fileUpdatesDispatcher;
        }

        public async Task NavigateToAsync<TViewModel>()
            where TViewModel: BaseViewModel
        {
            var page = Create(typeof(TViewModel));
            _rootFrame.Content = page;
            Window.Current.Activate();
            await (page.DataContext as BaseViewModel).InitializeAsync();
        }

        private Page Create(Type viewModelType)
        {

            return new LightChatlistPage(
                new ChatlistViewModel(
                    _loadChatlistUseCase, 
                    _loadChatAvatarsUseCase, 
                    _fileUpdatesDispatcher));
        } 
    }
}
