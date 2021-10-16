using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelEntity;

namespace HotelData
{
    public interface Ilogininfo
    {
        bool logincheck(Login l);
        void create(Login l);
    }
}
