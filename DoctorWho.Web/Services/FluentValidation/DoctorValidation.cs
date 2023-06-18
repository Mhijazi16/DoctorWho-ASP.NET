using DoctorWho.Db;
using FluentValidation;

namespace DoctorWho.Web.Services.FluentValidation;

public class DoctorValidation : AbstractValidator<Doctor>
{
    public DoctorValidation()
    {
        RuleFor(D => D.DoctorName)
            .NotEmpty().NotNull().WithMessage("The Name is Required.");
        RuleFor(D => D.DoctorNumber)
            .NotEmpty().NotEmpty().WithMessage("The Number is Required.");
        RuleFor(D => D.LastEpisodeDate)
            .GreaterThanOrEqualTo(D => D.FirstEpisodeDate)
            .Must((doctor, lastEpisode) => ValidateLastEpisode(doctor.FirstEpisodeDate, lastEpisode));

    }

    private bool ValidateLastEpisode(DateOnly doctorFirstEpisodeDate, DateOnly lastEpisode)
    {
        return lastEpisode == null && doctorFirstEpisodeDate == null;
    }
}