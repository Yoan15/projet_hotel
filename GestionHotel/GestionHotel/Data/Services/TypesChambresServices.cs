using GestionHotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.Data.Services
{
    public class TypesChambresServices
    {

        private readonly HotelContext _context;

        public TypesChambresServices(HotelContext context)
        {
            _context = context;
        }

        public void AddTypesChambre(TypesChambre tc)
        {
            if (tc == null)
            {
                throw new ArgumentNullException(nameof(tc));
            }
            _context.Typeschambres.Add(tc);
            _context.SaveChanges();
        }

        public void DeleteTypesChambre(TypesChambre tc)
        {
            if (tc == null)
            {
                throw new ArgumentNullException(nameof(tc));
            }
            _context.Typeschambres.Remove(tc);
            _context.SaveChanges();
        }

        public IEnumerable<TypesChambre> GetAllTypesChambres()
        {
            return _context.Typeschambres.ToList();
        }

        public TypesChambre GetTypesChambreById(int id)
        {
            return _context.Typeschambres.FirstOrDefault(tc => tc.IdTypeChambre == id);
        }

        public void UpdateTypesChambre(TypesChambre tc)
        {
            if (tc == null)
            {
                throw new ArgumentNullException(nameof(tc));
            }
            _context.SaveChanges();
        }
    }
}
