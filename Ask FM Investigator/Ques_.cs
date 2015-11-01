using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ask_FM_Investigator
{
    enum QuesType { _25, Mored }
    class Ques_
    {
        public string Quest = "";
        public string Answer = "";

        public Ques_(string Code="")
        {

            this.COde = Code;
        }
         
        public string AskingTime = "";
        public int Fans = 0;
         
        private static Ques_ CreateMore(string q, int i,bool Is25=true)
        {
            Ques_ obj = new Ques_();
            obj._25 = Is25;
            obj.AnalyzDirections( );
            obj.InDex = i;

            int DateIndex = 11;
            if (q.Length > 0)
            {
                if (q.Contains("\\"))
                {
                    string[] pcs = q.Split(new string[] { "/questions/", "/report", "\\\">\\n\\n    <div class=\\\"question", "id=\\\"question_box_", "\\\">\\n\\n    <div class=\\\"question\\\" dir=\\\"ltr\\\">", "<span class=\\\"text-bold\\\"><span dir=\\\"ltr\\\">", "</span></span>\\n    </div>", "<div class=\\\"answer\\\" dir=\\\"ltr\\\">", "</div>\\n\\n    <div class", "data-rlt-aid=\\\"answer_time\\\" hint=\\\"", "ago</a></div>", "div class=\\\"likeList people-like-block\\\"><a href", "likes this</div>" }, StringSplitOptions.RemoveEmptyEntries);
                    if (pcs.Length > 1)
                    {
                        obj.ID = long.Parse(pcs[1]);

                        if (obj.IsLeft_to_left())
                        {
                            obj.Quest = (pcs[3]);
                            obj.Answer = Ques_.GetAnswerM_LTR(pcs[9]).Trim();
                        }

                        else if (obj.ISLeft_to_right())
                        {
                            obj.Quest = (pcs[3]);
                            obj.Answer = Ques_.GetAnswerM_RTL(pcs[5]);
                        }

                        else if (obj.IsRight_to_Left())
                        {
                            obj.Quest = Ques_.GetQuestM_RTL(pcs[2]);
                            obj.Answer = Ques_.GetAnswerM_LTR(pcs[9]).Trim();

                        }

                        else if (obj.IsRight_to_Right())
                        {
                            obj.Quest = Ques_.GetQuestM_RTL(pcs[2]);
                            obj.Answer = Ques_.GetAnswerM_RTL(pcs[7]);
                            DateIndex = 9;


                        }
                        obj.AskingTime = pcs[DateIndex].Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)[0];
                        obj.Fans = Ques_.GetFans(q, false);
                     
                        obj.setAsker(Ques_.GetAsker(q, false));
                    }

                    /*/"\" id=\\\"question_box_123427359647\\\">\\n\\n   
                    <div class=\\\"question\\\" dir=\\\"rtl\\\">\\n      
                     * <span class=\\\"text-bold\\\"><span dir=\\\"rtl\\\">
                     *    \\u0625\\u0641\\u062a\\u062d \\u0627\\u0644\\u0631\\u0622\\u0628\\u0637\\u060c 
                     *    \\u0645\\u0647\\u0645\\u064f : [  
                     *    <a class=\\\"link-blue\\\" target=\\\"_blank\\\" rel=\\\"nofollow\\\" href=\\\"http://l.ask.fm/goto/50aiCb_tfaGMFH48iDvC_Y0ooQiD-umJvjzvofOy0CuNNxFsDJ0BLVa3_hYCQm4-WViAct81_FXWtpQnpRwaj2FTMGVyol3Ob3S0xfA,\\\">http://ask.fm/AbdulrahmanBedaiwi/answer/122031348826</a>
                     *    ]\\u060c \\u0648\\u0645\\u0648 \\u0644\\u0627\\u0632\\u0645 \\u064a\\u0646\\u0632\\u0644.
                     *    </span></span>\\u200f<span class=\\\"author nowrap\\\">&nbsp;&nbsp;<a href=\\\"/AbdulrahmanBedaiwi\\\" class=\\\"link-blue\\\" dir=\\\"rtl\\\">\\u00b1\\u062f.\\u0639\\u0628\\u062f\\u0651\\u0627\\u0644\\u0631\\u062d\\u0645\\u0651\\u0646 \\u2639\\u2716\\ue035.</a></span>\\n    </div>\\n\\n    \\n    \\n    <div class=\\\"reportFlagBox \\\">\\n  <a href=\\\"/a7medbenladen1/questions/123427359647/report_answer\\\" class=\\\"reportFlag hintable\\\" hint=\\\"Report\\\" onclick=\\\"RLTLogger.execute(&quot;CtxPointer&quot;, &quot;Complain.mark&quot;);$.colorbox({href:&quot;/a7medbenladen1/questions/123427359647/report_answer&quot;,title:&quot;Report&quot;}); return false\\\"></a>\\n</div>\\n\\n\\n    \\n    \\n\\n    <div class=\\\"answer\\\" dir=\\\"ltr\\\">\\n      <a class=\\\"link-blue\\\" target=\\\"_blank\\\" rel=\\\"nofollow\\\" href=\\\"http://l.ask.fm/goto/50aiCb_tfaGMFH48iDvo-po1rAyP_eyJvk26_M72lh7jOAxoHoovM1W2-BQGQGgzV1SF\\\">http://ask.fm/keshavmohan309</a> follow him and like his 50 answers nd in return he will give 100\\n    </div>\\n\\n    <div class=\\\"time\\\"><a href=\\\"/a7medbenladen1/answer/123427359647\\\" class=\\\"link-time hintable inverse\\\" data-rlt-aid=\\\"answer_time\\\" hint=\\\"December 31, 2014 17:23:16 GMT\\\">10 months ago</a></div>\\n\\n    <div class=\\\"likeCombo\\\" id=\\\"like_box_123427359647\\\">\\n  \\n    <div class=\\\"likeBox\\\">\\n      <div class=\\\" ghostLink\\\">\\n        <a href=\\\"/likes/a7medbenladen1/question/123427359647/mobile_prompt\\\" class=\\\"like hintable\\\" hint=\\\"Like\\\" onclick=\\\"$.colorbox({href:&quot;/likes/a7medbenladen1/question/123427359647/quick_prompt&quot;,title:&quot;create account or log in&quot;}); return false\\\"></a>\\n      </div>\\n    </div>\\n    <div class=\\\"likeList people-like-block\\\"><a class=\\\"link-blue\\\" href=\\\"/likes/a7medbenladen1/question/123427359647/people\\\" onclick=\\\"$.colorbox({title:&quot;People Who Like This&quot;,onComplete:Likes.onPeopleOpening,onCleanup:Likes.onPeopleClosing,href:&quot;/likes/a7medbenladen1/question/123427359647/people&quot;}); return false\\\">1 person</a> likes this</div>\\n    \\n</div>\\n\\n    \\n  </div>\\n\\n  \\n    \\n  \\n\\n\\n\");\n$(\"#questions_page\").val(2);\n$(\"#more-container\").hide();"
                */
                }
            }
            return obj;
        }

        private bool IsRight_to_Right()
        {
            return (this.Right_to_Left_QUEST && this.Right_to_Left_Answer);

        }

        private bool IsRight_to_Left()
        {
            return (this.Right_to_Left_QUEST && !this.Right_to_Left_Answer);

        }

        private bool ISLeft_to_right()
        {
            return (!this.Right_to_Left_QUEST && this.Right_to_Left_Answer);

        }

        private bool IsLeft_to_left()
        {
            
            return ( !this.Right_to_Left_QUEST&& !this.Right_to_Left_Answer);
        }

        private static int GetFans(string q, bool Is25)
        {
            if (Is25)
                return Ques_.GetFans25(q);
            else 
                return Ques_.GetFansM(q);
        }

        private static string GetAnswerM_LTR(string p)
        {
            if (p.Contains("\\n"))
            {
                string[] pcs = p.Split(new string[] { "\\n" }, StringSplitOptions.RemoveEmptyEntries);
                return pcs[0];
            }
            else return p;
        }

        private static bool isAnswer_RTL(string q)
        {
            foreach (string s in Ques_.Answer_RLanguage_Destingiusher)
                if (q.Contains(s))
                    return true;

            return false;
        }

        private static bool IsQuest_RTL(string p)
        {
            foreach (string s in Ques_.Quest_RLanguage_Destingiusher)
                if (p.Contains(s))
                    return true;

            return false;
        }
         

        private static string GetAnswerM_RTL(string p)
        {
            //"_answer&quot;,title:&quot;Report&quot;}); return false\\\"></a>\\n</div>\\n\\n\\n    \\n    \\n\\n    <div class=\\\"answer\\\" dir=\\\"rtl\\\">\\n      \\u0639\\u0640\\u0640\\u0631\\u0628\\u0648\\n    "
            string[] pcs = p.Split(new string[] { "dir=\\\"rtl\\\">\\n", "\\n" }, StringSplitOptions.RemoveEmptyEntries);
            
            try
            {
                p = pcs[5];
            }
            catch { p = pcs[1]; }
            return System.Text.RegularExpressions.Regex.Unescape(p);

        }
         

        private static string GetQuestM_RTL(string p)
        {
            string[] pcs = p.Split(new string[] { "<span dir=\\\"rtl\\\">" }, StringSplitOptions.RemoveEmptyEntries);
            return System.Text.RegularExpressions.Regex.Unescape(pcs[1]);
        }

        private static int GetFansM(string questBox)
        {
            int count = 0;
            try
            {
                string p = "";
                string[] pcs = questBox.Split(new string[] { "<div class=\"likeList people-like-block\">", "</div" }, StringSplitOptions.RemoveEmptyEntries);

                if (pcs.Length > 4)
                    p = pcs[4];

                 if (questBox.Contains("others</a> like this"))
                {
                    p = pcs[5];
                    string[] pos = p.Split(new string[] { "return false\\\">", "other" },StringSplitOptions.RemoveEmptyEntries);
                    count = int.Parse(pos[1]);

                    if (questBox.Contains("and"))
                        count++;
                 }
               
                 else      if (p.Contains("class=\"likeList people-like-block\"></div>"))
                    return 0;

                else  if (p.Contains("like this") || p.Contains("likes this"))
                    count = 1;

                else   if (p.Contains("and <a href=\\\"/"))
                    count = 2;

                
            }
            catch { count= 0; }
            return count;
        }

        private static long GetIdM(string s)
        {
            if (s.Length > 14)
                return long.Parse(s.Substring(14));
            else return 0;
        }
        public static Ques_ Create(string q, int i, bool ___25__=true)
        {

            Ques_ __obj = new Ques_(q);
            __obj.AnalyzDirections();
            __obj.InDex = i;
            __obj._25 = ___25__;
            string[] pieces = q.Split(new string[] { "<div" }, StringSplitOptions.RemoveEmptyEntries);

            __obj.ID = Ques_.GetId(pieces[0]);
            __obj.Quest = Ques_.GetQuest(pieces[1]).HTML_to_TEXT();
            __obj.Fans = Ques_.GetFans25(pieces[8]);

            if (pieces[1].Contains("span class=\"author nowrap\">"))
                __obj.setAsker(Ques_.GetAsker(q));

            __obj.AskingTime = Ques_.GetTime(pieces[4]);
            __obj.Answer = Ques_.GetAnswer(pieces[3]);

            __obj.Decode();
            return __obj;
        }

        private void Decode()
        {
            this.Answer = System.Text.RegularExpressions.Regex.Unescape(this.Answer);
            this.Quest = System.Text.RegularExpressions.Regex.Unescape(this.Quest);
            this.AskedBy.Name = System.Text.RegularExpressions.Regex.Unescape(this.AskedBy.Name);
        }

        public  void AnalyzDirections()
        { 
            this.Right_to_Left_QUEST= Ques_.IsQuest_RTL(this.COde);
            this.Right_to_Left_Answer = Ques_.isAnswer_RTL(this.COde);
        }

        private void setAsker(Asker p)
        {
            this.AskedBy = p;
        }

        private static Asker GetAsker(string p,bool is25=true)
        {
             Asker Result = new Asker("","");
             if (Ques_.IsAnonymousQues(p))
             {
                 string s1="", s2="", s3="", s4 = "";
                 string[] pcs = new string[] { };
                 if (is25)
                 {
                     s4 = "</a></span>";
                     s3 = "\" class=\"link-blue\" dir=\"rtl\">";
                     s2 = "\" class=\"link-blue\" dir=\"ltr\">";                     
                     s1="class=\"author nowrap\">&nbsp;&nbsp;<a href=\"/";
                 }
                 else
                 {    //class=\"author nowrap\">&nbsp;&nbsp;<a href=\"/MostafaEssam115\" class=\"link-blue\" dir=\"ltr\">Mostafa Essam</a></span>\n
                     s4 = "";
                     s3 = "\\\" class=\\\"link-blue\\\" dir=\\\"rtl\\\">";
                     s2 = "\\\" class=\\\"link-blue\\\" dir=\\\"ltr\\\">";
                     s1 = "class=\\\"author nowrap\\\">&nbsp;&nbsp;<a href=\\\"/";
                 }
                 pcs = p.Split(new string[] { s1, s2, s3, s4 }, StringSplitOptions.RemoveEmptyEntries);
                 return new Asker(pcs[2], pcs[1]);

             }
             return new Asker();
        }

        private static bool IsAnonymousQues(string p)
        {
            return ((p.Contains("class=\"author nowrap\">")) || p.Contains("class=\\\"author nowrap\\\">"));
        }

        private static int   GetFans25(string p)
        {

            /*
                  if (p.Trim() == "class=\"likeList people-like-block\"></div>\n    \n</div>\n\n    \n  </div>\n\n  \n    \n  \n\n\n\n  ".Trim())
                    return 0;
                else if (p.Contains("return false\">") && p.Contains("return false\">"))
                {

                    string[] pcs = p.Split(new string[] { "return false\">", "people" }, StringSplitOptions.RemoveEmptyEntries);
                    if (pcs.Length < 5)
                        return 0;

                    if (pcs[4].Contains("1 person"))
                        return 1;
                    else
                        if (pcs[4].isInt())
                            return int.Parse(pcs[4]);
                    return 0;
             */
            string ix ="0";
            try
            {
                int i = " class=\"likeList people-like-block\"><a class=\"link-blue\" href=\"/likes/askfm/question/131873930506/people\" onclick=\"$.colorbox({title:&quot;People Who Like This&quot;,onComplete:Likes.onPeopleOpening,onCleanup:Likes.onPeopleClosing,href:&quot;/likes/askfm/question/131873930506/people&quot;}); return false\">".Length;
                if (p.Length >= i)
                 {
                    string x = p.Substring(i);
                    if (x.Contains(" "))
                        ix= x.Split(new char[] { ' ' })[0];
                }
                return (int.Parse(ix)); 
            }
            catch { return 0; }
         }

        private static string GetAnswer(string p)
        {
            if (Ques_.IsSingleAnswer(p))
            {
                if (p.Contains("\n"))
                {
                    string[] x = p.Split(new char[] { '\n' });
                    return x[1];
                }
                else return p;
            }
            else if (p.Contains('\n'))
            {
                string[] byN = p.Split(new char[] { '\n' });
                return byN[1];
            }
            else
                return p;
        }

        private static bool IsSingleAnswer(string p)
        {
            return (p.Contains("<img") || p.Contains("<a"));

        }

        private static string GetTime(string p)
        {
            int i = " class=\"time\"><a href=\"/askfm/answer/> <class data-rlt-aid=\"answer_time\" hint=\"".Length;

            if (p.Length < i)
                return "";

            if (p.Contains("hint=\"") && p.Contains("\">"))
            {
                string[] pos = p.Split(new string[] { "hint=\"", "\">" }, StringSplitOptions.RemoveEmptyEntries);
                if (pos.Length > 2)
                    return pos[2];
                return p;
            }
            else
            {
                return p;
                //string pix = p.Substring(i);
                //if (pix.Contains("\"") == false)
                //    return "";
                //string[] pices = pix.Split(new char[] { '"' });
                //return pices[0];
            }
        }

        private static string GetQuest(string p)
        { 
            if (p.Length < 77)
                return p;

            if ((p.Contains("<span dir=\"ltr\">") || p.Contains("<span dir=\"rtl\">")) && p.Contains("</span>"))
            {
                string[] pcsx = p.Split(new string[] { "<span dir=\"rtl\">", "<span dir=\"ltr\">", "</span>" }, StringSplitOptions.RemoveEmptyEntries);

                return pcsx[1];
            }
            if (p.Contains("class=\"text-bold\"><span dir=\"ltr\""))
            {
                string[] pos = p.Split(new string[] { "class=\"text-bold\"><span dir=\"ltr\"" }, StringSplitOptions.RemoveEmptyEntries);
                p = pos[1];
            }
            else if (p.Length > 77)
                p = p.Substring(77);
            if (!p.Contains("<"))
                return p;

            string[] x = p.Split(new char[] { '<' });
            return x[0];

        }
        private static long GetId(string p,bool is25=true)
        {
            try
            {
                if (is25)
                {

                    string s = p.Substring(18).Trim();
                    string n = "";
                    foreach (char c in s)
                        if (c <= '9' && c >= '0')
                            n += c;

                    return long.Parse(n);
            
                }
                else
                {
                    string[] pcs = p.Split(new string[] { "box_", "\\" }, StringSplitOptions.RemoveEmptyEntries);
                    return long.Parse(pcs[1]);
                }
            }
            catch
            { return 0; }
        }
        private static string LinkedAnswer(string p)
        {
            return p;
        }
        public long ID = 0;








        public int InDex { get; set; }
         

        internal bool Contains(string p)
        {
            if (this == null)
                return false;
            string z = p.ToLower();
            if (this.Answer.ToLower().Contains(z))
                return true;
            if (this.AskedBy.Name.ToLower().Contains(z))
                return true;
            if (this.AskedBy.UserName.ToLower().Contains(z))
                return true;
            return false;
        }


        public string AnswerLink { get; set; }


        public string COde { get; set; }

        internal static string TrimeHTML(string p)
        {
            return p.Replace("\\\\", "\\").Replace("\\n", "");
        }

        public Asker AskedBy { get; set; }
        public static string[] Quest_RLanguage_Destingiusher = new string[] {  "<div class=\"question\" dir=\"rtl\">", "<div class=\\\"question\\\" dir=\\\"rtl\\\">" };
        public static string[] Answer_RLanguage_Destingiusher = new string[] {  "<div class=\"answer\" dir=\"rtl\">", "<div class=\\\"answer\\\" dir=\\\"rtl\\\">" };






        public bool Right_to_Left_QUEST { get; set; }

        public bool Right_to_Left_Answer { get; set; }

        public bool _25 { get; set; }
    }
    /*class Answer
    {
        private string Text = "";
        private string HTML = "";
        public bool Linked = false;
        public Answer(string s)
        {
            this.HTML = this.Text = s;

            if (s.Contains("<a class=\\\"link-blue\\\" target=\\\"_blank"))
            {
                if (this.Text.Contains("<"))
                {
                    string[] spd = s.Split(new char[] { '<' });
                    this.Text = spd[0];
                }

            }

        }
    }

     
     */
    enum CharDirection { Right_to_Right, Right_to_Left, Left_to_left, Left_to_right, Unkown }
}
