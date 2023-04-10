using AutoMapper;
using DoctorWho.Web.Models;

namespace DoctorWho.Web.Profiles
{
    public class EpisodeProfile : Profile
    {
        public EpisodeProfile()
        {
            CreateMap<DoctorWho.Db.Entities.Episode, EpisodeDto>();
            CreateMap<EpisodeDto, DoctorWho.Db.Entities.Episode>();
        }
    }
}
