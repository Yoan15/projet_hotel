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
    public class TypesEmployesController : ControllerBase
    {

        private readonly TypesEmployesServices _service;
        private readonly IMapper _mapper;

        public TypesEmployesController(HotelContext context)
        {
            _service = new TypesEmployesServices(context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EmployesProfile>();
                cfg.AddProfile<TypesEmployesProfile>();
            });
            _mapper = config.CreateMapper();
        }

        public IEnumerable<TypesEmployeDTO> GetAllTypesEmployes()
        {
            var listeTypesEmployes = _service.GetAllTypesEmployes();
            return _mapper.Map<IEnumerable<TypesEmployeDTO>>(listeTypesEmployes);
        }

        public TypesEmploye GetTypesEmployeById(int id)
        {
            var tEmpItem = _service.GetTypesEmployeById(id);
            if (tEmpItem != null)
            {
                return tEmpItem;
            }
            return new TypesEmploye();
        }

        public TypesEmploye CreateTypesEmploye(TypesEmployeDTO tEmp)
        {
            TypesEmploye te = _mapper.Map<TypesEmploye>(tEmp);
            _service.AddTypesEmploye(te);
            return GetTypesEmployeById(te.IdTypeEmploye);
        }

        public int UpdateTypesEmploye(TypesEmployeDTO tEmp)
        {
            var tEmpFromRepo = _service.GetTypesEmployeById(tEmp.IdTypeEmploye);
            if (tEmpFromRepo == null)
            {
                return -1;
            }
            _mapper.Map(tEmp, tEmpFromRepo);
            _service.UpdateTypesEmploye(tEmpFromRepo);
            return 0;
        }

        [HttpDelete("{id}")]
        public int DeleteTypesEmploye(int id)
        {
            var tEmpModelFromRepo = _service.GetTypesEmployeById(id);
            if (tEmpModelFromRepo == null)
            {
                return -1;
            }
            _service.DeleteTypesEmploye(tEmpModelFromRepo);
            return 0;
        }
    }
}
