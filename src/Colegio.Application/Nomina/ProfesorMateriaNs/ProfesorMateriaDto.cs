using Abp.AutoMapper;
using Colegio.Models.Inscripcion.GeneralNs.MateriaNs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colegio.Nomina.ProfesorMateriaNs
{
    public class ProfesorMateriaDto
    {
        public int ProfesorMateriaId { get; set; }
        public int ProfesorId { get; set; }
        public int MateriaId { get; set; }
        public string MateriaNombre { get; set; }
        public string ProfesorNombre { get; set; }
    }
}
