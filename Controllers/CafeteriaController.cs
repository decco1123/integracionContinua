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
    public class CafeteriaController : ApiController
    {
        // POST api/<controller>
        public Cafeteria Post([FromBody] Cafeteria cafeteria)
        {
            //Creo una instancia de la clase que procesa el cálculo de los combos
            clsCafeteria _cafeteria = new clsCafeteria();
            //Paso la propiedad de entrada, con la información de los datos para el proceso
            _cafeteria.cafeteria = cafeteria;
            //Invoco el método de cálculo del pago
            _cafeteria.CalcularPago();
            //Retorno el objeto con las respuestas
            return _cafeteria.cafeteria;
        }
    }
}