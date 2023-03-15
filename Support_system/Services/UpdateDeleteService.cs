using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Support_system.Services
{
    internal class UpdateDeleteService
    {
        public async Task UpdateSpecficCasesAsync()
        {
            Console.Write("Ange e-postadress på den kund du vill uppdatera ärendet på: ");

            var email = Console.ReadLine();
            if (!string.IsNullOrEmpty(email))
            {
                var customer = await CasesService.GetAsync(email);


                if (customer != null)
                {

                    Console.WriteLine("Uppdatera det aktuella fältet. \n");

                    Console.Write("Förnamn: ");
                    customer.FirstName = Console.ReadLine() ?? "";

                    Console.Write("Efternamn: ");
                    customer.LastName = Console.ReadLine() ?? "";

                    Console.Write("E-post: ");
                    customer.Email = Console.ReadLine() ?? "";

                    Console.Write("Telefonummer: ");
                    customer.PhoneNumber = Console.ReadLine() ?? "";

                    Console.Write("Titel på ditt ärende: ");
                    customer.CaseTitle = Console.ReadLine() ?? "";

                    Console.Write("Beskrivning av ditt ärende: ");
                    customer.Description = Console.ReadLine() ?? "";

                    // update specific customer and case from database
                    await CasesService.UpdateAsync(customer);

                    Console.WriteLine("Uppdaterat");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ingen e-postadress angiven");
            }
        }
        public async Task DeleteSpecficCasesAsync()
        {
            Console.Write("Ange e-postadress på den kund du vill ta bort ärendet på: ");
            var email = Console.ReadLine();
            Console.WriteLine("Vill du ta bort ärendet kopplat till mejladressen " + email + " från listan? ");
            Console.Write("j = ja. n = nej.");
            var inputanswer = Console.ReadLine();

            if (inputanswer == "j")
            {
                // delete specific customer fron database
                await CasesService.DeleteAsync(email);
                Console.WriteLine("Ärendet har tagits bort");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ingen e-postadress angiven");
            }
        }
    }

}
