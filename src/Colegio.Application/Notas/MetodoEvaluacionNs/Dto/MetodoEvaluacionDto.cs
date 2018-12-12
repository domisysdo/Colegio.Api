using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Notas.MetodoEvaluacionNs;
using Colegio.Notas.DetalleMetodoEvaluacionNs;
using System.Collections.Generic;

namespace Colegio.Notas.MetodoEvaluacionNs
{
    [AutoMap(typeof(MetodoEvaluacion))]
    public class MetodoEvaluacionDto: EntityDto<int>
    {
        public string Descripcion { get; set; }
        public List<DetalleMetodoEvaluacionDto> ListaMetodoEvaluacion { get; set; }
    }
}