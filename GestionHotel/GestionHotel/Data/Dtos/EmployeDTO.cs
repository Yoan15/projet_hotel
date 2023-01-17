using GestionHotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.Data.Dtos
{
    public class EmployeDTO
    {
        
        public string NomEmploye { get; set; }
        public string PrenomEmploye { get; set; }
        public string Identifiant { get; set; }
        public string Mdp { get; set; }

        public virtual TypesEmployeDTOAvecLibelle TypeEmploye { get; set; }
    }
    public class EmployeDTOSansTypeEmploye
    {
        public string NomEmploye { get; set; }
        public string PrenomEmploye { get; set; }
        public string Identifiant { get; set; }
        public string Mdp { get; set; }
    }
}
