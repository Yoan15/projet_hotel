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
    public class ChambresProfile : Profile
    {
        public ChambresProfile()
        {
            CreateMap<Chambre, ChambreDTO>();
            CreateMap<ChambreDTO, Chambre>();

            CreateMap<Chambre, ChambreDTOStatut>();
            CreateMap<ChambreDTOStatut, Chambre>();


            CreateMap<Chambre, ChambreDTOAvecDetail>().ForMember(c => c.NumEtage, a => a.MapFrom(s => s.EtageObj.NumEtage)).ForMember(c => c.LibelleTypeChambre, a => a.MapFrom(s => s.TypeChambreObj.LibelleTypeChambre)).ForMember(c => c.LibelleStatutChambre, a => a.MapFrom(s => s.StatutChambreObj.LibelleStatutChambre));
        }
    }
}
