using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelEntity;

namespace HotelService
{
    public interface IloginS
    {
        bool logincheck(Login l);
        void create(Login l);
    }
}
