using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab02Shvachka.Services;

namespace Lab02Shvachka.Models
{
    internal class Person
    {
        #region Fields
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthday;
        #endregion

        #region Constructors
        public Person(string name, string surname, string email, DateTime dateOfBirthday)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _birthday = dateOfBirthday;

            FullName = $"{name} {surname}";

            DateAnalyser analyser = new DateAnalyser(dateOfBirthday);
            Age = analyser.CalculateAge();
            IsAdult = analyser.isAdult();
            IsBirthday = analyser.IsBirthdayToday();

            WesternZodiacSign = ZodiacCalculator.CalculateWesternZodiac(dateOfBirthday);
            ChineseZodiacSign = ZodiacCalculator.CalculateChineseZodiac(dateOfBirthday);
        }
        public Person(string name, string surname, string email) : this(name, surname, email, DateTime.MinValue)
        {
        }
        public Person(string name, string surname, DateTime dateOfBirthday) : this(name, surname, String.Empty, dateOfBirthday)
        {
        }
        #endregion

        #region Properties
        public string Name { get { return _name; } }
        public string Surname { get { return _surname; } }
        public string FullName { get; }
        public string Email { get { return _email; } }
        public DateTime DateOfBirth { get { return _birthday; } }
        public String FormattedDateOfBirthday { get { return DateOfBirth.ToString("dd.MM.yyyy"); } }

        public int Age { get; }
        public bool IsAdult { get; }
        public WesternZodiacSign WesternZodiacSign { get; }
        public ChineseZodiacSign ChineseZodiacSign { get; }
        public bool IsBirthday { get; }
        #endregion



    }
}
