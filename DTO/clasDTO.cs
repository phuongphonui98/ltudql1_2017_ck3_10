using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  class clasDTO
    {
        public static List<clasDTO> lop = new List<clasDTO>();
        public static bool TonTail;
        private string MaL;
        private string TenL;
        private int SiSo;
        private string MaK;

        public clasDTO(string x, string y,int z,string o)
        {
            MaL = x;
            TenL = y;
            SiSo = z;
            MaK = o;
        }
        
        public int SiSo1 { get => SiSo; set => SiSo = value; }
    
        public string MaL1 { get => MaL; set => MaL = value; }
        public string TenL1 { get => TenL; set => TenL = value; }
        public string MaK1 { get => MaK; set => MaK = value; }
    }
}
