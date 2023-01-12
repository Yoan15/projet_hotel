using System;
using System.Collections.Generic;

#nullable disable

namespace GestionHotel.Data.Models
{
    public partial class Etage
    {
        public Etage()
        {
            Chambres = new HashSet<Chambre>();
        }

        public int IdEtage { get; set; }
        public int? NumEtage { get; set; }

        public virtual ICollection<Chambre> Chambres { get; set; }
    }
}
