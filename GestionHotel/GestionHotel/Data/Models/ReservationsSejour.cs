using System;
using System.Collections.Generic;

#nullable disable

namespace GestionHotel.Data.Models
{
    public partial class ReservationsSejour
    {
        public ReservationsSejour()
        {
            Facturations = new HashSet<Facturation>();
            Historiqueactionsreservations = new HashSet<HistoriqueActionsReservation>();
            Historiquechambres = new HashSet<HistoriqueChambre>();
        }

        public int IdReservationSejour { get; set; }
        public int? NumReservationSejour { get; set; }
        public DateTime? DateDebutReservationSejour { get; set; }
        public TimeSpan? HeureArriveePrevue { get; set; }
        public DateTime? DateFinReservationSejour { get; set; }
        public int? NbPersonnes { get; set; }
        public int? NbChambres { get; set; }
        public int IdClient { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual ICollection<Facturation> Facturations { get; set; }
        public virtual ICollection<HistoriqueActionsReservation> Historiqueactionsreservations { get; set; }
        public virtual ICollection<HistoriqueChambre> Historiquechambres { get; set; }
    }
}
