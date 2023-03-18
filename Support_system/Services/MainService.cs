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
            Console.WriteLine("Välj status:");
            Console.WriteLine(" 1 = Ej Påbörjad / 2 = Påbörjad / 3 = Avslutad: ");
            var inputanswer = Console.ReadLine();
            if (inputanswer == "1") 
            {
                customer.Status = "Ej påbörjat";
            }
            else if (inputanswer == "2")
            {
                customer.Status = "Påbörjat";
            }
            else if (inputanswer == "3") 
            {
                customer.Status = "Avslutat";
            }
           Console.WriteLine("Ärendet sparat.");

            // save to database
            await CasesService.SaveAsync(customer);
        }

        public async Task ListAllCasesAsync()
        {
            // Get all customers+case fron database
            var customers = await CasesService.GetAllAsync();

            // spara in i variabel

            if (customers.Any())
            {
                foreach (Customer customer in customers)
                {
                    Console.WriteLine($" Kundnummer: {customer.Id}");
                    Console.WriteLine($" Namn: {customer.FirstName} {customer.LastName}");
                    Console.WriteLine($" Email: {customer.Email}");
                    Console.WriteLine($" Telefonummer: {customer.PhoneNumber}");
                    Console.WriteLine($" Adress: {customer.StreetName}, {customer.Postalcode} {customer.City}");
                    Console.WriteLine($" Titel på ärende: {customer.CaseTitle}");
                    Console.WriteLine($" Beskrivning av ärendet: {customer.Description}");
                    Console.WriteLine($" Ärendet skapat: {customer.CreatedAt}");
                    Console.WriteLine($" Status: {customer.Status}");
                    Console.WriteLine("");
                    //Eventuell kommentar
                    Console.WriteLine($"{customer.UpdateComment} {customer.UpdatedAt}");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Inga ärenden finns i databasen. ");
                Console.WriteLine("");
            }
        }

        public async Task ListSpecficCasesAsync()
        {
            Console.Write("Ange e-postadress på den kund du vill hämta ärende på ");

            var email = Console.ReadLine();
            if (!string.IsNullOrEmpty(email))
            {
                // Get specific customers+address fron database
                var customer = await CasesService.GetAsync(email);


                if (customer != null)
                {
                    Console.WriteLine($" Kundnummer: {customer.Id}");
                    Console.WriteLine($" Namn: {customer.FirstName} {customer.LastName}");
                    Console.WriteLine($" Email: {customer.Email}");
                    Console.WriteLine($" Telefonummer: {customer.PhoneNumber}");
                    Console.WriteLine($" Adress: {customer.StreetName}, {customer.Postalcode} {customer.City}");
                    Console.WriteLine($" Titel på ärende: {customer.CaseTitle}");
                    Console.WriteLine($" Beskrivning av ärendet: {customer.Description} ");
                    Console.WriteLine($" Skapat: {customer.CreatedAt}");
                    Console.WriteLine($" Status: {customer.Status}");
                    Console.WriteLine("");
                    //Eventuell kommentar
                    Console.WriteLine($"{customer.UpdateComment} {customer.UpdatedAt}");
                    Console.WriteLine("");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Ingen kund med e-postadressen {email} hittades");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ingen e-postadress angiven");
            }
        }
        public async Task CommentSpecficCasesAsync()
        {

            Console.Write("Ange e-postadress på det ärende du vill kommentera: ");
            Console.WriteLine("");
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
                    Console.WriteLine("");
                    Console.WriteLine("Uppdatera status:");
                    Console.WriteLine(" 1 = Ej Påbörjad / 2 = Påbörjad / 3 = Avslutad: ");
                    var inputanswer = Console.ReadLine();
                    if (inputanswer == "1")
                    {
                        customer.Status = "Ej påbörjat";
                    }
                    else if (inputanswer == "2")
                    {
                        customer.Status = "Påbörjat";
                    }
                    else if (inputanswer == "3")
                    {
                        customer.Status = "Avslutat";
                    }
                }
                // update specific from database
                await CasesService.UpdateAsync(customer);
                Console.WriteLine("Uppdaterat");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ingen e-postadress angiven");
            }
        }

        public async Task UpdateSpecficCasesAsync()
            {
                Console.Write("Ange e-postadress på den kund ändra uppgifterna kring ärendet på: ");

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

                        Console.Write("Kundens gatuadress: ");
                        customer.StreetName = Console.ReadLine() ?? "";

                        Console.Write("Kundens postnummer: ");
                        customer.Postalcode = Console.ReadLine() ?? "";

                        Console.Write("Kundens Stad: ");
                        customer.City = Console.ReadLine() ?? "";

                        Console.Write("Titel på ditt ärende: ");
                        customer.CaseTitle = Console.ReadLine() ?? "";

                        Console.Write("Beskrivning av ditt ärende: ");
                        customer.Description = Console.ReadLine() ?? "";

                        // update specific  from database
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
                    // delete from database
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

