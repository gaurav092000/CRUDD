using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models
{
    public class Product
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public int Quatity { get; set; }

        public float Price { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsUpdated { get; set; }

    }
}