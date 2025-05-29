using Servicios_6_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_6_8.Clases
{
    public class clsCafeteria
    {
        public Cafeteria cafeteria { get; set; }
        public void CalcularPago()
        {
            if (Validar())
            {
                //Calculo el valor antes de descuento
                CalcularValorProducto();
                cafeteria.ValorAntesDescuento = cafeteria.Cantidad * cafeteria.ValorProducto;
                CalcularDescuento();
                cafeteria.ValorDescuento = Convert.ToInt32(cafeteria.ValorAntesDescuento * cafeteria.PorcentajeDescuento);
                cafeteria.ValorPagar = cafeteria.ValorAntesDescuento - cafeteria.ValorDescuento;
            }
            else
            {
                return;
            }
        }
        private void CalcularDescuento()
        {
            if (cafeteria.Cantidad < 3)
                cafeteria.PorcentajeDescuento = 0.0;
            else if (cafeteria.Cantidad < 5)
                cafeteria.PorcentajeDescuento = 0.10;
            else if (cafeteria.Cantidad < 9)
                cafeteria.PorcentajeDescuento = 0.20;
            else
                cafeteria.PorcentajeDescuento = 0.30;
        }
        private void CalcularValorProducto()
        {
            if (cafeteria.ComboCafeteria == 1)
                cafeteria.ValorProducto = cafeteria.ValorCombo1;
            else if (cafeteria.ComboCafeteria == 2)
                cafeteria.ValorProducto = cafeteria.ValorCombo2;
            else
                cafeteria.ValorProducto = cafeteria.ValorCombo3;
        }
        private bool Validar()
        {
            if (cafeteria.ComboCafeteria < 1 || cafeteria.ComboCafeteria > 3)
            {
                cafeteria.Error = "No definió un combo que se pueda procesar, consulte con el administrador del sistema";
                return false;
            }
            if (cafeteria.Cantidad < 0 || cafeteria.Cantidad > 100)
            {
                cafeteria.Error = "No definió una cantidad adecuada, debe estar entre 1 y 100";
                return false;
            }
            return true;
        }
    }
}