using Servicios_6_8.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Servicios_6_8.Clases
{
    public class clsCliente
    {
        public CLIEnte cliente { get; set; }
        private DBSuperEntities1 dbSuper = new DBSuperEntities1();
        public string Insertar()
        {
            try
            {
                dbSuper.CLIEntes.Add(cliente);
                dbSuper.SaveChanges();
                return "Se ingresó el cliente con documento: " + cliente.Documento;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Actualizar()
        {
            try
            {
                //El método .AddOrUpdate, hace el proceso de inserción si el cliente no existe, y si existe lo actualiza
                //Según la literatura, sólo es útil cuando se envía toda la información del cliente, cuando se quiere actualizar
                //una información parcial, se pueden obtener resultados no deseados.
                dbSuper.CLIEntes.AddOrUpdate(cliente);
                dbSuper.SaveChanges();
                return "Se actualizaron los datos del cliente con documento: " + cliente.Documento;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public CLIEnte Consultar(string documento)
        {
            return dbSuper.CLIEntes.FirstOrDefault(c=> c.Documento == documento);
        }
        public string Eliminar()
        {
            CLIEnte _cliente = Consultar(cliente.Documento);
            if (_cliente == null ) 
            {
                return "El cliente con documento: " + cliente.Documento + " no existe en la base de datos.";
            }
            try
            {
                dbSuper.CLIEntes.Remove(_cliente);
                dbSuper.SaveChanges();
                return "Se eliminó el cliente con documento: " + cliente.Documento;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}