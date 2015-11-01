using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ask_FM_Investigator
{
    class StringBool
    {
        public bool HasError { get; set; }

        public string Text { get; set; }
        public StringBool()
        {
            HasError = true;
        }
    }
}
