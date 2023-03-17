using Support_system.Models;
using Support_system.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Support_system.Services
{
    internal class CreateService
    {
        public async Task CreateNewCaseAsync()
        {
 
            var customer = new Customer();
            

            Console.WriteLine("Skapa ett nytt ärende: ");
            Console.Write("Kundens förnamn: ");
            customer.FirstName = Console.ReadLine() ?? "";

            Console.Write("Kundens efternamn: ");
            customer.LastName = Console.ReadLine() ?? "";

            Console.Write("Kundens E-post: ");
            customer.Email = Console.ReadLine() ?? "";

            Console.Write("Kundens telefonummer: ");
            customer.PhoneNumber = Console.ReadLine() ?? "";

            Console.Write("Kundens gatuadress: ");
            customer.StreetName = Console.ReadLine() ?? "";

            Console.Write("Kundens postnummer: ");
            customer.Postalcode = Console.ReadLine() ?? "";

            Console.Write("Kundens Stad: ");
            customer.City = Console.ReadLine() ?? "";

            Console.Write("Titel på ärendet: ");
            customer.CaseTitle = Console.ReadLine() ?? "";

            Console.Write("Beskrivning av ärendet: ");
            customer.Description = Console.ReadLine() ?? "";
          
        
            // save customer and case to database
            await CasesService.SaveAsync(customer);
          

        }

        public async Task CommentSpecficCasesAsync()
        {
            

            var employee = new Employee();

            Console.WriteLine("Anställd som kommenterar ärendet");
            Console.Write("Ditt förnamn: ");
            employee.FirstName = Console.ReadLine() ?? "";

            Console.Write("Ditt efternamn: ");
            employee.LastName = Console.ReadLine() ?? "";

            Console.Write("E-post: ");
            employee.Email = Console.ReadLine() ?? "";

            // save customer and case to database
            await CasesService.SaveAsync(employee);

            Console.Write("Ange e-postadress på det ärende du vill kommentera: ");

            var email = Console.ReadLine();
            if (!string.IsNullOrEmpty(email))
            {
                var customer = await CasesService.GetAsync(email);
                
                

                if (customer != null)
                {
                

                    Console.WriteLine("Kommentera det aktuella ärendet. \n");

                    Console.Write($"Kommentar:");
                    customer.UpdateComment = Console.ReadLine() ?? "";
                    Console.WriteLine($"{customer.UpdatedAt}");

                    // update specific customer and case from database
                    await CasesService.UpdateAsync(customer);
                    Console.WriteLine("");
                    Console.WriteLine("Kommentar sparad.");

                    Console.WriteLine("Välj status.");

                    

                 

                    await CasesService.SaveAsync(customer);

                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ingen e-postadress angiven");
            }
        }

    }
}

