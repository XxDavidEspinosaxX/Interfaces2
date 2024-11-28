using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine3
{
    public class Usr
    { 
        public string Email { get; set; }
        public string Password { get; set; }
        public Usr(string email_intro, string passw_intro)
        {
            this.Email = email_intro; this.Password = passw_intro; 
        }
        public Usr() 
        {
            this.Email = "";
            this.Password = "";
        }
    }
}
