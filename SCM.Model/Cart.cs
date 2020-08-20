using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.Model
{
    public class Cart
    {
        public string CartId { get; set; } 
        public List<Item> Items { get; set; }
        public bool IsCheckOut { get; set; }

    }
}
