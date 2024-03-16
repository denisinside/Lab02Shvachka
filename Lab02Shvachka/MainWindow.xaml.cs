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
using Lab02Shvachka.Models;
using Lab02Shvachka.Views;

namespace Lab02Shvachka
{
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

        // Please give a response about this variant of transfering a person from one viewmodel to another.
        // Firstly I considered to do a basic parent viewmodel with INotifyPropertyChanged and shared static Person
        // Then I thought about service class
        // Now I found out this variant, it seems interesting, but i don't know what variant I should use for more clear mvvm standart
        public void GotoInfoDisplay(Person person)
        {
            _infoDisplayView.ViewModel.Person = person;
            Content = _infoDisplayView;
        }
        public void GotoInputMenu()
        {
            Content = _menuView;
        }
    }
}