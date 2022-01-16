using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTest.Models
{
    [Table("Store")]
    public class Store
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Addrese { get; set; }


    }
}
