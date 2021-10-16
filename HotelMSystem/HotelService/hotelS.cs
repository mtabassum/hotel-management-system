using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelEntity;
using HotelData;

namespace HotelService
{
    class hotelS : IhotelS
    {
        private Ihotelinfo hdata;

        public hotelS(Ihotelinfo hdata)
        {

            this.hdata = hdata;
        }

        public IEnumerable<Hotelinfo> Getall(string s)
        {
            return hdata.Getall(s);
        }


        public void create(Hotelinfo H)
        {
            hdata.Create(H);
            return;
        }


        public Hotelinfo Edit(int id)
        {
            return this.hdata.Edit(id);
        }


        public void EditConfirm(Hotelinfo H)
        {
            hdata.EditConfirm(H);
            return;
        }

        public Hotelinfo Detail(int id)
        {
            return hdata.Detail(id);
        }


        public Hotelinfo Delete(int id)
        {
            return hdata.Delete(id);
        }


        public void DeleteConfirm(Hotelinfo H)
        {
            hdata.DeleteConfirm(H);
            return;
        }


        public bool check(Hotelinfo H)
        {
            return hdata.check(H);
        }


        public Hotelinfo UpdateRoom(string hname)
        {
            return hdata.UpdateRoom(hname);
        }

        public void UpdateRoomConfirm(Hotelinfo H)
        {
            hdata.UpdateRoomConfirm(H);
            return;
        }
    }
}
