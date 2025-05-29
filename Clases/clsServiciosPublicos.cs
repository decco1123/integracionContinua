using Servicios_6_8.Models;

namespace Servicios_6_8.Clases
{
    public class clsServiciosPublicos
    {
        public ServiciosPublicos serviciosPublicos { get; set; }
        public void CalcularPagoTotal()
        {
            if (Validar())
            {
                CalcularPagoAguas();
                CalcularPagoEnergia();
                CalcularPagoGas();
                serviciosPublicos.TotalRecargo = serviciosPublicos.ValorRecargoAgua + serviciosPublicos.ValorRecargoGas + serviciosPublicos.ValorRecargoEnergia;
                serviciosPublicos.TotalPagar = serviciosPublicos.ValorConsumoAgua + serviciosPublicos.ValorConsumoGas + 
                                                serviciosPublicos.ValorConsumoEnergia + serviciosPublicos.TotalRecargo; 
            }
            else
            {
                //Si no pasa la validación, no debe continuar con los cálculos
                return;
            }
        }
        private void CalcularPagoAguas()
        {
            double PorcentajeRecargo;
            
            serviciosPublicos.ValorConsumoAgua = serviciosPublicos.ConsumoAgua * serviciosPublicos.ValorM3Agua;
            if (serviciosPublicos.ConsumoAgua < 15)
            {
                PorcentajeRecargo = -0.10;
            }
            else
            {
                if (serviciosPublicos.ConsumoAgua  <= 20)
                {
                    PorcentajeRecargo = 0.0;
                }
                else
                {
                    PorcentajeRecargo = 0.20;
                }
            }
            serviciosPublicos.ValorRecargoAgua = serviciosPublicos.ValorConsumoAgua * PorcentajeRecargo;
        }
        private void CalcularPagoGas()
        {
            double PorcentajeRecargo;

            serviciosPublicos.ValorConsumoGas = serviciosPublicos.ConsumoGas * serviciosPublicos.ValorM3Gas;
            if (serviciosPublicos.ConsumoGas < 20)
            {
                PorcentajeRecargo = -0.15;
            }
            else
            {
                if (serviciosPublicos.ConsumoGas <= 40)
                {
                    PorcentajeRecargo = 0.0;
                }
                else
                {
                    PorcentajeRecargo = 0.35;
                }
            }
            serviciosPublicos.ValorRecargoGas = serviciosPublicos.ValorConsumoGas * PorcentajeRecargo;
        }
        private void CalcularPagoEnergia()
        {
            double PorcentajeRecargo;

            serviciosPublicos.ValorConsumoEnergia = serviciosPublicos.ConsumoElectricidad * serviciosPublicos.ValorKwElectricidad;
            if (serviciosPublicos.ConsumoElectricidad < 50)
            {
                PorcentajeRecargo = -0.20;
            }
            else
            {
                if (serviciosPublicos.ConsumoElectricidad <= 80)
                {
                    PorcentajeRecargo = 0.0;
                }
                else
                {
                    PorcentajeRecargo = 0.25;
                }
            }
            serviciosPublicos.ValorRecargoEnergia = serviciosPublicos.ValorConsumoEnergia * PorcentajeRecargo;

        }
        private bool Validar()
        {
            if (serviciosPublicos.ConsumoAgua < 0)
            {
                serviciosPublicos.Error = "No definió el cosumo de agua";
            }
            if (serviciosPublicos.ConsumoElectricidad < 0)
            {
                serviciosPublicos.Error += "\nNo definió el consumo de electricidad";
            }
            if (serviciosPublicos.ConsumoGas < 0)
            {
                serviciosPublicos.Error += "\nNo definió el consumo de gas";
            }
            if (string.IsNullOrEmpty(serviciosPublicos.Error))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}