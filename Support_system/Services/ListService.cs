using Support_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Support_system.Services
{
    internal class ListService
    {
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
                    Console.WriteLine($" Förnamn: {customer.FirstName}");
                    Console.WriteLine($" Efternamn: {customer.LastName}");
                    Console.WriteLine($" Email: {customer.Email}");
                    Console.WriteLine($" Telefonummer: {customer.PhoneNumber}");
                    Console.WriteLine($" Adress: {customer.StreetName}, {customer.Postalcode} {customer.City}");

                    Console.WriteLine($" Titel på ärende: {customer.CaseTitle}");
                    Console.WriteLine($" Beskrivning av ärendet: {customer.Description}");
                    Console.WriteLine($" Ärendet skapat: {customer.CreatedAt}");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    //Eventuell kommentar
                    Console.WriteLine($"{customer.UpdateComment}");


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
                    Console.WriteLine($" Förnamn: {customer.FirstName}");
                    Console.WriteLine($" Efternamn: {customer.LastName}");
                    Console.WriteLine($" Email: {customer.Email}");
                    Console.WriteLine($" Telefonummer: {customer.PhoneNumber}");
                    Console.WriteLine($" Adress: {customer.StreetName}, {customer.Postalcode} {customer.City}");
                    Console.WriteLine($" Titel på ärende: {customer.CaseTitle}");
                    Console.WriteLine($" Beskrivning av ärendet: {customer.Description} ");
                    Console.WriteLine($" Skapat: {customer.CreatedAt}");
                   
                    Console.WriteLine("");
                    //Eventuell kommentar
                    Console.WriteLine($"{customer.UpdateComment}");

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
    }
}
