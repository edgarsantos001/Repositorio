using Microsoft.Extensions.Logging;
using QueryAPI.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueryAPI
{
    public class App
    {
        private readonly ILogger<App> _logger;
        private readonly IMaterial _material;

        public App(ILogger<App> logger, IMaterial material)
        {
            _logger = logger;
            _material = material;
        }

        public void Run()
        {
            _logger.LogInformation("Ínicio Coleta Material."); 
            _material.InsertMaterial();

            Console.ReadKey();
        }
    }
}
