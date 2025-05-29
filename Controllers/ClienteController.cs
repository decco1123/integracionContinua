using Servicios_6_8.Clases;
using Servicios_6_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Servicios_6_8.Controllers
{
    [EnableCors(origins: "http://localhost:50804", headers: "*", methods: "*")]
    public class ClienteController : ApiController
    {
        // GET api/<controller>
        public CLIEnte Get(string Documento)
        {
            clsCliente cliente = new clsCliente();
            return cliente.Consultar(Documento);
        }
        // POST api/<controller>
        public string Post([FromBody] CLIEnte Cliente)
        {
            clsCliente _cliente = new clsCliente();
            _cliente.cliente = Cliente;
            return _cliente.Insertar();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] CLIEnte Cliente)
        {
            clsCliente _cliente = new clsCliente();
            _cliente.cliente = Cliente;
            return _cliente.Actualizar();
        }

        // DELETE api/<controller>/5
        public string Delete(CLIEnte Cliente)
        {
            clsCliente _cliente = new clsCliente();
            _cliente.cliente = Cliente;
            return _cliente.Eliminar();
        }
    }
}