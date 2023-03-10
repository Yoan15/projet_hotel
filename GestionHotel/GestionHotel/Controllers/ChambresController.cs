using AutoMapper;
using GestionHotel.Data;
using GestionHotel.Data.Dtos;
using GestionHotel.Data.Models;
using GestionHotel.Data.Profiles;
using GestionHotel.Data.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.Controllers
{
    public class ChambresController : ControllerBase
    {

        private readonly ChambresServices _service;
        private readonly IMapper _mapper;

        public ChambresController(HotelContext _context)
        {
            _service = new ChambresServices(_context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ChambresProfile>();
            });
            _mapper = config.CreateMapper();
        }

        public IEnumerable<ChambreDTO> GetAllChambres()
        {
            var listeChambres = _service.GetAllChambres();
            return _mapper.Map<IEnumerable<ChambreDTO>>(listeChambres);
        }

        public IEnumerable<ChambreDTOAvecDetail> GetAllChambresAvecDetail()
        {
            var listeChambres = _service.GetAllChambres();
            return _mapper.Map<IEnumerable<ChambreDTOAvecDetail>>(listeChambres);
        }

        public Chambre GetChambreById(int id)
        {
            var chambreItem = _service.GetChambreById(id);
            if (chambreItem != null)
            {
                return chambreItem;
            }
            return new Chambre();
        }

        public Chambre CreateChambre(ChambreDTO chambre)
        {
            Chambre ch = _mapper.Map<Chambre>(chambre);
            _service.AddChambre(ch);
            return GetChambreById(ch.IdChambre);
        }

        public int UpdateChambre(ChambreDTO chambre)
        {
            var chambreFromRepo = _service.GetChambreById(chambre.IdChambre);
            if (chambreFromRepo == null)
            {
                return -1;
            }
            _mapper.Map(chambre, chambreFromRepo);
            _service.UpdateChambre(chambreFromRepo);
            return 0;
        }
     
        public int DeleteChambre(int id)
        {
            var chambreModelFromRepo = _service.GetChambreById(id);
            if (chambreModelFromRepo == null)
            {
                return -1;
            }
            _service.DeleteChambre(chambreModelFromRepo);
            return 0;
        }
    }
}
