using System;
using System.Collections.Generic;

#nullable disable

namespace GestionHotel.Data.Models
{
    public partial class Employe
    {
        public Employe()
        {
            Historiqueactionsreservations = new HashSet<HistoriqueActionsReservation>();
            Historiquesnettoyages = new HashSet<HistoriquesNettoyage>();
        }

        public int IdEmploye { get; set; }
        public string NomEmploye { get; set; }
        public string PrenomEmploye { get; set; }
        public string Identifiant { get; set; }
        public string Mdp { get; set; }
        public int IdTypeEmploye { get; set; }

        public virtual TypesEmploye TypeEmploye { get; set; }
        public virtual ICollection<HistoriqueActionsReservation> Historiqueactionsreservations { get; set; }
        public virtual ICollection<HistoriquesNettoyage> Historiquesnettoyages { get; set; }
    }
}
