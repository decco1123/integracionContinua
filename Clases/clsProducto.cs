using Servicios_6_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios_6_8.Clases
{
    public class clsProducto
    {
        public PRODucto producto { get; set; }
        private DBSuperEntities1 dbSuper = new DBSuperEntities1();
        //Consultar todos los productos mezclados con el tipo de producto
        public IQueryable ListaProductos()
        {
            /*
             SELECT	    TP.Codigo as CodTIPO, TP.Nombre as TIPO, P.Codigo, P.Nombre 
             FROM	    TIpoPRoducto TP inner join PRODucto P
		                ON TP.Codigo = P.CodigoTipoProducto
             */
            return from TP in dbSuper.Set<TIpoPRoducto>()
                   join P in dbSuper.Set<PRODucto>()
                   on TP.Codigo equals P.CodigoTipoProducto
                   orderby(TP.Nombre)
                   select new
                   {
                       Cod_Tipo_Producto = TP.Codigo,
                       TipoProducto = TP.Nombre,
                       Codigo = P.Codigo,
                       Producto = P.Nombre,
                       Descripcion = P.Descripcion,
                       Cantidad = P.Cantidad,
                       ValorUnitario = P.ValorUnitario
                   };
        }
    }
}