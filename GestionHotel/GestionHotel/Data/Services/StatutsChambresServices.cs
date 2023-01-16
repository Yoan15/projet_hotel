using GestionHotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.Data.Services
{
    class StatutsChambresServices
    {

        private readonly HotelContext _context;

        public StatutsChambresServices(HotelContext context)
        {
            _context = context;
        }

        public void AddStatutsChambre(StatutsChambre sc)
        {
            if (sc == null)
            {
                throw new ArgumentNullException(nameof(sc));
            }
            _context.Statutschambres.Add(sc);
            _context.SaveChanges();
        }

        public void DeleteStatutsChambre(StatutsChambre sc)
        {
            if (sc == null)
            {
                throw new ArgumentNullException(nameof(sc));
            }
            _context.Statutschambres.Remove(sc);
            _context.SaveChanges();
        }

        public IEnumerable<StatutsChambre> GetAllStatutsChambres()
        {
            return _context.Statutschambres.ToList();
        }

        public StatutsChambre GetStatutsChambreById(int id)
        {
            return _context.Statutschambres.FirstOrDefault(sc => sc.IdStatutChambre == id);
        }

        public void UpdateStatutsChambre(StatutsChambre sc)
        {
            if (sc == null)
            {
                throw new ArgumentNullException(nameof(sc));
            }
            _context.SaveChanges();
        }
    }
}
