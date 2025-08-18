using Light.LightAuthorizationRequests;
using Light.LightAuthorizationStateUpdatesDispatcher;
using Light.LightChatsRequests;
using Light.LightChatsUpdatesHandler;
using Light.LightConnectionUpdatesHandler;
using Light.LightFileRequests;
using Light.LightFileUpdatesHandler;
using Light.LightInitialApplicationSettings;
using Light.LightSynchronizationClient;
using Light.LightSynchronizationServices;
using Light.LightUserUpdatesHandler;
using Light.NavigationServices;
using Light.Pages;
using Light.ViewModels;
using LightApplication.LightCachedDataRepositories;
using LightApplication.LightFileRequests;
using LightApplication.LightUpdates;
using LightApplication.LightUseCases;
using LightCachedRepositories.ChatsRepository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


using Td = Telegram.Td;
using TdApi = Telegram.Td.Api;


namespace Light
{
    /// <summary>
    /// Обеспечивает зависящее от конкретного приложения поведение, дополняющее класс Application по умолчанию.
    /// </summary>
    sealed partial class App : Application
    {
        Frame _rootFrame;

        Page _applicationRoot;

        //ILightApplication _coreApplication;

        INavigationService _authorizedUserNavigationService;
        //INavigationService _authorizationNavigationService;
        LoadChatlistUseCase _loadChatlistUseCase;
        LoadChatAvatarsUseCase _loadChatAvatarsUseCase;
        IChatsRequests _chatsRequests;
        IFilesRequests _filesRequests;
        IChats _chats;
        FileUpdatesDispatcher _fileUpdatesDispatcher;


        ISynchronizationClient _synchronizationClient;
        UpdatesReceiver _synchronizationUpdatesReceiver;

        IUpdatesHandler _nullUpdatesHandler;

        IUpdatesHandler _fileUpdatesHandler;
        IUpdatesHandler _chatsUpdatesHandler;
        //IChatlistUpdatesDispatcher _chatlistUpdatesDispatcher;

        IUpdatesHandler _userUpdatesHandler;
        IUpdatesHandler _connectionUpdatesHandler;

        IUpdatesHandler _authorizationUpdatesHandler;
        IAuthorizationStateUpdatesDispatcher _authorizationStateUpdatesDispatcher;

        IAuthorizationRequests _authorizationRequests;

        /// <summary>
        /// Инициализирует одноэлементный объект приложения.  Это первая выполняемая строка разрабатываемого
        /// кода; поэтому она является логическим эквивалентом main() или WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Вызывается при обычном запуске приложения пользователем.  Будут использоваться другие точки входа,
        /// например, если приложение запускается для открытия конкретного файла.
        /// </summary>
        /// <param name="e">Сведения о запросе и обработке запуска.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            _nullUpdatesHandler = new NullUpdatesHandler();

            _fileUpdatesDispatcher = new FileUpdatesDispatcher();
            _fileUpdatesHandler = new FileUpdatesHandler(_fileUpdatesDispatcher, _nullUpdatesHandler);

            _userUpdatesHandler = new UserUpdatesHandler(_fileUpdatesHandler);
            _connectionUpdatesHandler = new ConnectionUpdatesHandler(_userUpdatesHandler);//в конце надо будет решить удолить или оставить. скорее оставить - это NullObject 

            _authorizationStateUpdatesDispatcher = new AuthorizationStateUpdatesDispatcher(AuthorizationState.Empty());
            _authorizationStateUpdatesDispatcher.AuthorizationStateChanged += OnAuthorizationStateChanged;

            _authorizationUpdatesHandler = new AuthorizationUpdatesHandler(
                _connectionUpdatesHandler,
                _authorizationStateUpdatesDispatcher);

            _synchronizationUpdatesReceiver = new UpdatesReceiver(
                SynchronizationContext.Current,
                _authorizationUpdatesHandler);

            //AppId and AppHash  а лучше AppInfo
            var appSettings = new LightSettings();

            _synchronizationClient = new SynchronizationClient(
                appSettings,
                new CancellationTokenSource(),
                _synchronizationUpdatesReceiver);

            _synchronizationClient.Run();

            _authorizationRequests = new AuthorizationRequests(_synchronizationClient);



            // Не повторяйте инициализацию приложения, если в окне уже имеется содержимое,
            // только обеспечьте активность окна
            if (_rootFrame == null)
            {
                // Создание фрейма, который станет контекстом навигации, и переход к первой странице
                _rootFrame = new Frame();

                _rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Загрузить состояние из ранее приостановленного приложения
                }

                Window.Current.Content = _rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                //_authorizationSynchronizationListener.AuthorizationStateChanged += OnAuthorizationStateChanged;
                Window.Current.Activate();

            }
        }

        private void OnAuthorizationStateChanged(object sender, AuthorizationStateChangedEventArgs e)
        {
            var state = e.NewState;
            var authorizationNavigationService = new AuthorizationNavigationService(
                _rootFrame,
                _authorizationRequests,
                _authorizationStateUpdatesDispatcher);

            try
            {
                switch (state.StateType)
                {
                    case AuthorizationStateType.WaitPhoneNumber:
                        authorizationNavigationService.Navigate<AuthorizationRootViewModel>();
                        break;
                    case AuthorizationStateType.WaitCode:
                        authorizationNavigationService.Navigate<CodeAuthorizationViewModel>();
                        break;
                    case AuthorizationStateType.Ready:
                        _rootFrame.Content = new LightStartupLoadingPage();
                        // TODO: Перейти в главное приложение
                        _ = LoadAsync();

                        break;

                    default:
                        // Можно логировать другие состояния
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка обработки состояния авторизации: {ex.Message}");
            }
        }

        private async Task LoadAsync()
        {
            //var handler = new AuthorizationRequestHandler();
            //var request = new TdApi.LoadChats
            //{
            //    ChatList = new TdApi.ChatListMain(),
            //    Limit = 100
            //};

            //_synchronizationClient.SendRequest(request, handler);

            //var result= await handler.Task;

            //if (result.Result == RequestResultType.Success)
            //{
            //    var getChatsHandler = new GetChatsRequestHandler();
            //    var getChatsRequest = new TdApi.GetChats { Limit = 50 };
            //    _synchronizationClient.SendRequest(getChatsRequest, getChatsHandler);

            //    var getChatsResult = await getChatsHandler.Task;
            //    var list = new List<DebugChatDto>();

            //    foreach (var item in getChatsResult.IdCollection)
            //    {
            //        var getChatInfoHandler = new GetChatRequestHandler();
            //        var getChatRequest = new TdApi.GetChat { ChatId=item };

            //        _synchronizationClient.SendRequest(getChatRequest, getChatInfoHandler);

            //        var getChatResult = await getChatInfoHandler.Task;

            //        list.Add(getChatResult);
            //    }

            //_rootFrame.Content = new LightStartPage(list);
            //}
            _chatsRequests = new ChatsRequests(_synchronizationClient);
            _filesRequests = new FilesRequests(_synchronizationClient);
            _chats = new Chats();

            _loadChatlistUseCase = new LoadChatlistUseCase(_chatsRequests,_chats);
            _loadChatAvatarsUseCase = new LoadChatAvatarsUseCase(_filesRequests);
            var chatlistVM = new ChatlistViewModel(_loadChatlistUseCase, _loadChatAvatarsUseCase, _fileUpdatesDispatcher);
            _rootFrame.Content = new LightChatlistPage(chatlistVM);
            await chatlistVM.InitializeAsync();
        }

        private void SetFrameRootContent(Page rootPage)
        {
            _rootFrame.Content = rootPage;
        }

        private Page CreateApplicationPage(Type viewModelType)
        {
            //if (viewModelType ==typeof(ApplicationRootViewModel))
            //{
            //    return new ApplicationRootPage(new ApplicationRootViewModel());
            //}
            ////else if (viewModelType == typeof(ApplicationRootViewModel))
            ////{
            ////    return new ApplicationRootPage(new ApplicationRootViewModel());
            ////}
            //else
            //{
            throw new Exception("Unknown view model");
            //}
        }



        /// <summary>
        /// Вызывается в случае сбоя навигации на определенную страницу
        /// </summary>
        /// <param name="sender">Фрейм, для которого произошел сбой навигации</param>
        /// <param name="e">Сведения о сбое навигации</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Вызывается при приостановке выполнения приложения.  Состояние приложения сохраняется
        /// без учета информации о том, будет ли оно завершено или возобновлено с неизменным
        /// содержимым памяти.
        /// </summary>
        /// <param name="sender">Источник запроса приостановки.</param>
        /// <param name="e">Сведения о запросе приостановки.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Сохранить состояние приложения и остановить все фоновые операции
            deferral.Complete();
        }
    }
}
