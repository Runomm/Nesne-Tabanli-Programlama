using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Diyagramları_Odev
{
    internal partial class Program
    {
        public interface Identifiable
        {
            string Id { get; }
        }

        public interface Experienced
        {
            void ShareExperience();
        }

        public class Vaccine
        {
            public string Name { get; set; }
            public string Type { get; set; }
        }

        public class PetInformation
        {
            public List<string> Traits { get; set; } = new List<string>();
            public List<Vaccine> Vaccines { get; set; } = new List<Vaccine>();
        }

        public class Animal
        {
            public string Type { get; set; }
            public string Breed { get; set; }
            public bool Carnivore { get; set; }
        }

        public class Owner : Experienced
        {
            public string Name { get; set; }
            public void ShareExperience()
            {
            }
        }

        public class Pet : Identifiable
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public Owner Owner { get; set; }
            public Animal Type { get; set; }
            public PetInformation PetInfo { get; set; }

            public void Feed()
            {
            }

            public bool IsHerbivore()
            {
                return true;
            }
        }
    }
}
