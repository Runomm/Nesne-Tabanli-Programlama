using System;
using System.Collections.Generic;

namespace soru_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> validDates = FindValidDates();

            Console.WriteLine("Cihazın kabul ettiği tarihler:");
            foreach (var date in validDates)
            {
                Console.WriteLine(date);
            }
        }

        //uygun tarihleri bulmak için ana fonksiyon
        static List<string> FindValidDates()
        {
            List<string> validDates = new List<string>();
            int currentYear = DateTime.Now.Year;

            //2000 ile 3000 yılları arasında tüm yılları tarıyoruz
            for (int year = currentYear + 1; year <= 3000; year++)
            {
                if (!CheckYearCondition(year)) continue;

                for (int month = 1; month <= 12; month++)
                {
                    if (!CheckMonthCondition(month)) continue;

                    int daysInMonth = DateTime.DaysInMonth(year, month);
                    for (int day = 1; day <= daysInMonth; day++)
                    {
                        if (!IsPrime(day)) continue;

                        validDates.Add($"{day:D2}/{month:D2}/{year}");
                    }
                }
            }
            return validDates;
        }

        //gün asal mı kontrol eden fonksiyon
        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        //ay koşulunu kontrol eden fonksiyon
        static bool CheckMonthCondition(int month)
        {
            //basamak toplamının çift olup olmadığını kontrol ediyoruz
            int sum = 0;
            while (month > 0)
            {
                sum += month % 10;
                month /= 10;
            }
            return sum % 2 == 0;
        }

        //yıl koşulunu kontrol eden fonksiyon
        static bool CheckYearCondition(int year)
        {
            int sum = 0, tempYear = year;
            //yılın rakamları toplamını buluyoruz
            while (tempYear > 0)
            {
                sum += tempYear % 10;
                tempYear /= 10;
            }
            //toplam, yılın dörtte birinden küçük mü diye kontrol ediyoruz
            return sum < year / 4;
        }
    }
}
