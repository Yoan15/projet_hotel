using GestionHotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.Data.Dtos
{
    public class TypesEmployeDTOAvecEmployes
    {
        public TypesEmployeDTOAvecEmployes()
        {
            Employes = new HashSet<EmployeDTOSansTypeEmploye>();
        }

        public string LibelleTypeEmploye { get; set; }

        public virtual ICollection<EmployeDTOSansTypeEmploye> Employes { get; set; }
    }

    public class TypesEmployeDTO
    {
        public int IdTypeEmploye { get; set; }
        public string LibelleTypeEmploye { get; set; }

    }
}
