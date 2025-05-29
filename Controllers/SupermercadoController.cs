using Servicios_6_8.Clases;
using Servicios_6_8.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Servicios_6_8.Controllers
{
    [EnableCors(origins: "http://localhost:50804", headers: "*", methods: "*")]
    public class SupermercadoController : ApiController
    {
        // GET api/<controller>/5
        public SUPErmercado Get(string Nit)
        {
            clsSupermercado _supermercado = new clsSupermercado();
            return _supermercado.Consultar(Nit);
        }

        // POST api/<controller> - Se utiliza para insertar en la base de datos
        public string Post([FromBody] SUPErmercado supermercado)
        {
            clsSupermercado _supermercado = new clsSupermercado();
            //Paso la propiedad supermercado con la información al objeto
            _supermercado.supermercado = supermercado;
            //Invoco el método de insertar
            return _supermercado.Insertar();
        }

        // PUT api/<controller>/5 - Se utiliza para actualizar en la base de datos
        public string Put([FromBody] SUPErmercado supermercado)
        {
            clsSupermercado _supermercado = new clsSupermercado();
            _supermercado.supermercado = supermercado;
            return _supermercado.Actualizar();
        }

        // DELETE api/<controller>/5 - Se utiiliza para eliminar en la base de datos
        public string Delete([FromBody] SUPErmercado supermercado)
        {
            clsSupermercado _supermercado = new clsSupermercado();
            _supermercado.supermercado = supermercado;
            return _supermercado.Eliminar();
        }
    }
}