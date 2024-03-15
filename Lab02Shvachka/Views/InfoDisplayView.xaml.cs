using System.Windows.Controls;
using Lab02Shvachka.ViewModels;

namespace Lab02Shvachka.Views
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class InfoDisplayView : UserControl
    {
        InfoDisplayViewModel viewModel;
        public InfoDisplayView(Action gotoInputMenu)
        {
            InitializeComponent();
            DataContext = viewModel = new InfoDisplayViewModel(gotoInputMenu);
        }
    }
}
