using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace PDF_Community
{
    class Library
    {
        public List<Profile> ListOfAccount;
        public Library()
        {
            ListOfAccount = new List<Profile>();
        }
    }
}
