using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Models.Inscripcion.InscripcionNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.Incripcion.InscripcionNs
{
    public class InscripcionAppService : AsyncCrudAppService<Inscripcion, InscripcionDto, int, PagedAndSortedResultRequestDto, InscripcionDto, InscripcionDto>, IInscripcionAppService
    {
        public InscripcionAppService(IRepository<Inscripcion> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<InscripcionDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<Inscripcion>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Estudiante.Identificador.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<InscripcionDto>(query.Count(), ObjectMapper.Map<List<InscripcionDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<InscripcionDto>(query.Count(), ObjectMapper.Map<List<InscripcionDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<Inscripcion> ApplySorting(IQueryable<Inscripcion> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<InscripcionDto> GetAllForSelect()
        {
            var paisList = new List<Inscripcion>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<InscripcionDto>(ObjectMapper.Map<List<InscripcionDto>>(paisList));
        }
    }
}
