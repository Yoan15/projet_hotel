using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHotel.Data
{
    class HotelContext: DbContext
    {
        public HotelContext()
        {

        }

        public HotelContext(DbContextOptions<HotelContext> options): base(options)
        {

        }
    }
}
