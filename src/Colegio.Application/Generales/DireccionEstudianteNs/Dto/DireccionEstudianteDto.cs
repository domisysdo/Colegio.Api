using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Generales.DireccionEstudianteNs;

namespace Colegio.Generales.DireccionEstudianteNs
{
    [AutoMap(typeof(DireccionEstudiante))]
    public class DireccionEstudianteDto: EntityDto<int>
    {
        public string Descripcion { get; set; }
        public int EstudianteId { get; set; }
        public int TipoDireccionId { get; set; }
        public int PaisId { get; set; }
        public int ProvinciaId { get; set; }
        public int MunicipioId { get; set; }
        public int SectorId { get; set; }

    }
}