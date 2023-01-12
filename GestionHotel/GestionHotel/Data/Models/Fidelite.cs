using System;
using System.Collections.Generic;

#nullable disable

namespace GestionHotel.Data.Models
{
    public partial class Fidelite
    {
        public Fidelite()
        {
            Particuliers = new HashSet<Particulier>();
        }

        public int IdFidelite { get; set; }
        public string LibelleFidelite { get; set; }
        public string DescriptionFidelite { get; set; }

        public virtual ICollection<Particulier> Particuliers { get; set; }
    }
}
