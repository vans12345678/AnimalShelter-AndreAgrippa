// File: Appointment Controller.cs
// Name: Andre Agrippa
// Date: 12 / 04 / 2020
// Purpose: Owners controller, returns views based on user selection
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnimalShelter_AndreAgrippa.Models;

namespace AnimalShelter_AndreAgrippa.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly ShelterContext _context;

        public AppointmentsController(ShelterContext context)
        {
            _context = context;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var shelterContext = _context.Appointments.Include(a => a.animal).Include(a => a.owner);
            return View(await shelterContext.ToListAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.animal)
                .Include(a => a.owner)
                .FirstOrDefaultAsync(m => m.appointmentID == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["animalID"] = new SelectList(_context.Animals, "animalID", "animalID");
            ViewData["ownerID"] = new SelectList(_context.Owners, "ownerID", "ownerID");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("appointmentID,date,animalID,ownerID")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["animalID"] = new SelectList(_context.Animals, "animalID", "animalID", appointment.animalID);
            ViewData["ownerID"] = new SelectList(_context.Owners, "ownerID", "ownerID", appointment.ownerID);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["animalID"] = new SelectList(_context.Animals, "animalID", "animalID", appointment.animalID);
            ViewData["ownerID"] = new SelectList(_context.Owners, "ownerID", "ownerID", appointment.ownerID);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("appointmentID,date,animalID,ownerID")] Appointment appointment)
        {
            if (id != appointment.appointmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.appointmentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["animalID"] = new SelectList(_context.Animals, "animalID", "animalID", appointment.animalID);
            ViewData["ownerID"] = new SelectList(_context.Owners, "ownerID", "ownerID", appointment.ownerID);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.animal)
                .Include(a => a.owner)
                .FirstOrDefaultAsync(m => m.appointmentID == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.appointmentID == id);
        }
    }
}
