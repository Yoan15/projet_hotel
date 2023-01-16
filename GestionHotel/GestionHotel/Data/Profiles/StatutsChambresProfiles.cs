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
    public class StatutsChambresProfiles : Profile
    {
        public StatutsChambresProfiles()
        {
            CreateMap<StatutsChambre, StatutsChambreDTO>();
            CreateMap<StatutsChambreDTO, StatutsChambre>();
        }
    }
}
