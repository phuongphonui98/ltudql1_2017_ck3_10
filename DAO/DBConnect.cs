using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace DAO
{
    public class DBConnect
    {
      protected  SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-L34EHS5\SQLEXPRESS;Initial Catalog=QLHS;Integrated Security=True");

    }
}
