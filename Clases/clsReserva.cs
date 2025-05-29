using Servicios_6_8.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Servicios_6_8.Clases
{
    public class clsReserva
    {
        public ReservaEscenarios reserva { get; set; }
        private DbReservaEntities3 dbreserva = new DbReservaEntities3();

        private void Descuento() { 
        
        double descuento = 0;

            reserva.ValorSinDescuento = 50000 * reserva.HorasReserva; 
              if(reserva.HorasReserva > 2)
            {

                descuento += 0.20;
            }

            if(reserva.DiaReserva == "semana")
            {

                descuento += 0.40;

            }
            
          
            reserva.ValorDescuento = (int)(reserva.ValorSinDescuento * descuento);

            reserva.ValorPagar = reserva.ValorSinDescuento - reserva.ValorDescuento;
        
        }

        public string Insertar()
        {
            Descuento();
            try
            {
                dbreserva.ReservaEscenarios.Add(reserva);
                dbreserva.SaveChanges();
                return "Se ingresó el cliente con documento: " + reserva.Documento;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Actualizar()
        {
            Descuento();
            try
            {
                //El método .AddOrUpdate, hace el proceso de inserción si el cliente no existe, y si existe lo actualiza
                //Según la literatura, sólo es útil cuando se envía toda la información del cliente, cuando se quiere actualizar
                //una información parcial, se pueden obtener resultados no deseados.
                dbreserva.ReservaEscenarios.AddOrUpdate(reserva);
                dbreserva.SaveChanges();
                return "Se actualizaron los datos del cliente con documento: " + reserva.Documento;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public ReservaEscenarios Consultar(string documento)
        {
            return dbreserva.ReservaEscenarios.FirstOrDefault(c=> c.Documento == documento);
        }
        public string Eliminar()
        {
            ReservaEscenarios _reserva = Consultar(reserva.Documento);
            if (_reserva == null ) 
            {
                return "El cliente con documento: " + reserva.Documento + " no existe en la base de datos.";
            }
            try
            {
                dbreserva.ReservaEscenarios.Remove(_reserva);
                dbreserva.SaveChanges();
                return "Se eliminó el cliente con documento: " +reserva.Documento;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}