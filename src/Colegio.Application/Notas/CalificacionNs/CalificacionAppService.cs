using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Repositories;
using Abp.Extensions;
using Colegio.Generales.CalificacionNs;
using Colegio.Models.Notas.CalificacionNs;
using Colegio.Notas.CalificacionNs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.CalificacionNs
{
    public class CalificacionAppService : AsyncCrudAppService<Calificacion, CalificacionDto, int, PagedAndSortedResultRequestDto, CalificacionDto, CalificacionDto>, ICalificacionAppService
    {
        public CalificacionAppService(IRepository<Calificacion> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<CalificacionDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var CalificacionList = new List<Calificacion>();
            var query = Repository.GetAllIncluding(x => x.Materia, x => x.Grupo, x => x.Estudiante, x => x.DetalleMetodoEvaluacion);

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                CalificacionList = query
                    .Where(x => x.Estudiante.Identificador.StartsWith(filter) ||
                                x.Estudiante.Nombres.StartsWith(filter) ||
                                x.Estudiante.PrimerApellido.StartsWith(filter) ||
                                x.Estudiante.SegundoApellido.StartsWith(filter) ||
                                x.Grupo.Identificador.StartsWith(filter) ||
                                x.Materia.Identificador.StartsWith(filter) ||
                                x.Materia.Nombre.StartsWith(filter)
                    )
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<CalificacionDto>(query.Count(), ObjectMapper.Map<List<CalificacionDto>>(CalificacionList));
                return Task.FromResult(result);
            }
            else
            {

                CalificacionList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<CalificacionDto>(query.Count(), ObjectMapper.Map<List<CalificacionDto>>(CalificacionList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<Calificacion> ApplySorting(IQueryable<Calificacion> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Estudiante.Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

       
        public List<CalificacionDto> GetAllForSelect()
        {
            var CalificacionList = new List<Calificacion>();

            var query = Repository.GetAll();
            CalificacionList = query.ToList();

            return new List<CalificacionDto>(ObjectMapper.Map<List<CalificacionDto>>(CalificacionList));
        }   
       
    }
}
