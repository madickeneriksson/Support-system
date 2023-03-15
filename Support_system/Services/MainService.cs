using Support_system.Models;
using Support_system.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Support_system.Services
{
    internal class MainService
    {

        public  async Task CreateNewCaseAsync()
        {
            var customer = new Customer();
            var status = new Status();

            Console.WriteLine("Skapa ett nytt ärende: ");
            Console.Write("Kundens förnamn: ");
            customer.FirstName = Console.ReadLine() ?? "";

            Console.Write("Kundens efternamn: ");
            customer.LastName = Console.ReadLine() ?? "";

            Console.Write("Kundens E-post: ");
            customer.Email = Console.ReadLine() ?? "";

            Console.Write("Kundens telefonummer: ");
            customer.PhoneNumber = Console.ReadLine() ?? "";

            Console.Write("Titel på ärendet: ");
            customer.CaseTitle = Console.ReadLine() ?? "";

            Console.Write("Beskrivning av ärendet: ");
            customer.Description = Console.ReadLine() ?? "";
            

            // save customer and case to database
            await CasesService.SaveAsync(customer);
          

        }

        public async Task CommentSpecficCasesAsync()
        {
            Console.Write("Ange e-postadress på det ärende du vill kommentera: ");

            var email = Console.ReadLine();
            if (!string.IsNullOrEmpty(email))
            {
                var customer = await CasesService.GetAsync(email);
                var comment = new Comments();

                if (customer != null)
                {
                  

                    Console.WriteLine("Kommentera det aktuella ärendet. \n");

                    Console.Write($"Titel på kommentar:");
                    comment.TitleComment = Console.ReadLine() ?? "";
                    Console.Write($"Kommentar:");
                   comment.DescriptionComment = Console.ReadLine() ?? "";

                    // update specific customer and case from database
                   await CasesService.UpdateAsync(customer);
                    await CommentsService.SaveCommentAsync(comment, customer);

                    Console.WriteLine("Kommentar sparad.");
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

