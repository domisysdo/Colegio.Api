using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Models.Inscripcion.GeneralNs.GrupoNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.Incripcion.GrupoNs
{
    public class GrupoAppService : AsyncCrudAppService<Grupo, GrupoDto, int, PagedAndSortedResultRequestDto, GrupoDto, GrupoDto>, IGrupoAppService
    {
        public GrupoAppService(IRepository<Grupo> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<GrupoDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<Grupo>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Identificador.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<GrupoDto>(query.Count(), ObjectMapper.Map<List<GrupoDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<GrupoDto>(query.Count(), ObjectMapper.Map<List<GrupoDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<Grupo> ApplySorting(IQueryable<Grupo> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<GrupoDto> GetAllForSelect()
        {
            var paisList = new List<Grupo>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<GrupoDto>(ObjectMapper.Map<List<GrupoDto>>(paisList));
        }

        public List<GrupoDto> GetAllForSelectByMateria(int materiaId)
        {
            var paisList = new List<Grupo>();

            var query = Repository.GetAll()
                .Where(x => x.MateriaId == materiaId);
            paisList = query.ToList();

            return new List<GrupoDto>(ObjectMapper.Map<List<GrupoDto>>(paisList));
        }
    }
}
