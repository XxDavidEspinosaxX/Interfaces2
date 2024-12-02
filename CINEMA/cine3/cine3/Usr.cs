using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine3
{
    public class Usr : IDataErrorInfo
    { 
        public string Email { get; set; }
        public string Password { get; set; }

        public string Error
        {
            get
            {
                return "";
            }
        }
        public string this[string columnName]
        {
            get
            {
                string resultErrors = "";

                if (columnName == "Email")
                {
                    if (string.IsNullOrEmpty(Email))
                    {
                        resultErrors = "El camp correu electonic no pot estar buit";
                    }
                }

                if (columnName == "Password")
                {
                    if (string.IsNullOrEmpty(Password))
                    {
                        resultErrors = "El camp contrasenya no pot estar buit";
                    }
                }

                return resultErrors;
            }
        }

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
