using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using LightApplication.CachedDataPresenters;
using LightApplication.LightUpdates;
using LightApplication.UseCases;

namespace Light.ViewModels
{
    public class ChatlistViewModel : BaseViewModel
    {
        private readonly LoadChatlistUseCase _loadChatlistUseCase;
        private readonly LoadChatAvatarsUseCase _loadChatAvatarsUseCase;
        private readonly FileUpdatesDispatcher _fileUpdatesDispatcher;

        public ChatlistViewModel(
            LoadChatlistUseCase loadChatlistUseCase, 
            LoadChatAvatarsUseCase loadChatAvatarsUseCase, 
            FileUpdatesDispatcher fileUpdatesDispatcher)
        {
            _loadChatlistUseCase = loadChatlistUseCase;
            _loadChatAvatarsUseCase = loadChatAvatarsUseCase;
            _fileUpdatesDispatcher = fileUpdatesDispatcher;

            Chatlist = new ObservableCollection<ChatPreviewPresentation>();
        }

        public override async Task InitializeAsync()
        {
            var chatMetaPreviews = await _loadChatlistUseCase.LoadInitialChatsAsync();
            foreach (var item in chatMetaPreviews)
            {
                Chatlist.Add(item);
            }

            _fileUpdatesDispatcher.FileUpdated += Chitlist_FileUpdated;

            await _loadChatAvatarsUseCase.LoadChatAvatarsAsync(chatMetaPreviews);
        }

        private void Chitlist_FileUpdated(object sender, FileUpdateEventArgs e)
        {
            var item = Chatlist.FirstOrDefault(it => it.PhotoId == e.Id && e.Path != null);

            if(item != null)
            {
                item.PhotoPath = e.Path;
            }
        }

        public ObservableCollection<ChatPreviewPresentation> Chatlist { get; set; }
    }
}
