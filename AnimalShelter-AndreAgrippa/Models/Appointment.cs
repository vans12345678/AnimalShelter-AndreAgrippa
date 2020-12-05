
// File: Appointment.cs
// Name: Andre Agrippa
// Date: 12 / 04 / 2020
// Purpose: Appointment class that has appointment data members and getters/setters, validates itself.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter_AndreAgrippa.Models
{
    public class Appointment
    {
        //Data members
        public int appointmentID { get; set; }
        public DateTime date { get; set; }
        public int animalID { get; set; }
        public int ownerID { get; set; }
        public virtual Animal animal { get; set; }
        public virtual Owner owner { get; set; }


    }
}
