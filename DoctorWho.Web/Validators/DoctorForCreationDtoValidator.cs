using DoctorWho.Web.Models;
using FluentValidation;

namespace DoctorWho.Web.Validators
{
    public class DoctorForCreationDtoValidator:AbstractValidator<DoctorForCreationDto>
    {
        public DoctorForCreationDtoValidator()
        {
            RuleFor(d => d.DoctorName).NotEmpty().NotNull()
                .WithMessage("Name is required");
            RuleFor(d => d.DoctorNumber).NotEmpty().NotNull() 
                .WithMessage("Number is required");
            RuleFor(d=>d.LastEpisodeDate).Empty()
                .When(d =>d.FirstEpisodeDate==null)
                .WithMessage("LastEpisodeDate should has no value when FirstEpisodeDate has no value");
            RuleFor(d => d.LastEpisodeDate).GreaterThanOrEqualTo(d => d.FirstEpisodeDate)
                .WithMessage("LastEpisodeDate should be greater than or equal to FirstEpisodeDate.");
        }
    }
}
