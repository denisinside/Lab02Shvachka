using System.Windows.Controls;
using Lab02Shvachka.ViewModels;

namespace Lab02Shvachka.Views
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class InfoDisplayView : UserControl
    {
        public InfoDisplayViewModel ViewModel { get; }
        public InfoDisplayView(Action gotoInputMenu)
        {
            InitializeComponent();
            DataContext = ViewModel = new InfoDisplayViewModel(gotoInputMenu);
        }
    }
}
