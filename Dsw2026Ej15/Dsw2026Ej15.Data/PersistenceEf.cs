using Microsoft.EntityFrameworkCore;
using Dsw2026Ej15.Domain.Interfaces;
using Dsw2026Ej15.Domain.Entities; 

namespace Dsw2026Ej15.Data
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
           
            return _context.Set<Speciality>().Find(id);
        }

        public void SaveDoctor(Doctor doctor)
        {
            
            var existingDoctor = _context.Set<Doctor>().Find(doctor.Id);

            if (existingDoctor == null)
            {
                
                _context.Set<Doctor>().Add(doctor);
            }
            else
            {
                
                _context.Entry(existingDoctor).CurrentValues.SetValues(doctor);
            }

            
            _context.SaveChanges();
        }

        
        public List<Doctor> GetAllDoctors()
        {
            
            return _context.Set<Doctor>().ToList();
        }

        public Doctor? GetDoctorById(Guid id)
        {
            
            return _context.Set<Doctor>().Find(id);
        }

        public void ToggleDoctorActive(Guid id)
        {
            
            var doctor = _context.Set<Doctor>().Find(id);

            
            if (doctor != null)
            {
                
                doctor.IsActive = !doctor.IsActive;

                
                _context.SaveChanges();
            }
        }
    }
}