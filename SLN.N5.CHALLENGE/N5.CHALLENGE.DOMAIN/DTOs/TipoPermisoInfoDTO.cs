﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.CHALLENGE.DOMAIN.DTOs
{
    public record TipoPermisoInfoDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
    }
}
