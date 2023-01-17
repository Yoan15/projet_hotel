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
    public class StatutsChambresController : ControllerBase
    {

        private readonly StatutsChambresServices _service;
        private readonly IMapper _mapper;

        public StatutsChambresController(StatutsChambresServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StatutsChambreDTO>> GetAllStatutsChambres()
        {
            var listeStatutsChambres = _service.GetAllStatutsChambres();
            return Ok(_mapper.Map<IEnumerable<StatutsChambreDTO>>(listeStatutsChambres));
        }

        [HttpGet("{id}", Name = "GetStatutsChambreById")]
        public ActionResult<StatutsChambreDTO> GetStatutsChambreById(int id)
        {
            var statutItem = _service.GetStatutsChambreById(id);
            if (statutItem != null)
            {
                return Ok(_mapper.Map<StatutsChambreDTO>(statutItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<StatutsChambreDTO> CreateStatutsChambre(StatutsChambre statut)
        {
            _service.AddStatutsChambre(statut);
            return CreatedAtRoute(nameof(GetStatutsChambreById), new { Id = statut.IdStatutChambre }, statut);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStatutsChambre(int id, StatutsChambre statut)
        {
            var statutFromRepo = _service.GetStatutsChambreById(id);
            if (statutFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(statut, statutFromRepo);
            _service.UpdateStatutsChambre(statutFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialStatutsChambreUpdate(int id, JsonPatchDocument<StatutsChambre> patchDoc)
        {
            var statutFromRepo = _service.GetStatutsChambreById(id);
            if (statutFromRepo == null)
            {
                return NotFound();
            }

            var statutToPatch = _mapper.Map<StatutsChambre>(statutFromRepo);
            patchDoc.ApplyTo(statutToPatch, ModelState);

            if (!TryValidateModel(statutToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(statutToPatch, statutFromRepo);
            _service.UpdateStatutsChambre(statutFromRepo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStatutsChambre(int id)
        {
            var statutModelFromRepo = _service.GetStatutsChambreById(id);
            if (statutModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteStatutsChambre(statutModelFromRepo);
            return NoContent();
        }
    }
}
