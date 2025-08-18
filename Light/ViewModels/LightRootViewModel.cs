using Light.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Light.ViewModels
{
    public class LightRootViewModel : BaseViewModel
    {
        public LightRootViewModel(IEnumerable<string> applicationPages)
        {
            ApplicationPages = applicationPages;

            ShowChatsAsync = new AsyncRelayCommand(NavigateToAllChatsAsync);
            ShowMyProfileAsync = new AsyncRelayCommand(NavigateToMyProfileAsync);
        }

        public IEnumerable<string> ApplicationPages { get; set; }
        

        public ICommand ShowChatsAsync { get; }
        public ICommand ShowMyProfileAsync { get; }

        private async Task NavigateToAllChatsAsync()
        {

        }

        private async Task NavigateToMyProfileAsync()
        {

        }

        public override async Task InitializeAsync()
        {
            
        }
    }
}
