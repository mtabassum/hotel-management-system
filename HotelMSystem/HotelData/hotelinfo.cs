using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelEntity;

namespace HotelData
{
    class hotelinfo : Ihotelinfo
    {
        private HotelDBContext HDC;

        public hotelinfo (HotelDBContext h) {

            this.HDC = h;
        
        }

        public IEnumerable<Hotelinfo> Getall(string s)
        {
            
            int num;
            bool isnum = Int32.TryParse(s,out num);
            if (isnum)
            {
                int temp = Convert.ToInt32(s);
                return HDC.Hotelinfoes.Where(x => x.rating == temp).ToList();
                
            }
            else if(s==null){
                return HDC.Hotelinfoes.ToList();
            }
            else{
            return HDC.Hotelinfoes.Where(x => x.area.StartsWith(s) || x.area == s || x.hotelName.StartsWith(s) || x.hotelName == s).ToList();
            }
            
        }


        public void Create(Hotelinfo H)
        {
            HDC.Hotelinfoes.Add(H);
            HDC.SaveChanges();
            return;
        }


        public Hotelinfo Edit(int id)
        {
            return this.HDC.Hotelinfoes.Find(id);
        }


        public void EditConfirm(Hotelinfo H)
        {
            Hotelinfo Hupdate = HDC.Hotelinfoes.SingleOrDefault(x=>x.id==H.id);

            Hupdate.hotelName = H.hotelName; Hupdate.rating = H.rating; Hupdate.facilities = H.facilities;
            Hupdate.address = H.address; Hupdate.area = H.area; Hupdate.roomprice = H.roomprice;
            Hupdate.status = H.status; Hupdate.totalrooms = H.totalrooms;

            HDC.SaveChanges();
            return;
                
        }


        public Hotelinfo Detail(int id)
        {
            return HDC.Hotelinfoes.Find(id);
        }


        public Hotelinfo Delete(int id)
        {
            return HDC.Hotelinfoes.Find(id);
        }


        public void DeleteConfirm(Hotelinfo H)
        {
            Hotelinfo Hdelete = HDC.Hotelinfoes.SingleOrDefault(x=>x.id==H.id);

            HDC.Hotelinfoes.Remove(Hdelete);
            HDC.SaveChanges();
            return;
        }


        public bool check(Hotelinfo H)
        {
            Hotelinfo Hcheck = HDC.Hotelinfoes.SingleOrDefault(x => x.hotelName == H.hotelName);

            if (Hcheck != null) { return false; }
            else { return true; }
        }


        public Hotelinfo UpdateRoom(string hname)
        {

            return HDC.Hotelinfoes.SingleOrDefault(x=>x.hotelName==hname);
        }

        public void UpdateRoomConfirm(Hotelinfo H)
        {
            Hotelinfo Hupdate = HDC.Hotelinfoes.SingleOrDefault(x => x.hotelName == H.hotelName);

            Hupdate.hotelName = H.hotelName; Hupdate.rating = H.rating; Hupdate.facilities = H.facilities;
            Hupdate.address = H.address; Hupdate.area = H.area; Hupdate.roomprice = H.roomprice;
            Hupdate.status = H.status; Hupdate.totalrooms = H.totalrooms;

            HDC.SaveChanges();
            return;
        }
    }
}
