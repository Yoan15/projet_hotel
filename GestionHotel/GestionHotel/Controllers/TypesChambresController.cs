using AutoMapper;
using GestionHotel.Data.Dtos;
using GestionHotel.Data.Models;
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
    [Route("api/[controller]")]
    [ApiController]
    public class TypesChambresController : ControllerBase
    {

        private readonly TypesChambresServices _service;
        private readonly IMapper _mapper;

        public TypesChambresController(TypesChambresServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TypesChambreDTO>> GetAllTypesChambres()
        {
            var listeTypesChambres = _service.GetAllTypesChambres();
            return Ok(_mapper.Map<IEnumerable<TypesChambreDTO>>(listeTypesChambres));
        }

        [HttpGet("{id}", Name = "GetTypesChambreById")]
        public ActionResult<TypesChambreDTO> GetTypesChambreById(int id)
        {
            var typeChambreItem = _service.GetTypesChambreById(id);
            if (typeChambreItem != null)
            {
                return Ok(_mapper.Map<TypesChambreDTO>(typeChambreItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<TypesChambreDTO> CreateTypesChambre(TypesChambre typeChambre)
        {
            _service.AddTypesChambre(typeChambre);
            return CreatedAtRoute(nameof(GetTypesChambreById), new { Id = typeChambre.IdTypeChambre }, typeChambre);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTypesChambre(int id, TypesChambre typeChambre)
        {
            var typeChambreFromRepo = _service.GetTypesChambreById(id);
            if (typeChambreFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(typeChambre, typeChambreFromRepo);
            _service.UpdateTypesChambre(typeChambreFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialTypesChambreUpdate(int id, JsonPatchDocument<TypesChambre> patchDoc)
        {
            var typeChambreFromRepo = _service.GetTypesChambreById(id);
            if (typeChambreFromRepo == null)
            {
                return NotFound();
            }

            var typeChambreToPatch = _mapper.Map<TypesChambre>(typeChambreFromRepo);
            patchDoc.ApplyTo(typeChambreToPatch, ModelState);

            if (!TryValidateModel(typeChambreToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(typeChambreToPatch, typeChambreFromRepo);
            _service.UpdateTypesChambre(typeChambreFromRepo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTypesChambre(int id)
        {
            var typeChambreModelFromRepo = _service.GetTypesChambreById(id);
            if (typeChambreModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteTypesChambre(typeChambreModelFromRepo);
            return NoContent();
        }
    }
}
