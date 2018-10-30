using Colegio.Enums;

namespace Colegio.EstudianteNs
{
    public class GetEstudianteOutput
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public Estado Estado { get; set; }
    }
}