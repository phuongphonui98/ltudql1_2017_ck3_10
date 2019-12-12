using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HocKi
    {
        public List<HocKi> HK = new List<HocKi>();   
        private int MaHK;
        private string TenHK;

        public int MaHK1 { get => MaHK; set => MaHK = value; }
        public string TenHK1 { get => TenHK; set => TenHK = value; }
    }
}
