using GestionHotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.Data.Services
{
    public class ChambresServices
    {

        private readonly HotelContext _context;

        public ChambresServices(HotelContext context)
        {
            _context = context;
        }

        public void AddChambre(Chambre c)
        {
            if (c == null)
            {
                throw new ArgumentNullException(nameof(c));
            }
            _context.Chambres.Add(c);
            _context.SaveChanges();
        }

        public void DeleteChambre(Chambre c)
        {
            if (c == null)
            {
                throw new ArgumentNullException(nameof(c));
            }
            _context.Chambres.Remove(c);
            _context.SaveChanges();
        }

        public IEnumerable<Chambre> GetAllChambres()
        {
            return _context.Chambres.ToList();
        }

        public Chambre GetChambreById(int id)
        {
            return _context.Chambres.FirstOrDefault(c => c.IdChambre == id);
        }

        public void UpdateChambre(Chambre c)
        {
            if (c == null)
            {
                throw new ArgumentNullException(nameof(c));
            }
            _context.SaveChanges();
        }
    }
}
