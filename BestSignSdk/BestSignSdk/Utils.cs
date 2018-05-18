using System;
using System.Text;
using System.Web;

namespace DiiL.Sdk.BestSignSdk
{
    public class Utils 
    {
        /**
         * 转换字符集到utf8
         */
    public static string convertToUtf8(string src) 
    {
        if (src == null || src.Length == 0) 
        {
            return src;
        }
        byte[] srcData = Encoding.UTF8.GetBytes(src);
        return Encoding.UTF8.GetString(srcData);
    }

    /**
     * 从utf8转换字符集
     */
    public static string convertFromUtf8(string src) 
    {
        if (src == null || src.Length == 0) 
        {
            return src;
        }
        byte[] srcData = new byte[0];
        try 
        {
            srcData = Encoding.UTF8.GetBytes (src);
        }
        catch (Exception ex) 
        {
            throw ex;
        }
        return srcData.ToString();
    }

    public static string urlEncode(string data)
    {
        string newData = Utils.convertToUtf8(data);
        return HttpUtility.UrlEncode(newData, Encoding.UTF8);
        //return URLEncoder.encode(newData, "UTF-8");
    }

    public static string join(string[] items, string split) {
        if (items.Length == 0) {
            return "";
        }
        StringBuilder s = new StringBuilder();
        int i;
        for (i = 0; i < items.Length - 1; i++) {
            s.Append(items[i]);
            s.Append(split);
        }
        s.Append(items[i]);
        return s.ToString();
    }

    public static int rand(int min, int max) 
    {
        Random rd = new Random();
        return (int) ((max - min + 1) * rd.NextDouble() + min);
    }
}
}
