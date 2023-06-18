using DoctorWho.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DoctorWhoRepository;

public class DoctorRepository : IDoctorRepository
{
   private readonly DoctorWhoContext _context;

   public DoctorRepository()
       => _context = new DoctorWhoContext();

   public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
       => await _context.Doctors.OrderBy(d => d.DoctorName).ToListAsync(); 
   
   public async Task<Doctor?> GetDoctorAsync(int id)
       => await _context.Doctors.FindAsync(id);

   public async Task<Doctor?> GetDoctorWithEpisodes(int id)
   {
      return await  _context.Doctors
          .Include(doc => doc.TblEpisodes)
          .FirstOrDefaultAsync(doc=>doc.DoctorId == id);
   }
   public async Task<bool> InsertDoctorAsync(Doctor doctor)
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

   public async Task<bool> UpdateDocotrAsync(int id, Doctor data)
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
       catch
       {
           return false; 
       }
   }

   public async Task<int> DeleteDoctorAsync(Doctor doctor)
   {
       _context.Doctors.Remove(doctor);
       return await _context.SaveChangesAsync();
   }

   public async Task<bool> CreateDoctorAsync(Doctor doctor)
   {
       try
       {
           _context.Doctors.AddAsync(doctor);
           _context.SaveChangesAsync();
           return true; 
       }
       catch(Exception e)
       {
           Console.WriteLine(e);
           return false; 
       }
   }
}