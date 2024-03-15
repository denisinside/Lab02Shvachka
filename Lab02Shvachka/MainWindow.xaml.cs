using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lab02Shvachka.Views;

namespace Lab02Shvachka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        InputMenuView _menuView;
        InfoDisplayView _infoDisplayView;

        public MainWindow()
        {
            InitializeComponent();
            Content = _menuView = new InputMenuView(GotoInfoDisplay);
            _infoDisplayView = new InfoDisplayView(GotoInputMenu);
        }

        public void GotoInfoDisplay()
        {
            Content = _infoDisplayView;
        }
        public void GotoInputMenu()
        {
            Content = _menuView;
        }
    }
}