using AutoMapper;
using GestionHotel.Data.Dtos;
using GestionHotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.Data.Profiles
{
    public class EmployesProfile : Profile
    {
        public EmployesProfile()
        {
            CreateMap<Employe, EmployeDTO>();
            CreateMap<EmployeDTO, Employe>();

            CreateMap<Employe, EmployeDTOAvecLibelleType>().ForMember(eDTO => eDTO.LibelleTypeEmploye, o => o.MapFrom(e => e.TypeEmploye.LibelleTypeEmploye));
            CreateMap<EmployeDTOAvecLibelleType, Employe>();
        }
    }
}
