using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Information
    {
        private string username, password;
        private int type, id;

        public Information(string username, string password, int type, int id)
        {
            this.username = username;
            this.password = password;
            this.type = type;
            this.id = id;
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
    }
}
