using System;
using System.Collections.Generic;

#nullable disable

namespace GestionHotel.Data.Models
{
    public partial class HistoriqueActionsReservation
    {
        public int IdHistoriqueActionsReservation { get; set; }
        public int? IdEmploye { get; set; }
        public int? IdReservationSejour { get; set; }
        public DateTime? DateHeureAction { get; set; }

        public virtual Employe IdEmployeNavigation { get; set; }
        public virtual ReservationsSejour IdReservationSejourNavigation { get; set; }
    }
}
