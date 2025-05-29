using Servicios_6_8.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Servicios_6_8.Clases
{
    public class clsClientes
    {
        public Clientes cliente { get; set; }
        //Agrego un objeto privado para gestionar los objetos de conexión a la base de datos. 
        private HotelDBEntities1 HotelDB = new HotelDBEntities1 ();
        public string Insertar()
        {
            try
            {
                //El insertar se realiza con el método .add del objeto dbSuper.Supermercado
                HotelDB.Clientes.Add(cliente);
                //Para garantizar que se inserte la información en la base de datos, se da la instrucción de SaveChanges()
                HotelDB.SaveChanges();
                return "Se ingresó el documento: " + cliente.ClienteID;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        //consultar
        public Clientes Consultar(int ClienteID)
        {
            //La consulta utiliza el método FirstOrDefault, que retorna el primer elemento que cumpla la condición solicitada, si
            //no existe, retorna null
            //Una expresión lamda, es una expresión que convierte la variable antes del => en un objeto del tipo que se está trabajando
            return HotelDB.Clientes.FirstOrDefault(s => s.ClienteID == ClienteID);
        }
        //Actalizar, primero se consulta el elemento en la "lista" o base de datos, se modifican los valores y se guarda
        public string Actualizar()
        {
            try
            {
                //El método .AddOrUpdate, hace el proceso de inserción si el cliente no existe, y si existe lo actualiza
                //Según la literatura, sólo es útil cuando se envía toda la información del cliente, cuando se quiere actualizar
                //una información parcial, se pueden obtener resultados no deseados.
                HotelDB.Clientes.AddOrUpdate(cliente);
                HotelDB.SaveChanges();
                return "Se actualizaron los datos del medicamento con id: " + cliente.ClienteID;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }
        public string Eliminar()
        {
            try
            {
                //Se consulta primero el elemento que se quiere eliminar
                Clientes _cliente = Consultar(cliente.ClienteID);
                if (_cliente == null)
                {
                    return "El cliente con el documento: " + cliente.ClienteID + ", no existe en la base de datos.";
                }
                HotelDB.Clientes.Remove(_cliente);
                //Se graban los cambios
                HotelDB.SaveChanges();
                //Se retorna la respuesta
                return "Se eliminó el cliente: " + cliente.ClienteID;
            }
            catch (Exception ex)
            {
                //Se captura el mensaje de la excepción y se retorna como respuesta
                return ex.Message;
            }
        }
    }
}

    
