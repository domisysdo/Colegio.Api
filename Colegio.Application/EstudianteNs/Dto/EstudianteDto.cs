using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Colegio.Enums;
using Colegio.Models.EstudianteNs;

namespace Colegio.EstudianteNs
{
    [AutoMap(typeof(Estudiante))]
    public class EstudianteDto: EntityDto<int>//, IShouldNormalize
    {
        public string Nombres { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public Estado Estado { get; set; }
        //public void Normalize()
        //{
        //    if (RoleNames == null)
        //    {
        //        RoleNames = new string[0];
        //    }
        //}
    }
}