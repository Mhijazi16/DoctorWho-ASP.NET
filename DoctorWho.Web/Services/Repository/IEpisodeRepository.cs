using DoctorWho.Db;

namespace EpisodeWhoRepository;

public interface IEpisodeRepository
{
    Task<IEnumerable<Episode>> GetAllEpisodesAsync();
    Task<Episode?> GetEpisodeAsync(int id);
    Task<bool> InsertEpisodeAsync(Episode doctor);
    bool DeleteEpisodeAsync(Episode doctor);
    Task<bool> CreateEpisodeAsync(Episode doctor);
    Task<bool> UpdateEpisodeAsync(int id ,Episode data);
}