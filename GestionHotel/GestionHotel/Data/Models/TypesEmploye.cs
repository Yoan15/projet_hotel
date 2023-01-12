using System;
using System.Collections.Generic;

#nullable disable

namespace GestionHotel.Data.Models
{
    public partial class TypesEmploye
    {
        public TypesEmploye()
        {
            Employes = new HashSet<Employe>();
        }

        public int IdTypeEmploye { get; set; }
        public string LibelleTypeEmploye { get; set; }

        public virtual ICollection<Employe> Employes { get; set; }
    }
}
