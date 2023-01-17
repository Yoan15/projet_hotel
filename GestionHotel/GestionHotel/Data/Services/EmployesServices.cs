using GestionHotel.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.Data.Services
{
    public class EmployesServices
    {

        private readonly HotelContext _context;

        public EmployesServices(HotelContext context)
        {
            _context = context;
        }

        public void AddEmploye(Employe e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }
            _context.Employes.Add(e);
            _context.SaveChanges();
        }

        public void DeleteEmploye(Employe e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }
            _context.Employes.Remove(e);
            _context.SaveChanges();
        }

        public IEnumerable<Employe> GetAllEmployes()
        {
            return _context.Employes.Include("TypeEmploye").ToList();
        }

        public Employe GetEmployeById(int id)
        {
            return _context.Employes.Include("TypeEmploye").FirstOrDefault(e => e.IdEmploye == id);
        }

        public void UpdateEmploye(Employe e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }
            _context.SaveChanges();
        }
    }
}
