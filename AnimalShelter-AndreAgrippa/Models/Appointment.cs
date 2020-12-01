using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter_AndreAgrippa.Models
{
    public class Appointment
    {
        public int appointmentID { get; set; }

        public DateTime date { get; set; }

        public int animalID { get; set; }
        public int ownerID { get; set; }
        public virtual Animal animal { get; set; }
        public virtual Owner owner { get; set; }
    }
}
