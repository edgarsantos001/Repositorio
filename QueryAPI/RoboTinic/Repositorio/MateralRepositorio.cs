using RoboTinic.Context;
using RoboTinic.Context.UtilContext;
using RoboTinic.InterfaceRepositorio;
using RoboTinic.RoboDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboTinic.Repositorio
{
    public class MateralRepositorio : IMaterialRepositorio
    {
        public int InsertMaterial(Material material)
        {
            using (var context = new RoboContext())
            {
                context.Material.Add(material);
                context.SaveChanges();

                return material.Id;
            }
        }

        public void InsertMaterialContent(List<Content> content)
        {
            using (var context = new RoboContext())
            {
                context.Content.AddRange(content);
                context.SaveChangesAsync();
            }
        }

        public void InsertMaterialDetalhe(Detalhe detalhe)
        {
            using (var context = new RoboContext())
            {
                context.InsertOrUpdate(detalhe);
                context.SaveChanges();
            }
        }

        public void InsertOrUpdateMaterialContent(Content content)
        {
            using (var context = new RoboContext())
            {
                context.InsertOrUpdate(content);
                context.SaveChangesAsync();
            }
        }

        public List<string> ObterProcessos()
        {
            using (var context = new RoboContext())
            {
                return context.Content.Where(x=> !x.Atualizado && !x.Erro).Select(x => x.processo).ToList();
            }
        }


        public Content ObterProcessos(string processo)
        {
            using (var context = new RoboContext())
            {
                return context.Content.FirstOrDefault(x=> x.processo == processo);
            }
        }
    }
}
