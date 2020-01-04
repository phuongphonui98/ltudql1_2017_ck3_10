using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UsserrDTO
    {
        public static List<UsserrDTO> lstU = new List<UsserrDTO>();
        public static UsserrDTO u = new UsserrDTO(0, "", "", 0);
        private int id;
        private string username;
        private string pass;
        private int per;

        public UsserrDTO()
        {

        }
        public UsserrDTO(int ID, string name, string pas, int permiss)
        {
            id = ID;
            username = name;
            pass = pas;
            per = permiss;
        }
        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Pass { get => pass; set => pass = value; }
        public int Per { get => per; set => per = value; }
    }
}
