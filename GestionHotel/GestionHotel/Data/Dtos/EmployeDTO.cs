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
        public int IdEmploye { get; set; }
        public string NomEmploye { get; set; }
        public string PrenomEmploye { get; set; }
        public string Identifiant { get; set; }
        public string Mdp { get; set; }
        public int IdTypeEmploye { get; set; }
    }
    public class EmployeDTOAvecType
    {
        public int IdEmploye { get; set; }
        public string NomEmploye { get; set; }
        public string PrenomEmploye { get; set; }
        public string Identifiant { get; set; }
        public string Mdp { get; set; }

        public virtual TypesEmployeDTO TypeEmploye { get; set; }
    }
    public class EmployeDTOAvecLibelleType
    {
        public int IdEmploye { get; set; }
        public string NomEmploye { get; set; }
        public string PrenomEmploye { get; set; }
        public string Identifiant { get; set; }
        public string Mdp { get; set; }
        public string LibelleTypeEmploye { get; set; }
    }
}
