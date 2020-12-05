
// File: ShelterContext.cs
// Name: Andre Agrippa
// Date: 12 / 04 / 2020
// Purpose: ShelterContext class that sets animal, owner and appointment in db

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter_AndreAgrippa.Models
{
    public class ShelterContext : DbContext
    {
        //Constructor for CarContext
        public ShelterContext(DbContextOptions<ShelterContext> options) : base(options)
        {



        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Owner> Owners { get; set; }

    }
}
