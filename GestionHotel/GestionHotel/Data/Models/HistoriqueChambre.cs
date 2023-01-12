using System;
using System.Collections.Generic;

#nullable disable

namespace GestionHotel.Data.Models
{
    public partial class HistoriqueChambre
    {
        public int IdHistoriqueChambre { get; set; }
        public int? IdChambre { get; set; }
        public int? IdReservationSejour { get; set; }

        public virtual Chambre IdChambreNavigation { get; set; }
        public virtual ReservationsSejour IdReservationSejourNavigation { get; set; }
    }
}
