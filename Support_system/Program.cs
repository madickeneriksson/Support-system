using Support_system.Services;

var main = new CreateService();
var list = new ListService();
var update = new UpdateDeleteService();


while (true)
{

    Console.Clear();
    Console.WriteLine("SUPPORTSYSTEM");
    Console.WriteLine("");
    Console.WriteLine("1. Skapa ett nytt ärende");
    Console.WriteLine("2. Visa alla ärenden");
    Console.WriteLine("3. Visa ett specifikt ärende");
    Console.WriteLine("4. Uppdatera ett specifikt ärende");
    Console.WriteLine("5. Kommentera ett specifikt ärende");
    Console.WriteLine("");
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
            await list.ListAllCasesAsync();
            break;

        case "3":
            Console.Clear();
            await list.ListSpecficCasesAsync();
            break;

        case "4":
            Console.Clear();
            await update.UpdateSpecficCasesAsync();
            break;

        case "5":
            Console.Clear();
            await main.CommentSpecficCasesAsync();
            break;

        case "6":
            Console.Clear();
            await update.DeleteSpecficCasesAsync();
            break;
    }

    Console.WriteLine("\nTryck på valfri knapp för att fortsätta");
    Console.ReadKey();
}


