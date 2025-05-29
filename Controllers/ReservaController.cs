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
    public class ReservaController : ApiController
    {
        // GET api/<controller>
        public ReservaEscenarios Get(string Documento)
        {
            clsReserva reserva = new clsReserva();
            return reserva.Consultar(Documento);
        }
        // POST api/<controller>
        public string Post([FromBody] ReservaEscenarios Reserva)
        {
            clsReserva _reserva = new clsReserva();
            _reserva.reserva = Reserva;
            return _reserva.Insertar();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] ReservaEscenarios Reserva)
        {
            clsReserva _reserva = new clsReserva();
            _reserva.reserva = Reserva;
            return _reserva.Actualizar();
        }

        // DELETE api/<controller>/5
        public string Delete(ReservaEscenarios Reserva)
        {
            clsReserva _reserva = new clsReserva();
            _reserva.reserva = Reserva;
            return _reserva.Eliminar();
        }
    }
}