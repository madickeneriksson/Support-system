using Support_system.Services;

var main = new MainService();

while (true)
{

    Console.Clear();
    Console.WriteLine("SUPPORTSYSTEM");
    Console.WriteLine("");
    Console.WriteLine("1. Skapa ett nytt ärende");
    Console.WriteLine("2. Visa alla ärenden");
    Console.WriteLine("3. Visa ett specifikt ärende");
    Console.WriteLine("4. Kommentera/Ändra status på ett specifikt ärende");
    Console.WriteLine("");
    Console.WriteLine("5. Uppdatera kunduppgifter på ett ärende");
    Console.WriteLine("6. Ta bort ett felaktigt ärende");
    Console.Write("Välj ett alternativ: ");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Clear();
            await main.CreateNewCaseAsync();
            break;

        case "2":
            Console.Clear();
            await main.ListAllCasesAsync();
            break;

        case "3":
            Console.Clear();
            await main.ListSpecficCasesAsync();
            break;

        case "4":
            Console.Clear();
            await main.CommentSpecficCasesAsync();
            break;

        case "5":
            Console.Clear();
            await main.UpdateSpecficCasesAsync();
            break;

        case "6":
            Console.Clear();
            await main.DeleteSpecficCasesAsync();
            break;
    }

    Console.WriteLine("\nTryck på valfri knapp för att fortsätta");
    Console.ReadKey();
}


