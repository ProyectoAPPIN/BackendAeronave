﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mercaderia.bono.Entidades.Dto
{
    public class UsuarioActivoDto
    {
        public string codUsuario { get; set; }
        public string codigoActivacion { get; set; }
        public bool? activo { get; set; }
    }
}
