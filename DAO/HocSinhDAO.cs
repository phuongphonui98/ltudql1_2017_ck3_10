using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
   public  class HocSinhDAO : DBConnect
    {

        public void GetHSL(string MLop)
        {
            HocSinhDTO.lisths.Clear();
            HocSinhDBDataContext hdb = new HocSinhDBDataContext();
            var list = hdb.TracuuhocsinhLop(MLop);

            foreach (var x in list)
            {

                DateTime oDate = Convert.ToDateTime(x.Date);
                bool kt;
                if (bool.Parse(x.Sex) == true)
                {
                    kt = true;
                }
                else { kt = false; }
                string tb1 = x.TBHocKi1.ToString();
                string tb2 = x.TBHocKi2.ToString();
                HocSinhDTO hs = new HocSinhDTO(x.Name, x.Email, x.Address, kt, oDate, x.TenLop, float.Parse(tb1), float.Parse(tb2));
                HocSinhDTO.lisths.Add(hs);
            }
        }
        public void GetHSK(string MK)
        {
            HocSinhDTO.lisths.Clear();
            HocSinhDBDataContext hdb = new HocSinhDBDataContext();
            var list = hdb.TracuuhocsinhKL(MK);

            foreach (var x in list)
            {

                DateTime oDate = Convert.ToDateTime(x.Date);
                bool kt;
                if (bool.Parse(x.Sex) == true)
                {
                    kt = true;
                }
                else { kt = false; }
                string tb1 = x.TBHocKi1.ToString();
                string tb2 = x.TBHocKi2.ToString();
                HocSinhDTO hs = new HocSinhDTO(x.Name, x.Email, x.Address, kt, oDate,x.TenLop,float.Parse(tb1),float.Parse(tb2));
                HocSinhDTO.lisths.Add(hs);
            }
        }
        public void Get()
        {
            HocSinhDBDataContext hdb = new HocSinhDBDataContext();
            try
            {
                HocSinhDTO.lisths.Clear();
              
                var q0 = from s0 in hdb.Hoc_sinhs select s0;
                
                foreach (var x in q0)
                {
                    
                    DateTime oDate = Convert.ToDateTime(x.Date);
                    bool kt;
                    if(bool.Parse(x.Sex) == true)
                    {
                        kt = true;
                    }
                    else { kt = false; }
                    
                    HocSinhDTO hs = new HocSinhDTO(x.Name,x.Email,x.Address,kt,oDate);
                    HocSinhDTO.lisths.Add(hs);
                }
                var q = from s in hdb.THAMSOs select s.TuoiToiThieu;
                var kq = q.FirstOrDefault();
                HocSinhDTO.toithieu = int.Parse(kq.ToString());
                var q2 = from s in hdb.THAMSOs select s.TuoiToiDa;
                var kq2 = q2.FirstOrDefault();
                HocSinhDTO.toida = int.Parse(kq2.ToString());
                ChiTietClass.ctclas.Clear();
                var ct = from st in hdb.CHITIETDSLOPs select st;

                foreach (var x in ct)
                {
                    string tb1 = x.TBHocKi1.ToString();
                    string tb2 = x.TBHocKi2.ToString();
                    ChiTietClass hsct = new ChiTietClass(x.MaChiTietDSLop, x.MaLop, x.MaHocSinh, float.Parse(tb1), float.Parse(tb2));
                    ChiTietClass.ctclas.Add(hsct);
                }
            

            }
            catch
            {
              
            }
        }
        public void GetKL()
        {
            HocSinhDBDataContext hdb = new HocSinhDBDataContext();
            try
            {
                ClassDTO.khoilop.Clear();
                clasDTO.lop.Clear();
                var kk = from l in hdb.DANHSACHLOPs select l;
                var q = from kq in hdb.KHOILOPs select kq;
                if(q == null || kk ==null)
                {
                    clasDTO.TonTail = false;
                    ClassDTO.TonTai = false;
                }
                else {
                    ClassDTO.TonTai = true;
                    clasDTO.TonTail = true;
                    foreach (var x in q)
                    {
                        ClassDTO kl = new ClassDTO(x.MaKhoiLop, x.TenKhoiLop);
                        ClassDTO.khoilop.Add(kl) ;
                    }
                    foreach (var n in kk)
                    {
                        clasDTO lop = new clasDTO(n.MaLop, n.TenLop, 0, n.MaKhoiLop);
                        clasDTO.lop.Add(lop);
                    }
                }
               
                
            }
            catch
            {

            }
        }
        DataTable dt = new DataTable();

        public bool GetMaHS(string email)
        {
            HocSinhDBDataContext hdb = new HocSinhDBDataContext();
            var kq = from s in hdb.Hoc_sinhs select s;
            foreach(var hs in kq.ToList())
            {
                if(email == hs.Email)
                {
                    HocSinhDTO.id = hs.ID;
                    return true;
                }

            }
            return false;
        }
      
        public bool Insert(HocSinhDTO hs)
        {
            try
            {
                
                HocSinhDBDataContext hdb = new HocSinhDBDataContext();
                
                Hoc_sinh hs2 = new Hoc_sinh { Name = hs.Name, Address = hs.Diachi, Email = hs.Email, Date = (hs.Ngsinh).ToString(), Sex = hs.Gioitinh.ToString() };
                
                hdb.Hoc_sinhs.InsertOnSubmit(hs2);
                hdb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool InsertKL(ClassDTO kl)
        {
            try
            {

                HocSinhDBDataContext hdb = new HocSinhDBDataContext();
                KHOILOP KL = new KHOILOP { MaKhoiLop = kl.MaK1, TenKhoiLop = kl.TenK1 };

                hdb.KHOILOPs.InsertOnSubmit(KL);
                hdb.SubmitChanges();
                
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool InsertL(clasDTO l)
        {
            try
            {

                HocSinhDBDataContext hdb = new HocSinhDBDataContext();
                DANHSACHLOP L = new DANHSACHLOP { MaLop=l.MaL1,TenLop=l.TenL1,SiSo=l.SiSo1,MaKhoiLop=l.MaK1 };

                hdb.DANHSACHLOPs.InsertOnSubmit(L);
                hdb.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool InsertHStoClass(ChiTietClass CT)
        {
            try
            {

                HocSinhDBDataContext hdb = new HocSinhDBDataContext();
                CHITIETDSLOP L = new CHITIETDSLOP { MaChiTietDSLop= CT.MaCT1,MaLop=CT.MaL1,MaHocSinh=CT.MaHS1,TBHocKi1=CT.TB11,TBHocKi2=CT.TB21 };

                hdb.CHITIETDSLOPs.InsertOnSubmit(L);
                hdb.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(string Mhs)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Hoc_sinh", cn);
                DataRow r = dt.Rows.Find(Mhs);
               
                if(r != null)
                {
                    r.Delete();
                }
                SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                da.Update(dt);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateHS(HocSinhDTO hs,int id)
        {
            try
            {
                HocSinhDBDataContext hdb = new HocSinhDBDataContext();
                hdb.updateHS(hs.Clas, id, hs.Name, hs.Diachi, hs.Email, hs.Ngsinh.ToString(), hs.Gioitinh.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
