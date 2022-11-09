using Microsoft.EntityFrameworkCore;
using TimeTicketApp.Domain;



namespace TimeTicketApp.Data
{
    public class TimeTicketContext : DbContext
    {
        public DbSet<Employee>  Employees { get; set; }
        public DbSet<TimeTicket> TimeTickets { get; set; }

        public string DbPath { get; }
        public TimeTicketContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "timeticket.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}