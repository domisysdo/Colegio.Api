using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Inscripcion.GeneralNs.ParentescoNs;

namespace Colegio.Incripcion.ParentescoNs
{
    [AutoMap(typeof(Parentesco))]
    public class ParentescoDto: EntityDto<int>
    {
        public string Descripcion { get; set; }
    }
}