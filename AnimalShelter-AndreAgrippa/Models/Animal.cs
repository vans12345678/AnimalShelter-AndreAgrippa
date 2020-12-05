// File: Animal.cs
// Name: Andre Agrippa
// Date: 12 / 04 / 2020
// Purpose: Animal class that has animal data members and getters/setters

using System;

namespace AnimalShelter_AndreAgrippa.Models
{
    public class Animal
    {
        //Private data members
        public int animalID { get; set; }

        public string animalName { get; set; }

        public string species { get; set; }

        public string age { get; set; }

        public string gender { get; set; }

        //This function validates animal entry
        public bool ValidateEntry(string animalName, string species, string age, string gender)
        {
            int ageNum;
            string[] genders = {"Boy", "Girl", "Female", "Male"};

            if (string.IsNullOrEmpty(animalName) || string.IsNullOrEmpty(species) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(age))
            {
                return false;
            }
            if (animalName.Length < 2 || age.Length > 3 || int.TryParse(age, out ageNum) == false)
            {
                return false;
            }
            if (!string.Equals(genders[0], "boy", StringComparison.OrdinalIgnoreCase) || !string.Equals(genders[1], "girl", StringComparison.OrdinalIgnoreCase) || !string.Equals(genders[2], "female", StringComparison.OrdinalIgnoreCase) || !string.Equals(genders[3], "male", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
