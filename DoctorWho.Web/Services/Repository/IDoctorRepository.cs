using DoctorWho.Db;

namespace DoctorWhoRepository;

public interface IDoctorRepository
{
    Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
    Task<Doctor?> GetDoctorAsync(int id);
    Task<bool> InsertDoctorAsync(Doctor doctor);
    Task<int> DeleteDoctorAsync(Doctor doctor);
    Task<Doctor?> GetDoctorWithEpisodes(int id);
    Task<bool> CreateDoctorAsync(Doctor doctor);
    Task<bool> UpdateDoctorAsync(int id ,Doctor data);
}