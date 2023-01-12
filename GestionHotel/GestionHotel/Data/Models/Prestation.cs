using System;
using System.Collections.Generic;

#nullable disable

namespace GestionHotel.Data.Models
{
    public partial class Prestation
    {
        public Prestation()
        {
            Facturations = new HashSet<Facturation>();
        }

        public int IdPrestation { get; set; }
        public string LibellePrestation { get; set; }
        public string DescriptionPrestation { get; set; }
        public decimal? PrixPrestation { get; set; }

        public virtual ICollection<Facturation> Facturations { get; set; }
    }
}
