using Entity.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Product :BaseEntity
    {
        public String Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }

}
