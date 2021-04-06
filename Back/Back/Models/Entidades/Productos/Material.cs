﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Models.Entidades.Productos
{
    public class Material
    {
        [Key]
        public int IdMaterial   { get; set; }
        [Column(TypeName ="varchar(150)"), Required]
        public string Nombre{ get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string IdUsuario  { get; set; }
    }
}