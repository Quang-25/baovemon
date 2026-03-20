using DATA;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
    public class DoimatkhauBus
    {
        DoimatkhauDal dal = new DoimatkhauDal();
        public bool checkmatkhau(DoimatkhauDTO nv) 
        {
            return dal.checkmatkhau(nv);
        }
        public bool Doimatkhau(DoimatkhauDTO nhanvien)
        {
            if (!dal.checkmatkhau(nhanvien))
                return false;

            return dal.Doimatkhau(nhanvien);
        }
    }
}
