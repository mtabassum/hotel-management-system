using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HotelEntity;

namespace HotelData
{
    class HotelDBContext : DbContext
    {
        public DbSet<Hotelinfo> Hotelinfoes { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
