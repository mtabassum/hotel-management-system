using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelEntity;
using HotelData;

namespace HotelService
{
    class bookingS : IbookingS
    {
        private Ibookinginfo bdata;

        public bookingS(Ibookinginfo bdata) {

            this.bdata = bdata;
        }

        public void create(Booking B)
        {
            bdata.create(B);
        }

        public IEnumerable<Booking> Allbooking(string hanme, string bDate)
        {
            return bdata.Allbooking(hanme,bDate);
        }


        public Booking verify(int s)
        {
            return bdata.verify(s);
        }


        public Booking Bdetails(int bd)
        {
            return bdata.Bdetails(bd);
        }
    }
}
