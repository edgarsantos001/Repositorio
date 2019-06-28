using ClassesDTO.DTO.MatDTO;
using ConData.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

namespace ConData
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"TESTE MIGRATIONS SQLITE");

            using (var context = new QueryContext())
            {
                //List<ContentMaterial> list = new List<ContentMaterial>();
                //var material = new Material() { totalPages = 1 };
                //material.content.Add(new ContentMaterial { processo = "TESTE" });
                //material.content.Add(new ContentMaterial { processo = "TESTE - 2" });
                //material.content.Add(new ContentMaterial { processo = "TESTE - 3" });
                //context.Material.Add(material);
                //context.SaveChanges();

                //foreach (var mat in context.Material.Local)
                //{
                //    Console.WriteLine($"Material: {mat.totalPages}");

                //    foreach (var cont in material.content)
                //    {
                //        Console.WriteLine($"Content: {cont.processo}");
                //    }
                //}

                Console.ReadLine();

            }
        }


    }


    public static class Utils
    {
        public static T ResultRequestJson<T>(string url) where T : new()
        {
            T obj;
            var request = WebRequest.CreateHttp(url);
            request.Method = "GET";
            request.Headers.Add("Postman-Token", "cecba5a9-7f5d-4098-9807-31a8f93b09ad");
            request.Headers.Add("cache-control", "no-cache");
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
