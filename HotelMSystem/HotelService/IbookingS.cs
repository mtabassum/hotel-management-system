using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelEntity;

namespace HotelService
{
    public interface IbookingS
    {
        IEnumerable<Booking> Allbooking(string hanme, string bDate);
        void create(Booking B);
        Booking verify(int s);
        Booking Bdetails(int bd);
    }
}
