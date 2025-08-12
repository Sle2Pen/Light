using Light.ViewModels;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Light.Pages
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class PasswordInputAuthorizationPage : Page
    {
        public PasswordInputAuthorizationPage(PasswordAuthorizationViewModel viewModel)
        {
            this.InitializeComponent();
            DataContext = viewModel;
        }
    }
}
