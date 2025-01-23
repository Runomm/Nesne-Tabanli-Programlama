namespace UML_Diyagramları_Odev
{
    internal partial class Program
    {
        public class Person
        {
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public string EmailAddress { get; set; }

            public void PurchaseParkingPass()
            {
            }
        }

        public class Address
        {
            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public int PostalCode { get; set; }
            public string Country { get; set; }

            public bool Validate()
            {
                return true; 
            }

            public string OutputAsLabel()
            {
                return $"{Street}, {City}, {State}, {PostalCode}, {Country}";
            }
        }

        public class Student : Person
        {
            public int StudentNumber { get; set; }
            public int AverageMark { get; set; }

            public bool IsEligibleToEnroll(string course)
            {
                return true;
            }

            public int GetSeminarsTaken()
            {
                return 0;
            }
        }

        public class Professor : Person
        {
            public int Salary { get; set; }
            public int StaffNumber { get; set; }
            public int YearsOfService { get; set; }
            public int NumberOfClasses { get; set; }

            public void Supervise(Student student)
            {
            }
        }

    }

}