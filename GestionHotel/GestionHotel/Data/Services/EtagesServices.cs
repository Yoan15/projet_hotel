using GestionHotel.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.Data.Services
{
    public class EtagesServices
    {

        private readonly HotelContext _context;

        public EtagesServices(HotelContext context)
        {
            _context = context;
        }

        public void AddEtage(Etage etg)
        {
            if (etg == null)
            {
                throw new ArgumentNullException(nameof(etg));
            }
            _context.Etages.Add(etg);
            _context.SaveChanges();
        }

        public void DeleteEtage(Etage etg)
        {
            if (etg == null)
            {
                throw new ArgumentNullException(nameof(etg));
            }
            _context.Etages.Remove(etg);
            _context.SaveChanges();
        }

        public IEnumerable<Etage> GetAllEtages()
        {
            return _context.Etages.ToList();
        }

        public Etage GetEtageById(int id)
        {
            return _context.Etages.FirstOrDefault(etg => etg.IdEtage == id);
        }

        public void UpdateEtage(Etage etg)
        {
            if (etg == null)
            {
                throw new ArgumentNullException(nameof(etg));
            }
            _context.SaveChanges();
        }
    }
}
