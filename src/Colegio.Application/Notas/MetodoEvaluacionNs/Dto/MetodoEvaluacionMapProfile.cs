using AutoMapper;
using Colegio.Models.Notas.MetodoEvaluacionNs;
using Colegio.Notas.DetalleMetodoEvaluacionNs;
using Colegio.Notas.MetodoEvaluacionNs;

namespace Colegio.Generales.MetodoEvaluacionNs.Dto
{
    public class MetodoEvaluacionMapProfile: Profile
    {
        public MetodoEvaluacionMapProfile()
        {
            CreateMap<MetodoEvaluacionDto, MetodoEvaluacion>();
            CreateMap<MetodoEvaluacion, MetodoEvaluacionDto>();

            CreateMap<DetalleMetodoEvaluacionDto, DetalleMetodoEvaluacion>();
            CreateMap<DetalleMetodoEvaluacion, DetalleMetodoEvaluacionDto>();
        }
    }
}
