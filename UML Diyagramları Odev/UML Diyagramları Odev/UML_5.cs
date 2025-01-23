using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Diyagramları_Odev
{
    internal partial class Program
    {
        public class Transaction
        {
            private int Id { get; set; }
            private string Name { get; set; }
            private string Date { get; set; }
            private string Address { get; set; }
            public void Update() { }
        }

        public class Reservation
        {
            private int Id { get; set; }
            private string Details { get; set; }
            private string List { get; set; }
            public void Confirmation() { }
        }

        public class Customer
        {
            private int Id { get; set; }
            private string Name { get; set; }
            private string Contact { get; set; }
            private string Address { get; set; }
            private int Payment { get; set; }
            public void Update() { }
        }

        public class Car
        {
            private int Id { get; set; }
            private string Details { get; set; }
            private string OrderType { get; set; }
            public void ProcessDebit() { }
        }

        public class RentingOwner
        {
            private int Id { get; set; }
            private string Name { get; set; }
            private string Age { get; set; }
            private string ContactNum { get; set; }
            private string Username { get; set; }
            private string Password { get; set; }
            public void VerifyAccount() { }
        }

        public class Payment
        {
            private int Id { get; set; }
            private int CardNumber { get; set; }
            private string Amount { get; set; }
            public void Add() { }
            public void Update() { }
        }

        public class Rentals
        {
            private int Id { get; set; }
            private string Name { get; set; }
            private string Price { get; set; }
            public void Add() { }
        }

    }
}
