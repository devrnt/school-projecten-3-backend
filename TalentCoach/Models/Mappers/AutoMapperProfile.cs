using AutoMapper;
using TalentCoach.Dtos;
using TalentCoach.Models.Domain;

namespace TalentCoach.Models.Mappers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Gebruiker, GebruikerDto>();
            CreateMap<GebruikerDto, Gebruiker>();
        }
    }
}
