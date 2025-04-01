using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
    [Serializable]
    public class MyRequest
    {
        
        public string type { get; set; } // login-response
        public string message { get; set; }// ok \ no
        public string login { get; set; }
        public string password { get; set; }

        public string ChatId { get; set; }
    }
}
