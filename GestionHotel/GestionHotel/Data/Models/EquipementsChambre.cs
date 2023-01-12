using System;
using System.Collections.Generic;

#nullable disable

namespace GestionHotel.Data.Models
{
    public partial class EquipementsChambre
    {
        public EquipementsChambre()
        {
            Possessionsequipements = new HashSet<PossessionsEquipement>();
        }

        public int IdEquipementChambre { get; set; }
        public string LibelleEquipementChambre { get; set; }
        public string DescriptionEquipementChambre { get; set; }

        public virtual ICollection<PossessionsEquipement> Possessionsequipements { get; set; }
    }
}
