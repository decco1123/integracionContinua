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
    public class TipoProductoController : ApiController
    {
        public List<TIpoPRoducto> Get()
        {
            clsTipoProducto _TipoProducto = new clsTipoProducto();
            return _TipoProducto.ConsultarActivos();
        }
    }
}