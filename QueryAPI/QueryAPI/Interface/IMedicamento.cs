<<<<<<< HEAD
﻿using QueryAPI.DTO;
using QueryAPI.DTO.MatDTO;
using System;
=======
﻿using System;
>>>>>>> 250e1124aac982d430b4c96b5f40c1413fb05cc0
using System.Collections.Generic;
using System.Text;

namespace QueryAPI.Interface
{
    public interface IMedicamento
    {
<<<<<<< HEAD
        void InsertMedicamento();
        void InsertPresentetion(List<ApresentacaoDTO> presentetions, int idContent);
        void InsertRotulo(List<string> rotulo, int idMedDet);
        void InsertClasseTerapeutica(List<string> classeTeraputica, int idMedDet);
        void InsertFormasFarmaceuticas(List<string> formasFarmaceuticas, int idMedDet);
        void InsertDestinacao(List<string> destinacao, int idMedDet);
        void InsertRestricaoUso(List<string> restricaoUso, int idMedDet);
        void InsertRestricaoPrescricao(List<string> restricaoPrescricao, int idMedDet);
        void InsertConservacao(List<string> conservacao, int idMedDet);
        void InsertPrincipioAtivo(List<string> principiosAtivos, int idMedDet);
        void InsertViasAdministracao(List<string> viasAdministracao, int idMedDet);
        void InsertMarcas(List<string> marcas, int idMedDet);
        void InsertAcessorios(List<Acessorio> acessorios, int idMedDet);
        void InsertEnvoltorio(List<string> envoltorios, int idMedDet);
        void InsertFactoryInter(List<FabricantesInternacionais> fabricantes, int idContent);
        void InsertFactoryNac(List<FabricantesNacionais> fabricantes, int idContent);
        
=======
>>>>>>> 250e1124aac982d430b4c96b5f40c1413fb05cc0
    }
}
