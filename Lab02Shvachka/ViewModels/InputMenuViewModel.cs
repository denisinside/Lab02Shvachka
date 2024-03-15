using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Lab02Shvachka.Tools;
using Lab02Shvachka.Services;
using System.Windows;

namespace Lab02Shvachka.ViewModels
{
    internal class InputMenuViewModel : INotifyPropertyChanged
    {
        #region PropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion

        #region Commands
        private RelayCommand<object> _analyse;
        private RelayCommand<object> _close;

        public RelayCommand<object> AnalyseCommand
        {
            get
            {
                return _analyse ??= new RelayCommand<object>(_ => GotoInfoDisplay(), CanExecute);
            }
        }
        
        public RelayCommand<object> CloseCommand
        {
            get
            {
                return _close ??= new RelayCommand<object>(_ => Environment.Exit(0));
            }
        }
        private void GotoInfoDisplay()
        {
            _gotoInfoDisplay?.Invoke();
        }

        private bool CanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(Name) && !String.IsNullOrWhiteSpace(Surname) && !String.IsNullOrWhiteSpace(Email) && IsValidEmail() && IsValidDate();
        }
        #endregion


        #region Fields
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _selectedDate;
        private Action _gotoInfoDisplay;
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    OnPropertyChanged(nameof(Surname));
                }
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    OnPropertyChanged(nameof(SelectedDate));
                }
            }
        }
        #endregion

        public InputMenuViewModel(Action toInfoDisplay)
        {
            SelectedDate = DateTime.Today;
            _gotoInfoDisplay = toInfoDisplay;
        }

        #region Validation Methods
        private bool IsValidDate()
        {
            return new DateAnalyser(SelectedDate).IsValid();
        }

        private bool IsValidEmail()
        {
            try
            {
                MailAddress m = new(Email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        } 
        #endregion

    }
}
