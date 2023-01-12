using System;
using System.Collections.Generic;

#nullable disable

namespace GestionHotel.Data.Models
{
    public partial class Facturation
    {
        public int IdFacturation { get; set; }
        public int? IdPrestation { get; set; }
        public int? IdReservationSejour { get; set; }
        public int? IdTypePaiement { get; set; }
        public string NumFacture { get; set; }
        public int? QuantitePrestation { get; set; }
        public DateTime? DatePrestation { get; set; }

        public virtual Prestation IdPrestationNavigation { get; set; }
        public virtual ReservationsSejour IdReservationSejourNavigation { get; set; }
        public virtual TypesPaiement IdTypePaiementNavigation { get; set; }
    }
}
