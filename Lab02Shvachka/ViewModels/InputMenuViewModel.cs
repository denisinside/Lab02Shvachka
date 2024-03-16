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
using Lab02Shvachka.Models;

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
        private async void GotoInfoDisplay()
        {
            Person person = new(Name, Surname, Email, SelectedDate);
            IsEnabled = false;

            await Task.Delay(1000);

            await person.InitializePersonAsync();
            IsEnabled = true;
            _gotoInfoDisplay?.Invoke(person);
            ClearData();
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
        private Action<Person> _gotoInfoDisplay;
        private bool _isEnabled;
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

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    OnPropertyChanged(nameof(IsEnabled));
                }
            }
        }
        #endregion

        public InputMenuViewModel(Action<Person> toInfoDisplay)
        {
            SelectedDate = DateTime.Today;
            IsEnabled = true;
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

        private void ClearData()
        {
            Name = String.Empty;
            Surname = String.Empty;
            Email = String.Empty;
            SelectedDate = DateTime.Today;
        }
    }
}
