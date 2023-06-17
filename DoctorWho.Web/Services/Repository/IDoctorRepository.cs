using DoctorWho.Db;

namespace DoctorWhoRepository;

public interface IDoctorRepository
{
    Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
    Task<Doctor?> GetDoctorAsync(int id);
    Task<bool> InsertDoctorAsync(Doctor doctor);
    Task<bool> UpdateDocotrAsync(int id, Doctor data);
}