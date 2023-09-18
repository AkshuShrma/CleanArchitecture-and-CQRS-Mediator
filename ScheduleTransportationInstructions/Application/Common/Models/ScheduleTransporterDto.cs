using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class ScheduleTransporterDto
    {
        public int ScheduleTransportID { get; set; }
        public DateTime DateScheduled { get; set; }
        //Auto populate but allow for changes
        public string Transporter { get; set; }
        //Select from a list of transporters        
        public int InstructionId { get; set; }
        public int ProductId { get; set; }
    }
}
