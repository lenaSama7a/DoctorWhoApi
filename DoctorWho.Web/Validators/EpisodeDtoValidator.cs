using FluentValidation;
using DoctorWho.Web.Models;
namespace DoctorWho.Web.Validators
{
    public class EpisodeDtoValidator: AbstractValidator<EpisodeDto>
    {
        public EpisodeDtoValidator()
        {
            RuleFor(e => e.DoctorId).NotEmpty().NotNull()
                .WithMessage("DoctorId is required.");
            RuleFor(e => e.AuthorId).NotEmpty().NotNull()
                .WithMessage("AuthorId is required.");
            RuleFor(e => e.SeriesNumber)
                .Must(seriesNumber => seriesNumber.ToString().Length == 10)
                .WithMessage("SeriesNumber should be 10 characters long.");
            RuleFor(e => e.EpisodeNumber).GreaterThan(0);

        }
    }
}
