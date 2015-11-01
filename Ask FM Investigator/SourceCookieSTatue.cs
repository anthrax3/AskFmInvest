using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ask_FM_Investigator
{
    class SourceCookieSTatue
    {
        public string Source = "";
        public string CookieString = "";
        public bool Statue = false;// p; 

        public SourceCookieSTatue()
        {

        }

        public SourceCookieSTatue(string b, bool p)
        {
            this.Statue = p;
            this.Source = b;
        }

        public SourceCookieSTatue(string x, string lst)
        {
            // TODO: Complete member initialization
            this.Source = x;
            this.CookieString = lst;
        }

        public SourceCookieSTatue(string source, string Cookie, bool statue)
        {
            // TODO: Complete member initialization
            this.Source = source;
            this.CookieString = Cookie;
            this.Statue = statue;
        }

    }
}
