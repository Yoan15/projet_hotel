using System;
using System.Collections.Generic;

#nullable disable

namespace GestionHotel.Data.Models
{
    public partial class HistoriquesNettoyage
    {
        public int IdHistoriquesNettoyage { get; set; }
        public int? IdEmploye { get; set; }
        public int? IdChambre { get; set; }
        public DateTime? DateHeureNettoyage { get; set; }

        public virtual Chambre IdChambreNavigation { get; set; }
        public virtual Employe IdEmployeNavigation { get; set; }
    }
}
