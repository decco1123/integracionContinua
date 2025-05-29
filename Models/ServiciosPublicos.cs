using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_6_8.Models
{
    public class ServiciosPublicos
    {
        public ServiciosPublicos() {
            ValorM3Agua = 1500;
            ValorM3Gas = 1200;
            ValorKwElectricidad = 950;
        }
        public double ConsumoAgua { get; set; }
        public double ConsumoGas { get; set; }
        public double ConsumoElectricidad { get; set; }
        public double TotalPagar { get; set; }
        public double TotalRecargo { get; set; }
        public double TotalConsumoAgua { get; set; }
        public double TotalConsumoGas { get; set; }
        public double TotalConsumoEnergia { get; set; }
        public double ValorConsumoAgua { get; set; }
        public double ValorConsumoGas { get; set; }
        public double ValorConsumoEnergia { get; set; }
        public double ValorRecargoAgua { get; set; }
        public double ValorRecargoGas { get; set; }
        public double ValorRecargoEnergia { get; set; }
        public double ValorM3Agua { get; set; }
        public double ValorM3Gas { get; set; }
        public double ValorKwElectricidad { get; set; }
        public string Error { get; set; }
    }
}