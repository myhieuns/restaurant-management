using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kombo1.DTO
{
   public class CongThucInfo
    {
        public CongThucInfo(int id, int iDCongThuc, int iDObject, float hamLuong)
        {
            this.ID = id;
            this.IDCongThuc = iDCongThuc;
            this.IDObject = iDObject;
            this.HamLuong = hamLuong;
        }
        public CongThucInfo(DataRow row)
        {
            this.ID = (int)row["id"];
            this.IDCongThuc = (int)row["idcongthuc"];
            this.IDObject = (int)row["idobject"];
            this.HamLuong = (float)row["hamluong"];
        }
        private int iD;
        private int iDCongThuc;
        private int iDObject;
        private float hamLuong;

        public int ID { get => iD; set => iD = value; }
        public int IDCongThuc { get => iDCongThuc; set => iDCongThuc = value; }
        public int IDObject { get => iDObject; set => iDObject = value; }
        public float HamLuong { get => hamLuong; set => hamLuong = value; }
    }
    
}
