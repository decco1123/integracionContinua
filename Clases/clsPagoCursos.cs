using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Servicios_6_8.Models;

namespace Servicios_6_8.Clases
{
    public class clsPagoCursos
    {
        public clsPagoCursos()
        {
            ValorCurso = 150000;
        }
        public CursosVacacionale curso { get; set; }
        private int ValorCurso;
        public void CalcularPago()
        {
            curso.ValorPagoAntesDcto = curso.CantidadCursos * 150000;
            CalcularPorcentajeDescuento();
            CalcularDescuento();
            curso.TotalPagar = curso.ValorPagoAntesDcto - curso.ValorDescuento;
        }
        private void CalcularPorcentajeDescuento()
        {
            double PorcentajeDescuento;
            if (curso.CantidadCursos > 3)
            {
                PorcentajeDescuento = 0.40;
            }
            else
            {
                if (curso.CantidadCursos > 1)
                {
                    PorcentajeDescuento = 0.25;
                }
                else
                { PorcentajeDescuento = 0; }
            }

            curso.PorcentajeDescuento = (float)(PorcentajeDescuento);
        }
        private void CalcularDescuento()
        {
            curso.ValorDescuento = Convert.ToInt32(curso.ValorPagoAntesDcto * curso.PorcentajeDescuento);
        }
    }
}