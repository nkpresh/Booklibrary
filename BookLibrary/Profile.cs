using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace PDF_Community
{
    class Profile
    {
        public string ProfileName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Image ProfilePicture { get; set; }
        public Profile(string ProfileName, string UserName, string Password,Image ProfilePicture)
        {
            this.ProfileName = ProfileName;
            this.UserName = UserName;
            this.Password = Password;
            this.ProfilePicture = ProfilePicture;
        }
        public Profile()
        {

        }
    }
}
