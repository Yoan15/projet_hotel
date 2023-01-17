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
    class EtagesProfile : Profile
    {
        public EtagesProfile()
        {
            CreateMap<Etage, EtageDTO>();
            CreateMap<EtageDTO, Etage>();
            CreateMap<Etage, EtageDTONum>();
            CreateMap<EtageDTONum, Etage>();
        }
    }
}
