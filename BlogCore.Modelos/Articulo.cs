﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.Modelos
{
 public   class Articulo
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage ="El nombre es obligatorio")]
        [Display(Name ="Nomple del Articulo")]
        public string Nombre { get; set; }


        public string Descripcion { get; set; }

        [Display(Name ="Fecha Creacion")]
        public string FechaCreacion { get; set; }

        [Display(Name ="Imagen")]
        public string UrlImagen { get; set; }

        [Display(Name ="La categoria es obligatoria")]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")] 
        public Categoria Categoria { get; set; }



    }
}
