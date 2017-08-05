using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BumblebeeClient
{
    class HttpUtil
    {
        public static string SendPost(string url, Dictionary<string,string> param)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (string k in param.Keys)
                {
                    sb.Append(k);
                    sb.Append("=");
                    sb.Append(param[k]);
                    sb.Append("&");
                }

                var result = string.Empty;
                //注意提交的编码 这边是需要改变的 这边默认的是Default：系统当前编码
                byte[] postData = null;
                if (param.Count > 0)
                {
                    postData = Encoding.UTF8.GetBytes(sb.ToString().Substring(0, sb.Length - 1));
                }
                else 
                {
                    postData = Encoding.UTF8.GetBytes(sb.ToString());
                }

                // 设置提交的相关参数 
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                Encoding myEncoding = Encoding.UTF8;
                request.Method = "POST";
                request.KeepAlive = false;
                request.AllowAutoRedirect = true;
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727; .NET CLR  3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                request.ContentLength = postData.Length;

                // 提交请求数据 
                System.IO.Stream outputStream = request.GetRequestStream();
                outputStream.Write(postData, 0, postData.Length);
                outputStream.Close();

                HttpWebResponse response;
                Stream responseStream;
                StreamReader reader;
                string srcString;
                response = request.GetResponse() as HttpWebResponse;
                responseStream = response.GetResponseStream();
                reader = new System.IO.StreamReader(responseStream, Encoding.GetEncoding("UTF-8"));
                srcString = reader.ReadToEnd();
                result = srcString;   //返回值赋值
                reader.Close();

                return result;
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                return "";
            }
            
        }

        public static string SendGet(string Url, Dictionary<string,string> param)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (string k in param.Keys)
                {
                    sb.Append(k);
                    sb.Append("=");
                    sb.Append(param[k]);
                    sb.Append("&");
                }

                string getDataStr = string.Empty;
                if (param.Count > 0)
                {
                    getDataStr = sb.ToString().Substring(0, sb.Length - 1);
                }
                else
                {
                    getDataStr = sb.ToString();
                }

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url+"?"+ getDataStr);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();

                return retString;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }
        }         
    }
}
