using AutoMapper;
using DoctorWho.Db.Entities;

namespace DoctorWho.Web.Profiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<DoctorWho.Db.Entities.Doctor, Models.DoctorDto>();
            CreateMap<Models.DoctorForCreationDto, Doctor>();
            CreateMap<Models.DoctorForUpdateDto, Models.DoctorDto>();
            CreateMap<Models.DoctorDto, Doctor>();

        }
    }
}
