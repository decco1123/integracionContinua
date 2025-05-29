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
    [EnableCors (origins: "http://localhost:50804", headers: "*", methods: "*")]
    public class CursosVacacionalesController : ApiController
    {
        public CursosVacacionale Get(string Documento)
        {
            clsCursos _cursos = new clsCursos();
            return _cursos.Consultar(Documento);
        }
        // POST api/<controller>
        public string Post([FromBody] CursosVacacionale curso)
        {
            clsCursos _cursos = new clsCursos();
            _cursos.cursos = curso;
            return _cursos.Insertar();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] CursosVacacionale curso)
        {
            clsCursos _cursos = new clsCursos();
            _cursos.cursos = curso;
            return _cursos.Actualizar();
        }

        // DELETE api/<controller>/5
        public string Delete(CursosVacacionale curso)
        {
            clsCursos _cursos = new clsCursos();
            _cursos.cursos = curso;
            return _cursos.Eliminar();
        }
    }
}