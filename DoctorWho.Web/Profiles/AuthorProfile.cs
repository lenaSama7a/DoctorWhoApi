using AutoMapper;
using DoctorWho.Db.Entities;
using DoctorWho.Web.Models;

namespace DoctorWho.Web.Profiles
{
    public class AuthorProfile:Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDto, Author>();
            CreateMap<AuthorForUpdateDto, AuthorDto>();
        }
    }
}
