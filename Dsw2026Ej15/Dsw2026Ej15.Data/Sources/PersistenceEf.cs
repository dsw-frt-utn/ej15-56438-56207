using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Dsw2026Ej15.Domain.Interfaces;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Data.Context;

namespace Dsw2026Ej15.Data.Sources
{
    public class PersistenceEf : IPersistence
    {
        private readonly AppDbContext _context;

        public PersistenceEf(AppDbContext context)
        {
            _context = context;
        }
        public Speciality? GetSpecialityById(Guid id)
        {
            return _context.Specialities
                .FirstOrDefault(s => s.Id == id);
        }

        public void SaveDoctor(Doctor doctor)
        {
            var speciality = GetSpecialityById(doctor.SpecialityId);
            if (speciality == null)
                throw new ArgumentException("La especialidad no existe");

            if (_context.Doctors.Any(d => d.Id == doctor.Id))
            {
                _context.Doctors.Update(doctor);
            }
            else
            {
                _context.Doctors.Add(doctor);
            }
            _context.SaveChanges();
        }

        public List<Doctor> GetAllDoctors()
        {
            return _context.Doctors
                .Include(d => d.Speciality)
                .ToList();
        }

        public Doctor? GetDoctorById(Guid id)
        {
            return _context.Doctors
                .Include(d => d.Speciality)
                .FirstOrDefault(d => d.Id == id);
        }

        public void ToggleDoctorActive(Guid id)
        {
            var doctor = GetDoctorById(id);
            if (doctor != null)
            {
                doctor.IsActive = !doctor.IsActive;
                _context.SaveChanges();
            }
        }
    }
}
