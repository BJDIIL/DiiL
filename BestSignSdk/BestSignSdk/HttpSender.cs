using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace DiiL.Sdk.BestSignSdk
{
    class HttpSender
    {
        public class HttpSendUtil
        {
            public static ArrayList PostData(string postData, string postUrl, Dictionary<string, string> heards)
            {
                ArrayList list = new ArrayList();
                HttpWebRequest request;
                HttpWebResponse response;
                request = WebRequest.Create(postUrl) as HttpWebRequest;
                ASCIIEncoding encoding = new ASCIIEncoding();
                var b = Encoding.GetEncoding("UTF-8").GetBytes(postData);
                request.UserAgent = "Mozilla/4.0";
                request.Method = "POST";
                request.ContentType = "application/json;charset=UTF-8";
                request.ContentLength = b.Length;
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(b, 0, b.Length);
                }
                try
                {
                    //获取服务器返回的资源  
                    using (response = request.GetResponse() as HttpWebResponse)
                    {
                        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")))
                        {
                            list.Add(reader.ReadToEnd());
                        }
                    }
                }
                catch (WebException wex)
                {
                    WebResponse wr = wex.Response;
                    using (Stream st = wr.GetResponseStream())
                    {
                        using (StreamReader sr = new StreamReader(st, System.Text.Encoding.Default))
                        {
                            list.Add(sr.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    list.Add("发生异常/n/r" + ex.Message);
                }
                return list;
            }

            public static ArrayList SteamPostData(byte[] bt, string postUrl, string urlsign, Dictionary<string, string> heards)
            {
                ArrayList list = new ArrayList();
                HttpWebRequest request;
                HttpWebResponse response;
                request = WebRequest.Create(postUrl) as HttpWebRequest;
                ASCIIEncoding encoding = new ASCIIEncoding();

                var b = bt;
                request.UserAgent = "Mozilla/4.0";
                request.Method = "POST";
                request.ContentType = "application/octet-stream";
                request.ContentLength = b.Length;
                if (heards != null)
                {
                    foreach (var item in heards)
                    {
                        request.Headers.Add(item.Key, item.Value);

                    }
                }
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(b, 0, b.Length);
                }
                try
                {
                    //获取服务器返回的资源  
                    using (response = request.GetResponse() as HttpWebResponse)
                    {
                        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")))
                        {
                            list.Add(reader.ReadToEnd());
                        }
                    }
                }
                catch (WebException wex)
                {
                    WebResponse wr = wex.Response;
                    using (Stream st = wr.GetResponseStream())
                    {
                        using (StreamReader sr = new StreamReader(st, System.Text.Encoding.Default))
                        {
                            list.Add(sr.ReadToEnd());
                        }
                    }
                }
                catch (Exception ex)
                {
                    list.Add("发生异常/n/r" + ex.Message);
                }
                return list;
            }
        }
    }
}
