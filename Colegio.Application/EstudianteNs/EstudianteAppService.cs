using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using AutoMapper;
using Colegio.Authorization;
using Colegio.Authorization.Roles;
using Colegio.Models.EstudianteNs;
using Colegio.Roles.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.EstudianteNs
{
    [AbpAuthorize(PermissionNames.Pages_Estudiante)]
    public class EstudianteAppService : AsyncCrudAppService<Estudiante, EstudianteDto, int, PagedResultRequestDto, EstudianteDto, EstudianteDto>, IEstudianteAppService
    {
        private readonly IEstudianteManager _estudianteManager;
        private readonly IRepository<Role> _roleRepository;

        public EstudianteAppService(IRepository<Estudiante> repository, IEstudianteManager estudianteManager, IRepository<Role> roleRepository)
            :base(repository)
        {
            _estudianteManager = estudianteManager;
            _roleRepository = roleRepository;
        }

        public override async Task<EstudianteDto> Create(EstudianteDto input)
        {

            var output = Mapper.Map<EstudianteDto, Estudiante>(input);

            await _estudianteManager.Create(output);

            return MapToEntityDto(output);

        }

        public override async Task<EstudianteDto> Update(EstudianteDto input)
        {
            Estudiante output = Mapper.Map<EstudianteDto, Estudiante>(input);

            await _estudianteManager.Update(output);

            return MapToEntityDto(output);
        }

        public async Task<ListResultDto<RoleDto>> GetRoles()
        {
            var roles = await _roleRepository.GetAllListAsync();
            return new ListResultDto<RoleDto>(ObjectMapper.Map<List<RoleDto>>(roles));
        }
    }
}
