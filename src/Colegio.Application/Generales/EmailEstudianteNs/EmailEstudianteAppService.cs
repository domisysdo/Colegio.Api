using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Colegio.Generales.EmailEstudianteNs;
using Colegio.Models.Generales.EmailEstudianteNs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.EmailEstudianteNs
{
    public class EmailEstudianteAppService : AsyncCrudAppService<EmailEstudiante, EmailEstudianteDto, int, PagedAndSortedResultRequestDto, EmailEstudianteDto, EmailEstudianteDto>, IEmailEstudianteAppService
    {
        public EmailEstudianteAppService(IRepository<EmailEstudiante> repository)
            : base(repository)
        {
        }

        public Task<PagedResultDto<EmailEstudianteDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter)
        {
            var provinciaList = new List<EmailEstudiante>();
            var query = Repository.GetAll();

            query = ApplySorting(query, input);


            if (filter != null && filter != string.Empty)
            {
                provinciaList = query
                    .Where(x => x.Email.StartsWith(filter))
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList();

                var result = new PagedResultDto<EmailEstudianteDto>(query.Count(), ObjectMapper.Map<List<EmailEstudianteDto>>(provinciaList));
                return Task.FromResult(result);
            }
            else
            {
                provinciaList = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount).ToList()
                    .ToList();

                var result = new PagedResultDto<EmailEstudianteDto>(query.Count(), ObjectMapper.Map<List<EmailEstudianteDto>>(provinciaList));
                return Task.FromResult(result);
            }
        }

        protected override IQueryable<EmailEstudiante> ApplySorting(IQueryable<EmailEstudiante> query, PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                input.Sorting = "Identificador asc";
            }
            return base.ApplySorting(query, input);
        }

        public List<EmailEstudianteDto> GetAllForSelect()
        {
            var paisList = new List<EmailEstudiante>();

            var query = Repository.GetAll();
            paisList = query.ToList();

            return new List<EmailEstudianteDto>(ObjectMapper.Map<List<EmailEstudianteDto>>(paisList));
        }
    }
}
