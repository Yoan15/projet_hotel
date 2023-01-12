using System;
using System.Collections.Generic;

#nullable disable

namespace GestionHotel.Data.Models
{
    public partial class PossessionsEquipement
    {
        public int IdPossessionsEquipement { get; set; }
        public int? IdEquipementChambre { get; set; }
        public int? IdChambre { get; set; }

        public virtual Chambre IdChambreNavigation { get; set; }
        public virtual EquipementsChambre IdEquipementChambreNavigation { get; set; }
    }
}
