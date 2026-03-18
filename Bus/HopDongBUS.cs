using DATA;
using DTO;
using System.Data;

namespace BUS
{
    public class HopDongBUS
    {
        HopDongDATA data = new HopDongDATA();

        public DataTable GetHopDong()
        {
            return data.GetHopDong();
        }

        public void Insert(HopDongDTO hd)
        {
            data.Insert(hd);
        }

        public void Update(HopDongDTO hd)
        {
            data.Update(hd);
        }

        public void Delete(int id)
        {
            data.Delete(id);
        }

        public DataTable Search(string so)
        {
            return data.Search(so);
        }
    }
}