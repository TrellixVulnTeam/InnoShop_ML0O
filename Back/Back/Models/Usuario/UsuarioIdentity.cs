﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Models.Usuario
{
    public class UsuarioIdentity : IdentityUser
    {
        [Column(TypeName = "nvarchar(40)")]
        public string Nombre { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Direccion { get; set; }
    }
}
