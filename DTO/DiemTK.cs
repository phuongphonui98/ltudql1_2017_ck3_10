using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DiemTK
    {
        public static List<DiemTK> DS = new List<DiemTK>();
        private int maHS;
       

        public DiemTK(int ma)
        {
            maHS = ma;
       
        }
        public int MaHS { get => maHS; set => maHS = value; }
       
    }
}
