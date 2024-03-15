using System;
using Lab02Shvachka.Models;
using Lab02Shvachka.Tools;

namespace Lab02Shvachka.Services
{
    class DateAnalyser
    {
        private DateTime _date;

        public DateAnalyser(DateTime date)
        {
            _date = date;
        }

        public bool isAdult()
        {
            return CalculateAge() >= 18;
        }

        public int CalculateAge()
        {
            int age = DateTime.Today.Year - _date.Year;
            if (_date > DateTime.Today.AddYears(-age))
            {
                age--;
            }
            return age;
        }

        public bool IsValid()
        {
            var age = CalculateAge();
            return age >= 0 && age <= 135;
        }

        public bool IsBirthdayToday()
        {
            return DateTime.Today.Month == _date.Month && DateTime.Today.Day == _date.Day;
        }

    }
}
