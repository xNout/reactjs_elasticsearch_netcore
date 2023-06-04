namespace N5.CHALLENGE.DOMAIN.DTOs
{
    public class PermissionDTO
    {
        public int Id { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public int IdTipoPermiso { get; set; }
        public string DescripcionPermiso { get; set; }
        public DateTime FechaPermiso { get; set; }
    }
}
