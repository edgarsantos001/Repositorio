using Microsoft.Extensions.Logging;
using RoboTinic.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RoboTinic
{
    public class App
    {
        private readonly ILogger<App> _logger;
        private readonly IMaterial _material;
        private readonly IMedicamento _medicamento;

        public App(ILogger<App> logger, IMaterial material)
        {
            _logger = logger;
            _material = material;
        }

        public void Run()
        {
           // _logger.LogInformation("Ínicio Coletor. \n");

            Console.WriteLine("----------------------------------\n");
            Console.WriteLine("Coletor De Dados \n");
            Console.WriteLine(" ---- ---- ---- ---- ---- ----\n");
            Console.WriteLine("Lista de opções. \n");
            Console.WriteLine("Digite a opção para execução: \n");

            Console.WriteLine("1 - Material \n");
            Console.WriteLine("2 - Medicamento \n");
            Console.WriteLine("3 - Todos \n");
            Console.Write("Escolha a opção e pressione ENTER:");

            var escolha = Console.ReadLine();
            switch (escolha)
            {
                case "1":
                    _logger.LogInformation("Iniciando Coleta de dados Anvisa Material.");
                    InsertMat(); //_material.InsertMaterial();
                    break;
                case "2":
                    _logger.LogInformation("Iniciando Coleta de dados Anvisa Medicamento.");
                    InsertMed();  //_medicamento.InsertMedicamento();
                    break;
                default:
                    _logger.LogInformation("Iniciando Coleta de dados Anvisa Material e Medicamento.");
                    InsertAll();
                    break;
            }
            _logger.LogInformation("Finalizado!!");
            Console.ReadKey();
        }

        public void InsertMat()
        {
            Thread threadMat = new Thread(new ThreadStart(_material.InsertMaterial));
            Thread threadDet = new Thread(new ThreadStart(_material.InsertDetalhes));
            
            try
            {
                threadMat.Start();
                threadDet.Start();
            }
            catch (ThreadStartException thearex)
            {
                _logger.LogError($"Erro Thread{thearex.Message}");
            }


        }

        public void InsertMed()
        {
           // _medicamento.InsertMedicamento();

        }

        public void InsertAll()
        {
            Thread threadMat = new Thread(new ThreadStart(InsertMat));
            Thread threadMed = new Thread(new ThreadStart(InsertMed));


            try
            {
                threadMat.Start();
                threadMed.Start();
            }
            catch (ThreadStartException thearex)
            {
                _logger.LogError($"Erro Thread{thearex.Message}");
            }

        }

    }
}
