using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelEntity;

namespace HotelData
{
    class bookinginfo : Ibookinginfo
    {
        private HotelDBContext HDC;

        public bookinginfo(HotelDBContext h)
        {

            this.HDC = h;
        
        }

        public void create(Booking B)
        {
            HDC.Bookings.Add(B);
            HDC.SaveChanges();
            return;
        }

        public IEnumerable<Booking> Allbooking(string hanme, string bDate)
        {
            if(hanme != null && bDate != null){

                if (hanme == "" && bDate == "")
                {
                    return HDC.Bookings.ToList();
                    
                }
                else if (hanme != "" && bDate == "")
                {
                    return HDC.Bookings.Where(x => x.hotelname == hanme).ToList();
                }
                else if (hanme == "" && bDate != "")
                {

                    return HDC.Bookings.Where(x => x.bookingdate == bDate).ToList();
                }
                else {
                    return HDC.Bookings.Where(x => x.hotelname == hanme && x.bookingdate == bDate).ToList();
                }
            }
            else{ 
                return HDC.Bookings.ToList();
            }
        }


        public Booking verify(int s)
        {
            return HDC.Bookings.SingleOrDefault(x=>x.code==s);
        }


        public Booking Bdetails(int bd)
        {
            return HDC.Bookings.Find(bd);
        }
    }
}
