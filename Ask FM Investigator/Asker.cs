using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ask_FM_Investigator
{
    class Asker
    {
        public string Name = "Anonymous";
        public string UserName = "";



        public Asker(string p1 = "", string p2 = "")
        {

            this.Name = p1;
            this.UserName = p2;
        }

        public string Link()
        {
            return "http://ask.fm/" + UserName;
        }
    }
}
