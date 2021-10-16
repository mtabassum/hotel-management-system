using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelEntity;

namespace HotelData
{
    public interface Ihotelinfo
    {
        IEnumerable<Hotelinfo> Getall(string s);
        void Create(Hotelinfo H);
        Hotelinfo Edit(int id);
        void EditConfirm(Hotelinfo H);
        Hotelinfo Detail(int id);
        Hotelinfo Delete(int id);
        void DeleteConfirm(Hotelinfo H);
        bool check(Hotelinfo H);
        Hotelinfo UpdateRoom(string hname);
        void UpdateRoomConfirm(Hotelinfo H);
    }
}
