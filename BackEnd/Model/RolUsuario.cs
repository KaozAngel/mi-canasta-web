﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Model
{
    public class RolUsuario
    {
        public string Dni { get; set; }
        public Usuario Usuario { get; set; }
        public int RolPerfilId { get; set; }
        public RolPerfil RolPerfil { get; set; }

    }
}
