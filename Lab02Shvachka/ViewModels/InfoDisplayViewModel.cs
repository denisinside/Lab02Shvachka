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
    public class InfoDisplayViewModel : ViewModelBase
    {


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

        public MessageViewModel BirthdayMessageViewModel { get; }
        public string Message { set => BirthdayMessageViewModel.Message = value; }
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
                    Message = "Happy Birthday!";
                else
                    Message = String.Empty;
            }
        }

        public InfoDisplayViewModel(Action gotoInputMenu)
        {
            _gotoInputMenu = gotoInputMenu;
            BirthdayMessageViewModel = new();
        }

    }
}
