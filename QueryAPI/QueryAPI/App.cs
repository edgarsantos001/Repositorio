using Microsoft.Extensions.Logging;
using QueryAPI.Interface;
using System;
using System.Collections.Generic;
using System.Text;
<<<<<<< HEAD
using System.Threading;
=======
>>>>>>> 250e1124aac982d430b4c96b5f40c1413fb05cc0

namespace QueryAPI
{
    public class App
    {
        private readonly ILogger<App> _logger;
        private readonly IMaterial _material;
<<<<<<< HEAD
        private readonly IMedicamento _medicamento;

        public App(ILogger<App> logger, IMaterial material, IMedicamento medicamento)
        {
            _logger = logger;
            _material = material;
            _medicamento = medicamento;
=======

        public App(ILogger<App> logger, IMaterial material)
        {
            _logger = logger;
            _material = material;
>>>>>>> 250e1124aac982d430b4c96b5f40c1413fb05cc0
        }

        public void Run()
        {
<<<<<<< HEAD
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


=======
            _logger.LogInformation("Ínicio Coleta Material."); 
            _material.InsertMaterial();

            Console.ReadKey();
        }
>>>>>>> 250e1124aac982d430b4c96b5f40c1413fb05cc0
    }
}
