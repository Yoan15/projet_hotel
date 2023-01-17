using System;
using System.Collections.Generic;

#nullable disable

namespace GestionHotel.Data.Models
{
    public partial class Chambre
    {
        public Chambre()
        {
            Historiquechambres = new HashSet<HistoriqueChambre>();
            Historiquesnettoyages = new HashSet<HistoriquesNettoyage>();
            Possessionsequipements = new HashSet<PossessionsEquipement>();
        }

        public int IdChambre { get; set; }
        public int? NumChambre { get; set; }
        public int IdTypeChambre { get; set; }
        public int IdStatutChambre { get; set; }
        public int IdEtage { get; set; }

        public virtual Etage EtageObj { get; set; }
        public virtual StatutsChambre StatutChambre { get; set; }
        public virtual TypesChambre IdTypeChambreNavigation { get; set; }
        public virtual ICollection<HistoriqueChambre> Historiquechambres { get; set; }
        public virtual ICollection<HistoriquesNettoyage> Historiquesnettoyages { get; set; }
        public virtual ICollection<PossessionsEquipement> Possessionsequipements { get; set; }
    }
}
