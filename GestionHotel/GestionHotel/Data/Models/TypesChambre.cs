using System;
using System.Collections.Generic;

#nullable disable

namespace GestionHotel.Data.Models
{
    public partial class TypesChambre
    {
        public TypesChambre()
        {
            Chambres = new HashSet<Chambre>();
        }

        public int IdTypeChambre { get; set; }
        public string LibelleTypeChambre { get; set; }
        public decimal? PrixChambre { get; set; }

        public virtual ICollection<Chambre> Chambres { get; set; }
    }
}
