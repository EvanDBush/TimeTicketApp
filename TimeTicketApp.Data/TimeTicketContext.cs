using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TimeTicketApp.Domain;



namespace TimeTicketApp.Data
{
    public class TimeTicketContext : DbContext
    {
        public DbSet<Employee>  Employees { get; set; }
        public DbSet<TimeTicket> TimeTickets { get; set; }

        public DbSet<Project> Projects { get; set; }

        public string DbPath { get; set; }
        public TimeTicketContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "timetickets.db");
        }
        
        private StreamWriter _writer
            = new("EFCoreLog.txt", append: true);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite($"Data Source={DbPath}")
                .LogTo(_writer.WriteLine, new[] {DbLoggerCategory.Database.Command.Name},
                LogLevel.Information)
                .EnableSensitiveDataLogging();
        }
    }
}