//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Servicios_6_8.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class ComentariosResenas
    {
        public int ComentarioID { get; set; }
        public Nullable<int> ClienteID { get; set; }
        public string Comentario { get; set; }
        public Nullable<int> Calificacion { get; set; }
        public Nullable<System.DateTime> FechaComentario { get; set; }

        [JsonIgnore]
        public virtual Clientes Clientes { get; set; }
    }
}
