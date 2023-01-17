using AutoMapper;
using GestionHotel.Data;
using GestionHotel.Data.Dtos;
using GestionHotel.Data.Models;
using GestionHotel.Data.Profiles;
using GestionHotel.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.Controllers
{
    public class StatutsChambresController : ControllerBase
    {

        private readonly StatutsChambresServices _service;
        private readonly IMapper _mapper;

        public StatutsChambresController(HotelContext _context)
        {
            _service = new StatutsChambresServices(_context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<StatutsChambresProfile>();
            });
            _mapper = config.CreateMapper();
        }

        public StatutsChambresController(StatutsChambresServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IEnumerable<StatutsChambreDTO> GetAllStatutsChambres()
        {
            var listeStatutsChambres = _service.GetAllStatutsChambres();
            return _mapper.Map<IEnumerable<StatutsChambreDTO>>(listeStatutsChambres);
        }

        public StatutsChambreDTO GetStatutsChambreById(int id)
        {
            var statutsChambreItem = _service.GetStatutsChambreById(id);
            if (statutsChambreItem != null)
            {
                return _mapper.Map<StatutsChambreDTO>(statutsChambreItem);
            }
            return new StatutsChambreDTO();
        }

        public StatutsChambreDTO CreateStatutsChambre(StatutsChambre statutsChambre)
        {
            _service.AddStatutsChambre(statutsChambre);
            return GetStatutsChambreById(statutsChambre.IdStatutChambre);
        }

        public int UpdateStatutsChambre(StatutsChambre statutsChambre)
        {
            var statutsChambreFromRepo = _service.GetStatutsChambreById(statutsChambre.IdStatutChambre);
            if (statutsChambreFromRepo == null)
            {
                return -1;
            }
            _mapper.Map(statutsChambre, statutsChambreFromRepo);
            _service.UpdateStatutsChambre(statutsChambreFromRepo);
            return 0;
        }

        public int DeleteStatutsChambre(int id)
        {
            var statusChambreModelFromRepo = _service.GetStatutsChambreById(id);
            if (statusChambreModelFromRepo == null)
            {
                return -1;
            }
            _service.DeleteStatutsChambre(statusChambreModelFromRepo);
            return 0;
        }
    }
}
