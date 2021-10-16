using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelEntity;
using HotelData;

namespace HotelService
{
    class loginS : IloginS
    {
        private Ilogininfo ldata;

        public loginS(Ilogininfo ldata)
        {

            this.ldata = ldata;
        }


        public bool logincheck(Login l)
        {
            return ldata.logincheck(l);
        }


        public void create(Login l)
        {
            ldata.create(l);
            return;
        }
    }
}
