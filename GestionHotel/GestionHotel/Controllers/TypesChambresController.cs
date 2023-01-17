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

    public class TypesChambresController : ControllerBase
    {

        private readonly TypesChambresServices _service;
        private readonly IMapper _mapper;

        public TypesChambresController(HotelContext _context)
        {
            _service = new TypesChambresServices(_context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TypesChambresProfiles>();
            });
            _mapper = config.CreateMapper();
        }

        public TypesChambresController(TypesChambresServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IEnumerable<TypesChambreDTO> GetAllTypesChambres()
        {
            var listeTypesChambres = _service.GetAllTypesChambres();
            return _mapper.Map<IEnumerable<TypesChambreDTO>>(listeTypesChambres);
        }

        public TypesChambreDTO GetTypesChambreById(int id)
        {
            var typeChambreItem = _service.GetTypesChambreById(id);
            if (typeChambreItem != null)
            {
                return _mapper.Map<TypesChambreDTO>(typeChambreItem);
            }
            return new TypesChambreDTO();
        }

        public TypesChambreDTO CreateTypesChambre(TypesChambreDTO typeChambre)
        {
            TypesChambre tc = _mapper.Map<TypesChambre>(typeChambre);
            _service.AddTypesChambre(tc);
            return GetTypesChambreById(typeChambre.IdTypeChambre);
        }

        public int UpdateTypesChambre(TypesChambreDTO typeChambre)
        {
            var typeChambreFromRepo = _service.GetTypesChambreById(typeChambre.IdTypeChambre);
            if (typeChambreFromRepo == null)
            {
                return -1;
            }
            _mapper.Map(typeChambre, typeChambreFromRepo);
            _service.UpdateTypesChambre(typeChambreFromRepo);
            return 0;
        }

        public int DeleteTypesChambre(int id)
        {
            var typeChambreModelFromRepo = _service.GetTypesChambreById(id);
            if (typeChambreModelFromRepo == null)
            {
                return -1;
            }
            _service.DeleteTypesChambre(typeChambreModelFromRepo);
            return 0;
        }
    }
}
