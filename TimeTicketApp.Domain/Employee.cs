using System.Collections.Generic;

namespace TimeTicketApp.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? EMail { get; set; }

        public decimal TaxWithholding { get; set; }

        public decimal HourlyRate { get; set; }

        public List<TimeTicket> TimeTickets { get; set; } = new List<TimeTicket>();
    }
}