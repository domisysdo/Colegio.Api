using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Inscripcion.MateriaNs;
using Colegio.Models.Inscripcion.GeneralNs.GrupoNs;

namespace Colegio.Inscripcion.GrupoNs
{
    [AutoMap(typeof(Grupo))]
    public class GrupoDto: EntityDto<int>
    {
        public string Identificador { get; set; }
        public int MateriaId { get; set; }
        public MateriaDto Materia { get; set; }
    }
}