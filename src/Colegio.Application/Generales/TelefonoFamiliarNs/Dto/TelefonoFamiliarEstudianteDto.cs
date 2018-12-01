using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Generales.TelefonoFamiliarNs;

namespace Colegio.Generales.TelefonoFamiliarEstudianteNs
{
    [AutoMap(typeof(TelefonoFamiliarEstudiante))]
    public class TelefonoFamiliarEstudianteDto: EntityDto<int>
    {
        public string Numero { get; set; }
        public int TipoTelefonoId { get; set; }
        public int FamiliarEstudianteId { get; set; }
    }
}