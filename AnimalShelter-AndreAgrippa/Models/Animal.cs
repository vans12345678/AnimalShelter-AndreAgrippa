using System;

namespace AnimalShelter_AndreAgrippa.Models
{
    public class Animal
    {
        public int animalID { get; set; }

        public string species { get; set; }

        public string age { get; set; }

        public string gender { get; set; }

        public bool ValidateEntry(string species, string age, string gender)
        {
            int ageNum;
            string[] genders = {"Boy", "Girl", "Female", "Male"};

            if (string.IsNullOrEmpty(species) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(age))
            {
                return false;
            }
            if (age.Length > 3 || int.TryParse(age, out ageNum) == false)
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
