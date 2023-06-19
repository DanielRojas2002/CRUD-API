﻿using Newtonsoft.Json;

namespace CRUD.Models.ViewModels
{
   
    public class ProductoVM
    {
      
        public string CodigoBarra { get; set; }

        public string Nombre { get; set; }

        public string Marca { get; set; }


        public string Categoria { get; set; }


        public decimal Precio { get; set; }
    }
}
