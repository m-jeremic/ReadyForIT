using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BackendTest.Models;

namespace BackendTest.ViewModels
{
    public class StoreBindingTarget
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Addrese { get; set; }

        public Store ToStore()
        {
            Store st = new Store();               
            st.Name = this.Name;
            st.Addrese = this.Addrese;
            return st;
        }
    }
}
