using Entity.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Option :BaseEntity
    {
        public String Title { get; set; }
        public String Description { get; set; }
        public ICollection<Product> Products;
        public ICollection<Discount> Discounts { get; set; }


    }
}
