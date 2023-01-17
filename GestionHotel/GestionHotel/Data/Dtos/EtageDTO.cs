using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.Data.Dtos
{
    public class EtageDTO
    {
        public int IdEtage { get; set; }
        public int? NumEtage { get; set; }
        public virtual ICollection<ChambreDTO> Chambres { get; set; }
    }

    public class EtageDTONum
    {
        public int NumEtage { get; set; }
    }
}
