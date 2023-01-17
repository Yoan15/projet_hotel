using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.Data.Dtos
{
    class ChambreDTO
    {
        public int IdChambre { get; set; }
        public int NumChambre { get; set; }
        public int IdTypeChambre { get; set; }
        public int IdStatutChambre { get; set; }
        public int IdEtage { get; set; }

        public virtual EtageDTO EtageObj { get; set; }
        public virtual StatutsChambreDTO StatutChambreObj { get; set; }
        public virtual TypesChambreDTO TypeChambreObj { get; set; }
    }

    class ChambreDTOAvecNumEtage
    {
        public int NumChambre { get; set; }
        public int IdEtage { get; set; }
        public int NumEtage { get; set; }
    }
}
