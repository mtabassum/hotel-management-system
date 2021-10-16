using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelData;

namespace HotelService
{
        public abstract class servicefactory
        {
            public static IhotelS gethotelService()
            {
                return new hotelS(datafactory.gethoteldata());
            }
            public static IloginS getloginService()
            {

                return new loginS(datafactory.getlogindata());
            }
            public static IbookingS getbookingService()
            {

                return new bookingS(datafactory.getbookingdata());
            }
        }
    
}
