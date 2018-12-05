﻿using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colegio.Inscripcion.EstudianteNs
{
    public interface IEstudianteAppService: IAsyncCrudAppService<EstudianteDto, int, PagedAndSortedResultRequestDto, EstudianteDto, EstudianteDto>
    {
        Task<PagedResultDto<EstudianteDto>> GetAllFiltered(PagedAndSortedResultRequestDto input, string filter);    
        List<EstudianteDto> GetAllForSelect();
        Task<EstudianteDto> GetIncluding(int estudianteId);
    }
}
