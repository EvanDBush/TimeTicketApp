using System.Runtime.CompilerServices;
using System.Xml.Linq;
using TimeTicketApp.Data;
using TimeTicketApp.Domain;

TimeTicketContext _context = new();
AddEmployeesByName("Steve", "Mary");
//GetEmployees();
Console.Write("Press any key...");
Console.ReadKey();

/*static void AddVariousTypes()
{
    _context.Employees.AddRange(
        new Employee { FirstName = "Steve" },
        new Employee { FirstName = "Mary" });
    _context.Projects.AddRange(
       new Project { Name = "NewBarRenovation" },
       new Project { Name = "RestaurantTableBuild" });
    _context.SaveChanges();
}*/

void AddEmployeesByName(params string[] names)
{
    foreach (string name in names)
    {
        _context.Employees.Add(new Employee { FirstName = name });
    }
    _context.SaveChanges();
}


