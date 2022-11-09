using Microsoft.EntityFrameworkCore;
using TimeTicketApp.Domain;



namespace TimeTicketApp.Data
{
    public class TimeTicketContext : DbContext
    {
        public DbSet<Employee>  Employees { get; set; }
        public DbSet<TimeTicket> TimeTickets { get; set; }

        public string DbPath { get; set; }
        public TimeTicketContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "timetickets.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }
}