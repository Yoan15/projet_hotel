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
    public class StatutsChambresProfile : Profile
    {
        public StatutsChambresProfile()
        {
            CreateMap<StatutsChambre, StatutsChambreDTO>();
            CreateMap<StatutsChambreDTO, StatutsChambre>();
        }
    }
}
