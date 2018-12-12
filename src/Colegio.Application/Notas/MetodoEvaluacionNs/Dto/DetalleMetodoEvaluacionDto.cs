using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Notas.MetodoEvaluacionNs;
using System.Collections.Generic;

namespace Colegio.Notas.DetalleMetodoEvaluacionNs
{
    [AutoMap(typeof(DetalleMetodoEvaluacion))]
    public class DetalleMetodoEvaluacionDto: EntityDto<int>
    {
        public int MetodoEvaluacionId { get; set; }
        public string Descripcion { get; set; }
        public double Puntuacion { get; set; }
    }
}