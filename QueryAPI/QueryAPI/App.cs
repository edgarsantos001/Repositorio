using Microsoft.Extensions.Logging;
using QueryAPI.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace QueryAPI
{
    public class App
    {
        private readonly ILogger<App> _logger;
        private readonly IMaterial _material;

        private readonly IMedicamento _medicamento;

        public App(ILogger<App> logger, IMaterial material, IMedicamento medicamento)
        {
            _logger = logger;
            _material = material;
            _medicamento = medicamento;

        }

        public void Run()
        {
            _logger.LogInformation("Ínicio Coletor. \n");

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
                    _material.InsertMaterial();
                    break;
                case "2":
                    _logger.LogInformation("Iniciando Coleta de dados Anvisa Medicamento.");
                    _medicamento.InsertMedicamento();
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
            _material.InsertMaterial();

        }

        public void InsertMed()
        {
            _medicamento.InsertMedicamento();

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
