using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTest.Models
{
    [Table("ProductSku")]
    public class ProductSku
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public long Sku { get; set; }

    }
}
