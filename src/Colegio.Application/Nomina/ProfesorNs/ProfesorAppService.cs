using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Nomina.ProfesorNs;
using Colegio.Models.Generales.PaisNs;
using Colegio.Models.Nomina.ProfesorNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.ProfesorNs
{
    public class ProfesorAppService : AsyncCrudAppService<Profesor, ProfesorDto, int, PagedAndSortedResultRequestDto, ProfesorDto, ProfesorDto>, IProfesorAppService
    {
        readonly IRepository<Pais> _paisRepository;
        public ProfesorAppService(IRepository<Profesor> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<ProfesorDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var profesorList = new List<Profesor>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                profesorList = query
                    .Where(x => x.Identificador.StartsWith(filter) || x.Nombres.StartsWith(filter) || x.PrimerApellido.StartsWith(filter) || x.SegundoApellido.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<ProfesorDto>(query.Count(), ObjectMapper.Map<List<ProfesorDto>>(profesorList));
                return Task.FromResult(result);
            }
            else
            {
                profesorList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<ProfesorDto>(query.Count(), ObjectMapper.Map<List<ProfesorDto>>(profesorList));
                return Task.FromResult(result);
            }
        }


        protected override IQueryable<Profesor> ApplySorting(IQueryable<Profesor> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<ProfesorDto> GetAllForSelect()
        {
            var profesorList = new List<Profesor>();

            var query = Repository.GetAll();
            profesorList = query.ToList();

            return new List<ProfesorDto>(ObjectMapper.Map<List<ProfesorDto>>(profesorList));

        }
    }
}
