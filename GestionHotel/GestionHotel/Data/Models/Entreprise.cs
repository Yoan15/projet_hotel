using System;
using System.Collections.Generic;

#nullable disable

namespace GestionHotel.Data.Models
{
    public partial class Entreprise
    {
        public int IdClient { get; set; }
        public string NomEntreprise { get; set; }
        public string Siret { get; set; }
        public int? NumEntreprise { get; set; }
        public decimal? PourcentageReduction { get; set; }

        public virtual Client IdClientNavigation { get; set; }
    }
}
