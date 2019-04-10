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
            _logger.LogInformation("Ínicio Coletor.");
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
    }
}
