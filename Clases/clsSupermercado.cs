using Servicios_6_8.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Servicios_6_8.Clases
{
    public class clsSupermercado
    {
        //Agrego una propiedad de supermercado, para recibir un objeto con la información del elemento que quiero modificar en la base de datos
        public SUPErmercado supermercado { get; set; }
        //Agrego un objeto privado para gestionar los objetos de conexión a la base de datos. 
        private DBSuperEntities1 dbSuper = new DBSuperEntities1();
        public string Insertar()
        {
            try
            {
                //El insertar se realiza con el método .add del objeto dbSuper.Supermercado
                dbSuper.SUPErmercadoes.Add(supermercado);
                //Para garantizar que se inserte la información en la base de datos, se da la instrucción de SaveChanges()
                dbSuper.SaveChanges();
                return "Se ingresó el supermercado: " + supermercado.Nombre;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        //consultar
        public SUPErmercado Consultar(string NIT)
        {
            //La consulta utiliza el método FirstOrDefault, que retorna el primer elemento que cumpla la condición solicitada, si
            //no existe, retorna null
            //Una expresión lamda, es una expresión que convierte la variable antes del => en un objeto del tipo que se está trabajando
            return dbSuper.SUPErmercadoes.FirstOrDefault(s => s.Nit == NIT);
        }
        //Actalizar, primero se consulta el elemento en la "lista" o base de datos, se modifican los valores y se guarda
        public string Actualizar()
        {
            try
            {
                //Primero se consulta y se graba el resultado en un objeto temporal, que es el que se va a modificar y luego a guardar
                //SUPErmercado _supermercado = dbSuper.SUPErmercadoes.FirstOrDefault(s => s.Nit == supermercado.Nit);
                SUPErmercado _supermercado = Consultar(supermercado.Nit);
                if (_supermercado == null)
                {
                    return "El supermercado con NIT: " + supermercado.Nit + ", no existe en la base de datos.";
                }
                //Se actualizan los datos de nombre y sitio web, con la información que se envió en el supermercado
                _supermercado.Nombre = supermercado.Nombre;
                _supermercado.SitioWeb = supermercado.SitioWeb;
                //Se graban los cambios con .SaveChanges()
                dbSuper.SaveChanges();
                //Se retorna la respuesta
                return "Se actualizó el supermercado: " + supermercado.Nombre;
            }
            catch(Exception ex)
            {
                //Se captura el mensaje de la excepción y se retorna como respuesta
                return ex.Message;
            }
        }
        public string Eliminar()
        {
            try
            {
                //Se consulta primero el elemento que se quiere eliminar
                SUPErmercado _supermercado = Consultar(supermercado.Nit);
                if (_supermercado == null)
                {
                    return "El supermercado con NIT: " + supermercado.Nit + ", no existe en la base de datos.";
                }
                dbSuper.SUPErmercadoes.Remove(_supermercado);
                //Se graban los cambios
                dbSuper.SaveChanges();
                //Se retorna la respuesta
                return "Se eliminó el supermercado: " + supermercado.Nit;
            }
            catch(Exception ex)
            {
                //Se captura el mensaje de la excepción y se retorna como respuesta
                return ex.Message;
            }
        }
    }
}