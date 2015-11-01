using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Ask_FM_Investigator
{
    class MrHTTP
    {
        public static string Chrome_UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.71 Safari/537.36";
        public static string FireFox_UserAgent = "";
        public static SourceCookieSTatue LoadMore(string username, string time, int page, string auth_tok, string cok)
        {
            SourceCookieSTatue res = new SourceCookieSTatue();
            try
            { 
                string url = "http://ask.fm/" + username + "/more";
                var req = (HttpWebRequest)WebRequest.Create(url);
                req.UserAgent = MrHTTP.Chrome_UserAgent;
                req.Accept = "text/javascript, application/javascript, application/ecmascript, application/x-ecmascript, */*; q=0.01";
                req.Headers.Add("Accept-Language", "en-US,en;q=0.5");
                //req.Headers.Add("Accept-Encoding", "gzip, deflate");
                req.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                req.Headers.Add("X-Requested-With", "XMLHttpRequest");
                req.Referer = "http://ask.fm/" + username;
                req.Headers.Add("Pragma", "no-cache");
                req.Headers.Add("Cache-Control", "no-cache");
                req.Method = "POST";
                req.Headers.Add("cookie", cok);
//                req.Connection = "keep-alive";
                req.KeepAlive = true;
                req.Headers.Add("Cache-Control", "no-cache");
                var postData = "time="+time;
                postData   += "&page="+page.ToString()
                             +"&authenticity_token="+auth_tok;

                var data = Encoding.ASCII.GetBytes(postData);
                req.ContentLength = data.Length;

                using (var stream = req.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
   
                
                var resp = (HttpWebResponse)req.GetResponse();
                res.Source = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                res.CookieString=MrHTTP.GetCookieString(resp.Headers);
                res.Statue = true;
                return res;
            }
            catch(Exception ex)
            {
                return new SourceCookieSTatue(ex.Message, "", false);
            }
        }
        internal static SourceCookieSTatue LoadSource(string p)
        {

            SourceCookieSTatue __Result__ = new SourceCookieSTatue();
            try
            {
                var Request = (HttpWebRequest)WebRequest.Create(p.Trim());
                Request.UserAgent = MrHTTP.Chrome_UserAgent;
                Request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                Request.Headers.Add("Accept-Language", "en-US,en;q=0.5");
               // Request.Headers.Add("Accept-Encoding", "gzip, deflate");
                var response = (HttpWebResponse)Request.GetResponse();
                string x = new StreamReader(response.GetResponseStream()).ReadToEnd();
                string CokString = MrHTTP.GetCookieString(response.Headers);
                System.IO.File.WriteAllText("lastGet.txt", "Host" + Environment.NewLine + Request.RequestUri.ToString() + Environment.NewLine + x);
                return new SourceCookieSTatue(x, CokString);
                 
            }
            catch (Exception sa) { return new SourceCookieSTatue(sa.Message,false); }

        }

        private static string GetCookieString(WebHeaderCollection webHeaderCollection)
        {
            try
            {
                string CokString = "";
                for (int i = 0; i < webHeaderCollection.Count; i++)
                {
                    String header__ = webHeaderCollection.GetKey(i);
                    if (header__ != "Set-Cookie")
                        continue;
                    String[] values = webHeaderCollection.GetValues(header__);
                    if (values.Length < 1)
                        continue;
                    foreach (string v in values)
                        if (v != "")
                            CokString += MrHTTP.StripCokNameANdVal(v)+";";


                }
                if (CokString.Length > 0)
                    return CokString.Substring(0, CokString.Length - 1);

                return CokString;
            }
            catch { return ""; }

        }

        private static string StripCokNameANdVal(string v)
        {
            if (v.Contains(";"))
            {
                string [] sepdByColn = v.Split(new char [] {';'});
                return sepdByColn[0];
            }
            else
                return v;
        }
        internal static string URLEncode(string p)
        {
            var data = Encoding.ASCII.GetBytes(p);


            return System.Web.HttpUtility.UrlEncode(data, 0, data.Length);
        }
    }
}
