using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Lab02Shvachka.Services;

namespace Lab02Shvachka.Models
{
    public class Person
    {
        #region Fields
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthday;

        private bool _initialized = false;
        private Lazy<Task> _task;
        #endregion

        #region Properties
        public string Name { get { return _name; } }
        public string Surname { get { return _surname; } }
        public string FullName { get; private set; }
        public string Email { get { return _email; } }
        public DateTime DateOfBirth { get { return _birthday; } }
        public String FormattedDateOfBirthday { get { return DateOfBirth.ToString("dd.MM.yyyy"); } }

        public int Age { get; private set; }
        public bool IsAdult { get; private set; }
        public WesternZodiacSign WesternZodiacSign { get; private set; }
        public ChineseZodiacSign ChineseZodiacSign { get; private set; }
        public bool IsBirthday { get; private set; }
        #endregion

        #region Constructors
        public Person(string name, string surname, string email, DateTime dateOfBirthday)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _birthday = dateOfBirthday;
        }
        public Person(string name, string surname, string email) : this(name, surname, email, DateTime.MinValue)
        {
        }
        public Person(string name, string surname, DateTime dateOfBirthday) : this(name, surname, String.Empty, dateOfBirthday)
        {
        }
        #endregion

        //  to be honest, it was hard for me to put async in a right place.
        //  i think having methods inside of models is bad behaviour, but it is impossible to make constructor async
        //  or just write a method in a viewmodel, because it is necessary to make properties readonly. (due to init outside of constructor, i have to use private set)
        //  i also read about async lazy initialization, but didn't find any benefits in my case,
        //  so i am unsure of my realization
        public async Task InitializePersonAsync()
        {
            if (!_initialized)
            {
                FullName = $"{Name} {Surname}";

                DateAnalyser analyser = new DateAnalyser(DateOfBirth);
                Age = await Task.Run(() => analyser.CalculateAge());
                IsAdult = await Task.Run(() => analyser.isAdult());
                IsBirthday = await Task.Run(() => analyser.IsBirthdayToday());

                WesternZodiacSign = await Task.Run(() => ZodiacCalculator.CalculateWesternZodiac(DateOfBirth));
                ChineseZodiacSign = await Task.Run(() => ZodiacCalculator.CalculateChineseZodiac(DateOfBirth));
            }
        }
    }
}
