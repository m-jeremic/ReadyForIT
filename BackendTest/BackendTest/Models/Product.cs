using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTest.Models
{
    [Table("Product")]
    public class Product
    {       
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public virtual IEnumerable<ProductSku> ProductSkus { get; set; }

        
    }
}
