using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Generales.AulaNs;

namespace Colegio.Generales.AulaNs
{
    [AutoMap(typeof(Aula))]
    public class AulaDto : EntityDto<int>
    {
        public string Identificador { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
    }
}