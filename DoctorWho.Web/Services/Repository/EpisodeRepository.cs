using DoctorWho.Db;
using EpisodeWhoRepository;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Web.Services.Repository;

public class EpisodeRepository : IEpisodeRepository
{
    private readonly DoctorWhoContext _context;

    public EpisodeRepository()
        => _context = new DoctorWhoContext();
    public async Task<IEnumerable<Episode>> GetAllEpisodesAsync()
    {
        return await _context.Episodes.ToListAsync();
    }

    public async Task<Episode?> GetEpisodeAsync(int id)
    {
        return await _context.Episodes.FindAsync(id);
    }

    public async Task<bool> InsertEpisodeAsync(Episode episode)
    {
        try
        {
            await _context.Episodes.AddAsync(episode);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public bool DeleteEpisodeAsync(Episode episode)
    {
        try
        {
            _context.Episodes.Remove(episode);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> UpdateEpisodeAsync(int id, Episode data)
    {
        try
        {
            _context.Episodes.Update(data);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}