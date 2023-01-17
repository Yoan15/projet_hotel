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
    public class EmployesController:ControllerBase
    {

        private readonly EmployesServices _service;
        private readonly IMapper _mapper;

        public EmployesController(EmployesServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeDTO>> GetAllEmployes()
        {
            var listeEmployes = _service.GetAllEmployes();
            return Ok(_mapper.Map<IEnumerable<EmployeDTO>>(listeEmployes));
        }

        [HttpGet("{id}", Name = "GetEmployeById")]
        public ActionResult<EmployeDTO> GetEmployeById(int id)
        {
            var employeItem = _service.GetEmployeById(id);
            if (employeItem != null)
            {
                return Ok(_mapper.Map<EmployeDTO>(employeItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<EmployeDTO> CreateEmploye(Employe employe)
        {
            _service.AddEmploye(employe);
            return CreatedAtRoute(nameof(GetEmployeById), new { Id = employe.IdEmploye }, employe);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEmploye(int id, Employe employe)
        {
            var employeFromRepo = _service.GetEmployeById(id);
            if (employeFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(employe, employeFromRepo);
            _service.UpdateEmploye(employeFromRepo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialEmployeUpdate(int id, JsonPatchDocument<Employe> patchDoc)
        {
            var employeFromRepo = _service.GetEmployeById(id);
            if (employeFromRepo == null)
            {
                return NotFound();
            }

            var employeToPatch = _mapper.Map<Employe>(employeFromRepo);
            patchDoc.ApplyTo(employeToPatch, ModelState);

            if (!TryValidateModel(employeToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(employeToPatch, employeFromRepo);
            _service.UpdateEmploye(employeFromRepo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEmploye(int id)
        {
            var employeModelFromRepo = _service.GetEmployeById(id);
            if (employeModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteEmploye(employeModelFromRepo);
            return NoContent();
        }
    }
}
