using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTest.Models
{
    [Table("Stock")]
    public class Stock
    {
        public int Id { get; set; }

        public int StoreId { get; set; }

        public int ProductSkuId { get; set; }

        public int Quantity { get; set; }

        public int WebPrice { get; set; }

    }
}
