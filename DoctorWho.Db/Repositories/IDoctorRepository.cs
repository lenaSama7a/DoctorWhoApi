using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorWho.Db.Entities;

namespace DoctorWho.Db.Repositories
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetAllDoctorsAsync();
        Task<Doctor> GetDoctorByIdAsync(int doctorId);
        Task<bool> DoctorExists(int doctorId);
        Task DeleteDoctorAsync(int doctorId);
        Task<Doctor> CreateDoctorAsync(Doctor doctor);
        Task<Doctor> UpdateDoctorAsync(Doctor doctor);
    }
}
