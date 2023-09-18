using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class GetInstructionDTO
    {
        public int Id { get; set; }
        public DateTime InstructionDate { get; set; }= DateTime.Now;
        //Auto populate but allow for changes

        public string ClientName { get; set; }
        //Select from a client list

        public string PickupAddress { get; set; }

        public string DeliveryAddress { get; set; }

        //Client reference
        public string ClientRef { get; set; }

        public string BillingRef { get; set; }
        public string Status { get; set; }
        //Billing references are used to obtain charge rates        
        public List<GetProductDTO> Products { get; set; }
    }
}
