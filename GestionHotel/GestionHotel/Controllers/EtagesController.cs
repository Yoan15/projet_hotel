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

        public EtageDTO CreateEtage(Etage etg)
        {
            _service.AddEtage(etg);
            return GetEtageById(etg.IdEtage);
        }

        public int UpdateEtage(Etage etg)
        {
            var etgFromRepo = _service.GetEtageById(etg.IdEtage);
            if (etgFromRepo == null)
            {
                return -1;
            }
            _mapper.Map(etg, etgFromRepo);
            _service.UpdateEtage(etgFromRepo);
            return 0;
        }

        public int DeleteEtage(int id)
        {
            var etgModelFromRepo = _service.GetEtageById(id);
            if (etgModelFromRepo == null)
            {
                return -1;
            }
            _service.DeleteEtage(etgModelFromRepo);
            return 0;
        }
    }
}
