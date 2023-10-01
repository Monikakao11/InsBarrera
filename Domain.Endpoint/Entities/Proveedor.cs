namespace Domain.Endpoint.Entities
{
    public class Proveedor:BaseEntity
    {
        public string NombreCompañia { get; set; }

        public int Telefono { get; set; }
        public string Correo { get; set; }

       
    }
}
