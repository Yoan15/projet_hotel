using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.Data.Dtos
{
    class EtageDTO
    {
        public int? NumEtage { get; set; }
        public virtual ICollection<ChambreDTO> Chambres { get; set; }
    }

    class EtageDTONum
    {
        public int NumEtage { get; set; }
    }

    class EtageDTOIn
    {
        public int NumEtage { get; set; }
    }
}
