using GestionHotel.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.Data.Services
{
    public class TypesEmployesServices
    {

        private readonly HotelContext _context;

        public TypesEmployesServices(HotelContext context)
        {
            _context = context;
        }

        public void AddTypesEmploye(TypesEmploye tE)
        {
            if (tE == null)
            {
                throw new ArgumentNullException(nameof(tE));
            }
            _context.Typesemployes.Add(tE);
            _context.SaveChanges();
        }

        public void DeleteTypesEmploye(TypesEmploye tE)
        {
            if (tE == null)
            {
                throw new ArgumentNullException(nameof(tE));
            }
            _context.Typesemployes.Remove(tE);
            _context.SaveChanges();
        }

        public IEnumerable<TypesEmploye> GetAllTypesEmployes()
        {
            return _context.Typesemployes.Include("Employes").ToList();
        }

        public TypesEmploye GetTypesEmployeById(int id)
        {
            return _context.Typesemployes.Include("Employes").FirstOrDefault(tE => tE.IdTypeEmploye == id);
        }

        public void UpdateTypesEmploye(TypesEmploye tE)
        {
            if (tE == null)
            {
                throw new ArgumentNullException(nameof(tE));
            }
            _context.SaveChanges();
        }
    }
}
