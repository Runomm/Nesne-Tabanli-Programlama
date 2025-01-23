using System;
using System.Collections.Generic;

namespace HaftaUygulaması6
{
    // Overloading
    class Calculator
    {
        public int Add(int a, int b) => a + b;
        public int Add(int a, int b, int c) => a + b + c;
        public int Add(params int[] numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
                sum += num;
            return sum;
        }

        public double CalculateArea(double side) => side * side;
        public double CalculateArea(double width, double height) => width * height;
        public double CalculateArea(double radius, bool isCircle) => Math.PI * radius * radius; 

        public int CalculateDifference(DateTime date1, DateTime date2) => (date2 - date1).Days;
        public double CalculateDifferenceInHours(DateTime date1, DateTime date2) => (date2 - date1).TotalHours;
        public (int years, int months, int days) CalculateDetailedDifference(DateTime date1, DateTime date2)
        {
            int years = date2.Year - date1.Year;
            int months = date2.Month - date1.Month;
            int days = date2.Day - date1.Day;

            if (days < 0)
            {
                months--;
                days += DateTime.DaysInMonth(date1.Year, date1.Month);
            }
            if (months < 0)
            {
                years--;
                months += 12;
            }
            return (years, months, days);
        }
    }

    class Library
    {
        private string[] books = { "C# Guide", "Data Structures", "Algorithms" };

        public string this[int index]
        {
            get => index >= 0 && index < books.Length ? books[index] : "Invalid index";
            set
            {
                if (index >= 0 && index < books.Length)
                    books[index] = value;
            }
        }
    }

    class StudentGrades
    {
        private Dictionary<string, int> grades = new Dictionary<string, int>();

        public int this[string subject]
        {
            get => grades.ContainsKey(subject) ? grades[subject] : throw new KeyNotFoundException("Subject not found");
            set => grades[subject] = value;
        }
    }

    struct Time
    {
        public int Hour { get; }
        public int Minute { get; }

        public Time(int hour, int minute)
        {
            Hour = hour >= 0 && hour < 24 ? hour : 0;
            Minute = minute >= 0 && minute < 60 ? minute : 0;
        }

        public int TotalMinutes() => Hour * 60 + Minute;

        public int DifferenceInMinutes(Time other) => Math.Abs(this.TotalMinutes() - other.TotalMinutes());
    }

    class Program
    {
        static void Main()
        {
            Calculator calc = new Calculator();
            Console.WriteLine("Overloading Örnekleri:");
            Console.WriteLine(calc.Add(5, 10)); 
            Console.WriteLine(calc.Add(1, 2, 3)); 
            Console.WriteLine(calc.Add(1, 2, 3, 4)); 

            Console.WriteLine(calc.CalculateArea(5));
            Console.WriteLine(calc.CalculateArea(4, 6));
            Console.WriteLine(calc.CalculateArea(3, true));

            DateTime d1 = new DateTime(2020, 1, 1);
            DateTime d2 = new DateTime(2023, 6, 15);
            Console.WriteLine(calc.CalculateDifference(d1, d2)); 
            Console.WriteLine(calc.CalculateDifferenceInHours(d1, d2));
            var result = calc.CalculateDetailedDifference(d1, d2);
            Console.WriteLine($"{result.years} yıl, {result.months} ay, {result.days} gün");

            Library library = new Library();
            Console.WriteLine("\nKitaplık Örnekleri:");
            Console.WriteLine(library[1]);
            library[1] = "New Book";
            Console.WriteLine(library[1]);
            Console.WriteLine(library[5]);

            StudentGrades student = new StudentGrades();
            Console.WriteLine("\nÖğrenci Notları Örnekleri:");
            student["Math"] = 90;
            Console.WriteLine(student["Math"]);

            Time t1 = new Time(12, 30);
            Time t2 = new Time(14, 45);
            Console.WriteLine("\nZaman İşlemleri Örnekleri:");
            Console.WriteLine(t1.DifferenceInMinutes(t2)); 
        }
    }
}
