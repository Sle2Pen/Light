using Light.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Light.NavigationServices
{
    public interface INavigationService
    {
        void Navigate<TViewModel>(object model = null, Action whenDone = null)
            where TViewModel : BaseViewModel;
    }
}
