using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelEntity;

namespace HotelData
{
    class logininfo : Ilogininfo
    {
        private HotelDBContext HDC;

        public logininfo(HotelDBContext h)
        {

            this.HDC = h;

        }

        public bool logincheck(Login l)
        {
            byte[] Enuname = new byte[l.username.Length];
            Enuname = System.Text.Encoding.UTF8.GetBytes(l.username);
            l.username = Convert.ToBase64String(Enuname);

            byte[] Epass = new byte[l.password.Length];
            Epass = System.Text.Encoding.UTF8.GetBytes(l.password);
            l.password = Convert.ToBase64String(Epass);

            Login log = HDC.Logins.SingleOrDefault(x=>x.username==l.username && x.password==l.password);

            if (log != null) {            
                return true; 
            }
            else { return false; }

        }


        public void create(Login l)
        {
            byte[] Enuname = new byte[l.username.Length];
            Enuname = System.Text.Encoding.UTF8.GetBytes(l.username);
            l.username = Convert.ToBase64String(Enuname);

            byte[] Epass = new byte[l.password.Length];
            Epass = System.Text.Encoding.UTF8.GetBytes(l.password);
            l.password = Convert.ToBase64String(Epass);

            HDC.Logins.Add(l);
            HDC.SaveChanges();
            return;
        }
    }
}
