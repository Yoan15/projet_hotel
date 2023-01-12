using System;
using System.Collections.Generic;

#nullable disable

namespace GestionHotel.Data.Models
{
    public partial class Particulier
    {
        public int IdClient { get; set; }
        public int? NumParticulier { get; set; }
        public int IdFidelite { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual Fidelite IdFideliteNavigation { get; set; }
    }
}
