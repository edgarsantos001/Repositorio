using RoboTinic.RoboDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboTinic.InterfaceRepositorio
{
    public interface IMaterialRepositorio
    {
        int InsertMaterial(Material material);
        void InsertMaterialContent(List<Content> content);
        void InsertMaterialDetalhe(Detalhe detalhe);
        void InsertOrUpdateMaterialContent(Content content);
        Content ObterProcessos(string processo);
        List<string> ObterProcessos();
    }
}
