using System;
using System.Collections.Generic;

#nullable disable

namespace GestionHotel.Data.Models
{
    public partial class TypesPaiement
    {
        public TypesPaiement()
        {
            Facturations = new HashSet<Facturation>();
        }

        public int IdTypePaiement { get; set; }
        public string LibelleTypePaiement { get; set; }

        public virtual ICollection<Facturation> Facturations { get; set; }
    }
}
