using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTicketApp.Domain
{
    public class TimeTicket
    {
        public int Id { get; set; }

        public decimal Hours { get; set; }

        public Employee? Employee { get; set; }

        public Project? Project { get; set; }

        public DateTime? DateTime { get; set; }
    }
}
