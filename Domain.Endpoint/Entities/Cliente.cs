//Entidad de el catálogo Cliente, elaborado por: Mónica Gutiérrez
using System;

namespace Domain.Endpoint.Entities
{
    public class Cliente : BaseEntity
    {
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
        public int Estado { get; set; }
        public DateTime FechaCreacion { get; set; }



    }
}
