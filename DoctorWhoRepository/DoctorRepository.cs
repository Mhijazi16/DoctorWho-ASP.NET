using DoctorWho.Db;
using DoctorWho.Web.DTO_s;
using Microsoft.EntityFrameworkCore;

namespace DoctorWhoRepository;

public class DoctorRepository
{
   private readonly DoctorWhoContext _context;

   public DoctorRepository()
       => _context = new DoctorWhoContext();
   public async Task<IEnumerable<Doctor>> GetAllDoctors()
       => await _context.Doctors.ToListAsync();
   public async Task<Doctor?> GetDoctorById(int id)
       => await _context.Doctors.FindAsync(id);

   public async Task<bool> InsertDoctor(Doctor doctor)
   {
       await _context.Doctors.AddAsync(doctor);
       try
       {
           await _context.SaveChangesAsync();
           return true; 
       }
       catch
       {
           return false;
       }
   }

   public async Task<bool> UpdateDocotr(int id, Doctor data)
   {
       var doctor = await _context.Doctors.FindAsync(id);

       if (doctor == null)
           return false; 
       doctor.DoctorName = data.DoctorName;
       doctor.DoctorNumber = data.DoctorNumber;
       doctor.FirstEpisodeDate = data.FirstEpisodeDate;
       doctor.LastEpisodeDate = data.LastEpisodeDate;
       doctor.BirthDate = data.BirthDate;

       _context.Update(doctor);
       
       try
       {
           await _context.SaveChangesAsync();
           return true;
       }
       catch (Exception e)
       {
           return false; 
       }
   }

}