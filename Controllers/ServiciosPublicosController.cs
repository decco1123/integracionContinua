using Servicios_6_8.Clases;
using Servicios_6_8.Models;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Servicios_6_8.Controllers
{
    [EnableCors(origins: "http://localhost:50804", headers: "*", methods: "*")]
    public class ServiciosPublicosController : ApiController
    {
        // POST api/<controller>
        public ServiciosPublicos Post([FromBody] ServiciosPublicos servicios)
        {
            clsServiciosPublicos serviciosPublicos = new clsServiciosPublicos();
            serviciosPublicos.serviciosPublicos = servicios;
            serviciosPublicos.CalcularPagoTotal();
            return serviciosPublicos.serviciosPublicos;
        }
    }
}