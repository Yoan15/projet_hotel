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
    public class EmployesController : ControllerBase
    {

        private readonly EmployesServices _service;
        private readonly IMapper _mapper;

        public EmployesController(HotelContext context)
        {
            _service = new EmployesServices(context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EmployesProfile>();
                cfg.AddProfile<TypesEmployesProfile>();
            });
            _mapper = config.CreateMapper();
        }

        public IEnumerable<EmployeDTO> GetAllEmployes()
        {
            var listeEmployes = _service.GetAllEmployes();
            return _mapper.Map<IEnumerable<EmployeDTO>>(listeEmployes);
        }

        public Employe GetEmployeById(int id)
        {
            var employeItem = _service.GetEmployeById(id);
            if (employeItem != null)
            {
                return employeItem;
            }
            return new Employe();
        }

        public Employe CreateEmploye(EmployeDTOAvecLibelleType employe)
        {
            Employe e = _mapper.Map<Employe>(employe);
            _service.AddEmploye(e);
            return GetEmployeById(e.IdEmploye);
        }

        public int UpdateEmploye(EmployeDTOAvecLibelleType employe)
        {
            var employeFromRepo = _service.GetEmployeById(employe.IdEmploye);
            if (employeFromRepo == null)
            {
                return -1;
            }
            _mapper.Map(employe, employeFromRepo);
            _service.UpdateEmploye(employeFromRepo);
            return 0;
        }

        public int DeleteEmploye(int id)
        {
            var employeModelFromRepo = _service.GetEmployeById(id);
            if (employeModelFromRepo == null)
            {
                return -1;
            }
            _service.DeleteEmploye(employeModelFromRepo);
            return 0;
        }
    }
}
