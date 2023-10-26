namespace Domain.Endpoint.Entities
{
    public class User:BaseEntity
    {
        //public int Id { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
        public string Estado { get; set; }
        public string Sexo { get; set; }
        public string UserName { get; set; }
        public string Contraseña { get; set; }

    }
}
