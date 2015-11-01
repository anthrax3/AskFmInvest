using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ask_FM_Investigator
{
    class DrJersy
    {
        internal static string GetQuest(Ques_ q) 
        { 

                string[] pcs = q.COde.Split(new string[] { "<span dir=\"rtl\">", "<span dir=\"ltr\">","</span>" }, StringSplitOptions.RemoveEmptyEntries);
                return pcs[1];
 
        }
    }
}
