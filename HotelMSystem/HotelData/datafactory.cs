using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelData
{
    public abstract class datafactory
    {
        public static Ihotelinfo gethoteldata() 
        {
            return new hotelinfo(new HotelDBContext());
        }
        public static Ilogininfo getlogindata()
        {
            return new logininfo(new HotelDBContext());
        }
        public static Ibookinginfo getbookingdata()
        {

            return new bookinginfo(new HotelDBContext());
        }
    }
}
