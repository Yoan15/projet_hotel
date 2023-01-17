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
    public class EmployesProfile:Profile
    {
        public EmployesProfile()
        {
            CreateMap<Employe, EmployeDTO>().ForMember(eDTO => eDTO.TypeEmploye, o=>o.MapFrom(e => e.TypeEmploye.LibelleTypeEmploye));
            CreateMap<EmployeDTO, Employe>();

            CreateMap<Employe, EmployeDTOSansTypeEmploye>();
            CreateMap<EmployeDTOSansTypeEmploye, Employe>();
        }
    }
}
