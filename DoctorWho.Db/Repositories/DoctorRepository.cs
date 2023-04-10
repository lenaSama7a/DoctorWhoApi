using DoctorWho.Db.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private DoctorWhoCoreDbContext _context;
        public DoctorRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }

        public async Task<Doctor> CreateDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> UpdateDoctorAsync(Doctor doctor)
        {
            var original = await _context.Doctors.FirstOrDefaultAsync(d => d.DoctorId == doctor.DoctorId);
            _context.Entry(original).CurrentValues.SetValues(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }
        public async Task DeleteDoctorAsync(int doctorId)
        {
            var doctor = _context.Doctors.Where(d => d.DoctorId == doctorId).FirstOrDefault();
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Doctor> GetDoctorByIdAsync(int doctorId)
        {
            var doctor = _context.Doctors.Where(d => d.DoctorId == doctorId).FirstOrDefault();
            return doctor;
        }

        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<bool> DoctorExists(int doctorId)
        {
            var doctor = await _context.Doctors.FindAsync(doctorId);
            if (doctor != null)
                return true;
            return false;
        }
    }
}
