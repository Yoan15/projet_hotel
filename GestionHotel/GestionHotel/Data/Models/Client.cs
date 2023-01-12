using System;
using System.Collections.Generic;

#nullable disable

namespace GestionHotel.Data.Models
{
    public partial class Client
    {
        public Client()
        {
            Reservationssejours = new HashSet<ReservationsSejour>();
        }

        public int IdClient { get; set; }
        public string NomClient { get; set; }
        public string PrenomClient { get; set; }
        public string MailClient { get; set; }
        public string TelClient { get; set; }

        public virtual Entreprise Entreprise { get; set; }
        public virtual Particulier Particulier { get; set; }
        public virtual ICollection<ReservationsSejour> Reservationssejours { get; set; }
    }
}
