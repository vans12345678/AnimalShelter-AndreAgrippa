using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter_AndreAgrippa.Models
{
    public class Owner
    {
        public int ownerID { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public string phonenumber { get; set; }

        public bool ValidateEntry(string firstname, string lastname, string phonenumber)
        {
            int phoneNum;

            if (string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname) || string.IsNullOrEmpty(phonenumber))
            {
                return false;
            }

            if (firstname.Length < 3 || lastname.Length < 3)
            {
                return false;
            }
            if (phonenumber.Length != 10  || int.TryParse(phonenumber, out phoneNum) == false)
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
