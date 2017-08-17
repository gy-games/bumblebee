using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BumblebeeClient
{
    class SecurityUtil
    {

        public static string GetTimestamp() 
        {
            TimeSpan ts2 = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts2.TotalSeconds).ToString();
        }

        public static string CreateSign(Dictionary<string, string> param, string signkey="")
        {
            signkey = signkey.ToUpper();
            if (param == null || param.Count == 0)
            {
                return null;
            }
            StringBuilder sb = new StringBuilder();
            Dictionary<string, string> order = param.OrderBy(i => i.Key).ToDictionary(i=>i.Key,i=>i.Value);
            foreach(string k in order.Keys)
            {
                sb.Append(k);
                sb.Append("=");
                sb.Append(order[k]);
                sb.Append("&");
            }
            if (order.Count > 0) 
            {
                Console.Write(sb.ToString() + signkey);
                return CreateMD5Hash(sb.ToString().Substring(0, sb.Length - 1) + signkey);
            }
            //return sb.ToString() + signkey;
            //Console.Write(sb.ToString() + signkey);
            return CreateMD5Hash(sb.ToString()+ signkey);
        }

        public static string CreateMD5Hash(string input)
        {
            MD5CryptoServiceProvider MD5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] b = MD5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
            System.Text.StringBuilder StrB = new System.Text.StringBuilder();
            for (int i = 0; i < b.Length; i++)
            {
                StrB.Append(b[i].ToString("x").PadLeft(2, '0'));
            }
            return StrB.ToString();
        }
    }
}
