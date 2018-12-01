using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Generales.DireccionFamiliarEstudianteNs;

namespace Colegio.Generales.DireccionFamiliarEstudianteNs
{
    [AutoMap(typeof(DireccionFamiliarEstudiante))]
    public class DireccionFamiliarEstudianteDto: EntityDto<int>
    {
        public string Descripcion { get; set; }
        public int FamiliarEstudianteId { get; set; }
        public int TipoDireccionId { get; set; }
        public int SectorId { get; set; }
    }
}