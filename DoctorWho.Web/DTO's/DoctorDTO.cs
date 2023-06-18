namespace DoctorWho.Web.DTO_s;

public class DoctorDTO
{
    
    public int DoctorNumber { get; set; }

    public string? DoctorName { get; set; }

    public DateOnly BirthDate { get; set; }

    public DateOnly LastEpisodeDate { get; set; }

    public DateOnly FirstEpisodeDate { get; set; }
}