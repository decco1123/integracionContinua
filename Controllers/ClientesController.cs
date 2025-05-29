using Servicios_6_8.Clases;
using Servicios_6_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Http;

namespace Servicios_6_8.Controllers
{
    public class ClientesController : ApiController
    {
        [EnableCors(origins: "http://localhost:50804", headers: "*", methods: "*")]
        
            // GET api/<controller>/5
            public Clientes Get(int ClienteID)
            {
                clsClientes _cliente = new clsClientes();
                return _cliente.Consultar(ClienteID);
            }

            // POST api/<controller> - Se utiliza para insertar en la base de datos
            public string Post([FromBody] Clientes Cliente)
            {
                clsClientes _cliente = new clsClientes();
                //Paso la propiedad supermercado con la información al objeto
                _cliente.cliente = Cliente;
                //Invoco el método de insertar
                return _cliente.Insertar();
            }

            // PUT api/<controller>/5 - Se utiliza para actualizar en la base de datos
            public string Put([FromBody] Clientes Cliente)
            {
                clsClientes _cliente = new clsClientes();
                _cliente.cliente = Cliente;
                return _cliente.Actualizar();
            }

            // DELETE api/<controller>/5 - Se utiiliza para eliminar en la base de datos
            public string Delete([FromBody] Clientes Cliente)
            {
                clsClientes _cliente = new clsClientes();
                _cliente.cliente= Cliente;
                return _cliente.Eliminar();
            }
        }
    }

