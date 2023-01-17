﻿using GestionHotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.Data.Dtos
{
    public class ChambreDTO
    {
        public int IdChambre { get; set; }
        public int? NumChambre { get; set; }
        public int IdTypeChambre { get; set; }
        public int IdStatutChambre { get; set; }
        public int IdEtage { get; set; }

        public virtual EtageDTO EtageObj { get; set; }
    }

    public class ChambreDTOStatut
    {
        public int? NumChambre { get; set; }

        public virtual StatutsChambre StatutChambre { get; set; }
    }
}