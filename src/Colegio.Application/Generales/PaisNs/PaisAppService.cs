using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using AutoMapper;
using Colegio.Authorization;
using Colegio.Generales.PaisNs;
using Colegio.Models.Generales.PaisNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.PaisNs
{
    public class PaisAppService : AsyncCrudAppService<Pais, PaisDto, int, PagedAndSortedResultRequestDto, PaisDto, PaisDto>, IPaisAppService
    {
        private readonly IPaisManager _paisManager;
        
        public PaisAppService(IRepository<Pais> repository, IPaisManager paisManager)
            :base(repository)
        {
            _paisManager = paisManager;
        }

        #region Using Managers
        //public override async Task<PaisDto> Create(PaisDto input)
        //{

        //    var output = Mapper.Map<PaisDto, Pais>(input);

        //    await _paisManager.Create(output);

        //    return MapToEntityDto(output);

        //}

        //public override async Task<PaisDto> Update(PaisDto input)
        //{
        //    Pais output = Mapper.Map<PaisDto, Pais>(input);

        //    await _paisManager.Update(output);

        //    return MapToEntityDto(output);
        //}
        #endregion

        public Task<PagedResultDto<PaisDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var paisList = new List<Pais>();
            var query = Repository.GetAll();

            if (filter != null && filter != string.Empty)
            {
                paisList = query
                    .Where(x => x.Identificador.StartsWith(filter) || x.Nombre.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<PaisDto>(query.Count(), ObjectMapper.Map<List<PaisDto>>(paisList));
                return Task.FromResult(result);
            }
            else
            {
                return base.GetAll(input);
            }
        }

        protected override IQueryable<Pais> ApplySorting(IQueryable<Pais> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

    }
}
