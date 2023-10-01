namespace Domain.Endpoint.Entities
{
    public class Producto : BaseEntity
    {
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public int Preciocompra { get; set; }
        public int Precioventa { get; set; }
        public string Estado { get; set; }
    }
}

