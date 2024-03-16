using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Lab02Shvachka.Tools;
using System.Xml.Linq;
using Lab02Shvachka.Models;
using System.Windows;

namespace Lab02Shvachka.ViewModels
{
    public class InfoDisplayViewModel : INotifyPropertyChanged
    {

        #region PropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion

        #region Commands
        private RelayCommand<object> _goToMenu;
        private RelayCommand<object> _close;

        public RelayCommand<object> GotoMenuCommand
        {
            get
            {
                return _goToMenu ??= new RelayCommand<object>(_ => GoToInputMenu());
            }
        }

        public RelayCommand<object> CloseCommand
        {
            get
            {
                return _close ??= new RelayCommand<object>(_ => Environment.Exit(0));
            }
        }
        private void GoToInputMenu()
        {
            _gotoInputMenu?.Invoke();
        }
        #endregion

        private Action _gotoInputMenu;
        private Person _person;
        public Person Person
        { 
            get
            {
                return _person; 
            }
            set
            {
                _person = value;
                OnPropertyChanged(nameof(Person));
                if (_person.IsBirthday)
                 Task.Run(()=>   SayHappyBirthday());
            }
        }

        public InfoDisplayViewModel(Action gotoInputMenu)
        {
            _gotoInputMenu = gotoInputMenu;
        }

        private void SayHappyBirthday()
        {
            MessageBox.Show("Happy Birthday!");
        }

    }
}
