using Support_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Support_system.Services
{
    internal class MainService
    {
        public async Task CreateNewCaseAsync()
        {
            var employee = new Employee();

            Console.WriteLine("Anställd");
            Console.Write("Ditt förnamn: ");
            employee.FirstName = Console.ReadLine() ?? "";

            Console.Write("Ditt efternamn: ");
            employee.LastName = Console.ReadLine() ?? "";

            Console.Write("Kundens E-post: ");
            employee.Email = Console.ReadLine() ?? "";

            // save customer and case to database
            await CasesService.SaveAsync(employee);
        }
    }

}
