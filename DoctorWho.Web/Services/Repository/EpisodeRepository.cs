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

    public Task<bool> InsertEpisodeAsync(Episode doctor)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteEpisodeAsync(Episode doctor)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateEpisodeAsync(Episode doctor)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateEpisodeAsync(int id, Episode data)
    {
        throw new NotImplementedException();
    }
}