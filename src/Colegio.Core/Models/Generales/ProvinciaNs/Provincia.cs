﻿using Abp.Domain.Entities.Auditing;
using Colegio.Models.Generales.PaisNs;

namespace Colegio.Models.Generales.ProvinciaNs
{
    public class Provincia:  FullAuditedEntity<int>
    {
        public string Identificador { get; set; }
        public string Nombre { get; set; }
        public int PaisId { get; set; }
        public virtual Pais Pais { get; set; }

    }
}