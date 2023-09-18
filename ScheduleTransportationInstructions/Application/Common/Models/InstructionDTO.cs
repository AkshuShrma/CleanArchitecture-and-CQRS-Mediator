using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.Common.Models
{
    public class InstructionDTO
    {        
        public DateTime InstructionDate { get; set; } = DateTime.Now;
        //Auto populate but allow for changes
       
        public string ClientName { get; set; }
        //Select from a client list
       
        public string PickupAddress { get; set; }

        public string DeliveryAddress { get; set; }

        //Client reference
        public string ClientRef { get; set; }

        public string BillingRef { get; set; }
        //Billing references are used to obtain charge rates
        public List<ProductDto> Products { get; set; }
    }
}
