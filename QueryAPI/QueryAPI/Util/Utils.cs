using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace QueryAPI
{
    public static class Utils
    {
        public static T ResultRequestJson<T>(string url) where T : new()
        {
            T obj;
            var request = WebRequest.CreateHttp(url); 
            request.Method = "GET";
            request.Headers.Add("Authorization", "Guest");
            try
            {
                using (var response = request.GetResponse())
                {
                    var stream = response.GetResponseStream();
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        object objResponse = reader.ReadToEnd();
                        obj = JsonConvert.DeserializeObject<T>(objResponse.ToString());
                    }
                }
            }
            catch (WebException wex)
            {
                if (wex.Status == WebExceptionStatus.ProtocolError)
                    return new T();
                Thread.Sleep(1000);
                return ResultRequestJson<T>(url);
            }
            return obj;
        }
    }
}
