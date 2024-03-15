using System;

namespace Lab02Shvachka.Services
{
    static class ZodiacCalculator
    {
        static public WesternZodiacSign CalculateWesternZodiac(DateTime dt)
        {
            int day = dt.Day;
            int month = dt.Month;

            if ((month == 3 && day >= 21) || (month == 4 && day <= 20))
                return WesternZodiacSign.Ram;
            if ((month == 4 && day >= 21) || (month == 5 && day <= 21))
                return WesternZodiacSign.Bull;
            if ((month == 5 && day >= 22) || (month == 6 && day <= 21))
                return WesternZodiacSign.Twins;
            if ((month == 6 && day >= 22) || (month == 7 && day <= 23))
                return WesternZodiacSign.Crab;
            if ((month == 7 && day >= 24) || (month == 8 && day <= 23))
                return WesternZodiacSign.Lion;
            if ((month == 8 && day >= 24) || (month == 9 && day <= 23))
                return WesternZodiacSign.Maiden;
            if ((month == 9 && day >= 24) || (month == 10 && day <= 23))
                return WesternZodiacSign.Scales;
            if ((month == 10 && day >= 24) || (month == 11 && day <= 22))
                return WesternZodiacSign.Scorpion;
            if ((month == 11 && day >= 23) || (month == 12 && day <= 21))
                return WesternZodiacSign.Archer;
            if ((month == 12 && day >= 22) || (month == 1 && day <= 20))
                return WesternZodiacSign.Goat;
            if ((month == 1 && day >= 21) || (month == 2 && day <= 19))
                return WesternZodiacSign.Water_bearer;

            return WesternZodiacSign.Fish;
        }

        static public ChineseZodiacSign CalculateChineseZodiac(DateTime dt)
        {
            int zodiacYear = (dt.Year - 1900) % 12;
            if (zodiacYear < 0)
            {
                zodiacYear += 12;
            }
            return (ChineseZodiacSign)zodiacYear;
        }
    }

    #region Enums
    public enum WesternZodiacSign
    {
        Ram,
        Bull,
        Twins,
        Crab,
        Lion,
        Maiden,
        Scales,
        Scorpion,
        Archer,
        Goat,
        Water_bearer,
        Fish
    }
    public enum ChineseZodiacSign
    {
        Rat,
        Ox,
        Tiger,
        Rabbit,
        Dragon,
        Snake,
        Horse,
        Sheep,
        Monkey,
        Rooster,
        Dog,
        Pig
    } 
    #endregion

}
