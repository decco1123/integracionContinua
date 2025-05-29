using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_6_8.Models
{
    public class Cafeteria
    {
        public Cafeteria() {
            ValorCombo1 = 8000;
            ValorCombo2 = 6000;
            ValorCombo3 = 4500;
        }
        public int ComboCafeteria { get; set; }
        public int ValorCombo1 { get; set; }
        public int ValorCombo2 { get; set; }
        public int ValorCombo3 { get; set; }
        public int ValorProducto { get; set; }
        public double PorcentajeDescuento { get; set; }
        public int Cantidad { get; set; }
        public int ValorAntesDescuento { get; set; }
        public int ValorDescuento { get; set; }
        public int ValorPagar { get; set; }
        public string Error { get; set; }
    }
}