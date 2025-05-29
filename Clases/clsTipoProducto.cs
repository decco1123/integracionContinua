using Servicios_6_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_6_8.Clases
{
    public class clsTipoProducto
    {
        public TIpoPRoducto TipoProducto { get; set; }
        private DBSuperEntities1 dbSuper = new DBSuperEntities1();
        public List<TIpoPRoducto> ConsultarActivos()
        {
            //Este método retorna todos los tipos de productos activos
            //Se hace una consulta a la base de datos, del tipo de producto, para que los retorne todos en formato de lista
            //Sirve para llenar el combo
            return dbSuper.TIpoPRoductoes
                          .OrderBy(t=> t.Nombre)
                          .Where(t => t.Activo == true)
                          .ToList();
        }
        //Faltan los demás métodos de la clase... NO se van a trabajar porque estamos haciendo producto
    }
}