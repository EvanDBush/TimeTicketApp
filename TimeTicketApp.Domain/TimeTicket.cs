using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTicketApp.Domain
{
    public class TimeTicket
    {
        private Employee? employee;

        public int Id { get; set; }

        public decimal Hours { get; set; }

        public Employee? Employee { get => employee; set => employee = value; }

        public Project? Project { get => Project; set => Project = value; }

        public DateTime DateTime { get; set; }
    }
}
