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
        public DataTable Get()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Hoc_sinh",cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        DataTable dt = new DataTable();

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
        public bool Update(HocSinhDTO hs)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Hoc_sinh", cn);
                DataRow r = dt.NewRow();
                r["Name"] = hs.Name;
                r["Address"] = hs.Diachi;
                r["Email"] = hs.Email;
                r["Date"] = hs.Ngsinh;
                r["Sex"] = hs.Gioitinh;
                dt.Rows.Add(r);
                SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                da.Update(dt);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
