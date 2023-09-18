using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class ProductDto
    {
        public string ProductCode { get; set; }
        //Display once product is selected
        public string ProductDescription { get; set; }
        //Select from a product list
        public decimal Qty { get; set; }
        //Quantity of items to be delivered. In the case of bulk cargo, this can be a decimal value.
    }
}
