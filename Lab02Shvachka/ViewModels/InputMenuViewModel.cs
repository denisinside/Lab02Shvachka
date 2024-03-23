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
using Lab02Shvachka.Exceptions;

namespace Lab02Shvachka.ViewModels
{
    internal class InputMenuViewModel : ViewModelBase
    {

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
            Person person;
            IsEnabled = false;
            try
            {
                await Task.Delay(1000);
                await ValidatePerson();

                person = new(Name, Surname, Email, SelectedDate);

                await person.InitializePersonAsync();
            }
            catch
            {
                return;
            }
            finally 
            {
                IsEnabled = true;
            }

            _gotoInfoDisplay?.Invoke(person);
            ClearData();
        }

        private bool CanExecute(object obj)
        {
            ToolTipText = UpdateToolTipText();
            return !String.IsNullOrWhiteSpace(Name) && !String.IsNullOrWhiteSpace(Surname) && !String.IsNullOrWhiteSpace(Email);
        }
        #endregion

        #region Fields
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _selectedDate;
        private Action<Person> _gotoInfoDisplay;
        private bool _isEnabled;
        private string _toolTipText;
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
        public string ToolTipText
        {
            get { return _toolTipText; }
            set
            {
                if (_toolTipText != value)
                {
                    _toolTipText = value;
                    OnPropertyChanged(nameof(ToolTipText));
                }
            }
        }

        public MessageViewModel ErrorViewModel { get; }
        public string ErrorMessage { set => ErrorViewModel.Message = value; }

        #endregion

        public InputMenuViewModel(Action<Person> toInfoDisplay)
        {
            SelectedDate = DateTime.Today;
            IsEnabled = true;
            _gotoInfoDisplay = toInfoDisplay;
            ErrorViewModel = new MessageViewModel();
        }

        #region Additional Methods
        private void ClearData()
        {
            Name = String.Empty;
            Surname = String.Empty;
            Email = String.Empty;
            SelectedDate = DateTime.Today;
            ErrorMessage = String.Empty;
        }


        // I think it would be better to catch general exceptions with messages from service
        // and then make a single catch where ErrorMessage = e.Message,
        // but because of the task I wanted to show more variety of exceptions
        private async Task ValidatePerson()
        {
            PersonValidation pv = new(Name, Surname, Email, SelectedDate);
            try
            {
                await pv.ValidatePersonValuesAsync();
            }
            catch (EmailFormatError)
            {
                ErrorMessage = "Invalid email format.";
                throw;
            }
            catch (TooYoungAgeError)
            {
                ErrorMessage = "You are too young for our app.";
                throw;
            }
            catch (TooOldAgeError)
            {
                ErrorMessage = "You must be zombie, if you are so old.";
                throw;
            }
            catch(BannedUserError)
            {
                ErrorMessage = "Get out of here, robber!";
                await Task.Delay(3000);
                Environment.Exit(1);
                throw;
            }
        }

        private string UpdateToolTipText()
        {
            if (String.IsNullOrWhiteSpace(Name))
            {
                return "Name field is empty.";
            }
            if (String.IsNullOrWhiteSpace(Surname))
            {
                return "Surname field is empty.";
            }
            if (String.IsNullOrWhiteSpace(Email))
            {
                return "Email field is empty.";
            }
            return "Click to analyse you!";
        } 
        #endregion
    }
}
