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

    class EtagesController : ControllerBase
    {

        private readonly EtagesServices _service;
        private readonly IMapper _mapper;

        public EtagesController(EtagesServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public EtagesController(HotelContext _context)
        {
            _service = new EtagesServices(_context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EtagesProfile>();
            });
            _mapper = config.CreateMapper();
        }

        public IEnumerable<EtageDTO> GetAllEtages()
        {
            var listeEtages = _service.GetAllEtages();
            return _mapper.Map<IEnumerable<EtageDTO>>(listeEtages);
        }

        public EtageDTO GetEtageById(int id)
        {
            var etgItem = _service.GetEtageById(id);
            if (etgItem != null)
            {
                return _mapper.Map<EtageDTO>(etgItem);
            }
            return _mapper.Map<EtageDTO>(etgItem);
        }

        public ActionResult<EtageDTO> CreateEtage(Etage etg)
        {
            _service.AddEtage(etg);
            return CreatedAtRoute(nameof(GetEtageById), new { Id = etg.IdEtage }, etg);
        }

        public ActionResult UpdateEtage(int id, Etage etg)
        {
            var etgFromRepo = _service.GetEtageById(id);
            if (etgFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(etg, etgFromRepo);
            _service.UpdateEtage(etgFromRepo);
            return NoContent();
        }

        public ActionResult PartialEtageUpdate(int id, JsonPatchDocument<Etage> patchDoc)
        {
            var etgFromRepo = _service.GetEtageById(id);
            if (etgFromRepo == null)
            {
                return NotFound();
            }

            var etgToPatch = _mapper.Map<Etage>(etgFromRepo);
            patchDoc.ApplyTo(etgToPatch, ModelState);

            if (!TryValidateModel(etgToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(etgToPatch, etgFromRepo);
            _service.UpdateEtage(etgFromRepo);

            return NoContent();
        }
        public ActionResult DeleteEtage(int id)
        {
            var etgModelFromRepo = _service.GetEtageById(id);
            if (etgModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteEtage(etgModelFromRepo);
            return NoContent();
        }
    }
}
