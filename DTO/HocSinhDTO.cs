using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HocSinhDTO
    {
        public static int id;
        public static List<HocSinhDTO> lisths = new List<HocSinhDTO>();
        #region Atrributes
        public static int toithieu;
        public static int toida;
        private String _name;
        private bool _gioitinh;
        
        private DateTime _ngsinh;
        private String _diachi;
        private String _email;
        private String clas;
        private float HK1;
        private float HK2;
  
        #endregion
        #region Default Constructor
        public HocSinhDTO( string name, string mail,string dc,bool gt ,DateTime date)
        {
            
            _name = name;
            _email = mail;
            _gioitinh = gt;
            _diachi =dc ;
            _ngsinh = date;
            
        }
        public HocSinhDTO(string name, string mail, string dc, bool gt, DateTime date, string lop,float tb1, float tb2)
        {

            _name = name;
            _email = mail;
            _gioitinh = gt;
            _diachi = dc;
            _ngsinh = date;
            clas = lop;
            HK1 = tb1;
            HK2 = tb2;

        }

        public string Name { get => _name; set => _name = value; }
        
     
        public string Diachi { get => _diachi; set => _diachi = value; }
        public string Email { get => _email; set => _email = value; }
        public DateTime Ngsinh { get => _ngsinh; set => _ngsinh = value; }
        public bool Gioitinh { get => _gioitinh; set => _gioitinh = value; }
        public string Clas { get => clas; set => clas = value; }
        public float HK11 { get => HK1; set => HK1 = value; }
        public float HK21 { get => HK2; set => HK2 = value; }
        #endregion
        #region Properties

        #endregion
    }
}
