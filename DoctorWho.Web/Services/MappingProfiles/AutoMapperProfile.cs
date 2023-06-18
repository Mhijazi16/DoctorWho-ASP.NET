using AutoMapper;
using DoctorWho.Web.DTO_s;

namespace DoctorWho.Db.Services.MappingProfiles;

public class AutoMapperProfile : Profile
{
   public AutoMapperProfile()
   {
      CreateMap<DoctorDTO, Doctor>();
      CreateMap<List<DoctorDTO>, List<Doctor>>();
   } 
}