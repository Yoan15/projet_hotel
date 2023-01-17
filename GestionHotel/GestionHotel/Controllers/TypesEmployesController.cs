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
    public class TypesEmployesController:ControllerBase
    {

        private readonly TypesEmployesServices _service;
        private readonly IMapper _mapper;

        public TypesEmployesController(TypesEmployesServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TypesEmployeDTO>> GetAllTypesEmployes()
        {
            var listeTypesEmployes = _service.GetAllTypesEmployes();
            return Ok(_mapper.Map<IEnumerable<TypesEmployeDTO>>(listeTypesEmployes));
        }

        [HttpGet("{id}", Name = "GetTypesEmployeById")]
        public ActionResult<TypesEmployeDTO> GetTypesEmployeById(int id)
        {
            var tEmpItem = _service.GetTypesEmployeById(id);
            if (tEmpItem != null)
            {
                return Ok(_mapper.Map<TypesEmployeDTO>(tEmpItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<TypesEmployeDTO> CreateTypesEmploye(TypesEmploye tEmp)
        {
            _service.AddTypesEmploye(tEmp);
            return CreatedAtRoute(nameof(GetTypesEmployeById), new { Id = tEmp.IdTypeEmploye }, tEmp);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTypesEmploye(int id, TypesEmploye tEmp)
        {
            var tEmpFromRepo = _service.GetTypesEmployeById(id);
            if (tEmpFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(tEmp, tEmpFromRepo);
            _service.UpdateTypesEmploye(tEmpFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialTypesEmployeUpdate(int id, JsonPatchDocument<TypesEmploye> patchDoc)
        {
            var tEmpFromRepo = _service.GetTypesEmployeById(id);
            if (tEmpFromRepo == null)
            {
                return NotFound();
            }

            var tEmpToPatch = _mapper.Map<TypesEmploye>(tEmpFromRepo);
            patchDoc.ApplyTo(tEmpToPatch, ModelState);

            if (!TryValidateModel(tEmpToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(tEmpToPatch, tEmpFromRepo);
            _service.UpdateTypesEmploye(tEmpFromRepo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTypesEmploye(int id)
        {
            var tEmpModelFromRepo = _service.GetTypesEmployeById(id);
            if (tEmpModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteTypesEmploye(tEmpModelFromRepo);
            return NoContent();
        }
    }
}
