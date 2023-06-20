using DoctorWho.Db;
using EpisodeWhoRepository;

namespace DoctorWho.Web.Services.Repository;

public class EpisodeRepository : IEpisodeRepository
{
    public Task<IEnumerable<Episode>> GetAllEpisodesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Episode?> GetEpisodeAsync(int id)
    {
        throw new NotImplementedException();
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