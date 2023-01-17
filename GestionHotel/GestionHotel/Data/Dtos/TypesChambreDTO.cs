using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.Data.Dtos
{
    public class TypesChambreDTO
    {
        public int IdTypeChambre { get; set; }
        public string LibelleTypeChambre { get; set; }
        public decimal? PrixChambre { get; set; }
    }

}
