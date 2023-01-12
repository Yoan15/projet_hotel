using System;
using System.Collections.Generic;

#nullable disable

namespace GestionHotel.Data.Models
{
    public partial class StatutsChambre
    {
        public StatutsChambre()
        {
            Chambres = new HashSet<Chambre>();
        }

        public int IdStatutChambre { get; set; }
        public string LibelleStatutChambre { get; set; }

        public virtual ICollection<Chambre> Chambres { get; set; }
    }
}
