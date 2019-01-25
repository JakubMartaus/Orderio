using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderio.Objects
{
    public class testik
    {
       private string user_id { get; set; }

        public string User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }
        public testik()
        {

        }
        public testik(string userID)
        {
            user_id = userID;
        }
    }
}
