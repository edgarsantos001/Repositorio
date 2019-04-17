using ClassesDTO.DTO.MatDTO;
using ConData.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConData
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"TESTE MIGRATIONS SQLITE");

            using (var context = new QueryContext())
            {
                List<ContentMaterialDTO> list = new List<ContentMaterialDTO>();
                var material = new MaterialDTO() { totalPages = 1 };
                
                material.content.Add(new ContentMaterialDTO { processo = "TESTE" });
                material.content.Add(new ContentMaterialDTO { processo = "TESTE - 2" });
                material.content.Add(new ContentMaterialDTO { processo = "TESTE - 3" });

                context.Material.Add(material);
                context.SaveChanges();

                foreach (var mat in context.Material.Local)
                {
                    Console.WriteLine($"Material: {mat.totalPages}");

                    foreach (var cont in material.content)
                    {
                        Console.WriteLine($"Content: {cont.processo}");
                    }
                }

                Console.ReadLine();

            }

        }
    }
}
