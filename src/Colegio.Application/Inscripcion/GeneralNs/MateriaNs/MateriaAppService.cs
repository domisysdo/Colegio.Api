using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Models.Inscripcion.GeneralNs.MateriaNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.Incripcion.MateriaNs
{
    public class MateriaAppService : AsyncCrudAppService<Materia, MateriaDto, int, PagedAndSortedResultRequestDto, MateriaDto, MateriaDto>, IMateriaAppService
    {
        public MateriaAppService(IRepository<Materia> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<MateriaDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<Materia>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Nombre.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<MateriaDto>(query.Count(), ObjectMapper.Map<List<MateriaDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<MateriaDto>(query.Count(), ObjectMapper.Map<List<MateriaDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<Materia> ApplySorting(IQueryable<Materia> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<MateriaDto> GetAllForSelect()
        {
            var paisList = new List<Materia>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<MateriaDto>(ObjectMapper.Map<List<MateriaDto>>(paisList));
        }
    }
}
