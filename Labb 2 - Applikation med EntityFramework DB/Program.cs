using Labb_2___Applikation_med_EntityFramework_DB.Models;
using System.Threading.Tasks.Dataflow;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;





//static void Main(string[] args)
   

{
    while (true)
    {
        Console.WriteLine("Välj ett alternativ:");
        Console.WriteLine("1. Lista på lagersaldo");
        Console.WriteLine("2. Lägg till bok i butik");
        Console.WriteLine("0. Avsluta");

        string val = Console.ReadLine();

        if (val == "1")
        {
            ListaLagersaldo();
        }
        else if (val == "2")
        {
            ExtraBok();
        }
        else if (val == "0")
        {
            break;
        }
        else
        {
            Console.WriteLine("Ogiltligt val. Försök igen.");
        }
    }
}



static void ListaLagersaldo()
{
    using (var context = new Labb1SqldatabasBokhandelContext())
    {
        // Hämta lagersaldo för alla böcker i alla butiker
        var Lagersaldo = context.LagerSaldos
            .Include(l => l.Butik) //Ladda butikens information
            .Include(l => l.IsbnNavigation.Författar) //Ladda butikens information
            .ToList();

        //skriv ut resultatet
        foreach (var item in Lagersaldo)
        {
            // Skriv ut titel, författare, butikens namn och lagersaldo
            Console.WriteLine($"Bok: {item.IsbnNavigation.Titel}, Författare: {item.IsbnNavigation.Författar?.FirstName} {item.IsbnNavigation.Författar?.LastName}, Butik: {item.Butik.ButiksNamn}, Lager: {item.Antal}");
            
        }
    }
}

static void ExtraBok()
{
    using (var context = new Labb1SqldatabasBokhandelContext())
    {
        // Hämta alla böcker
        var böcker = context.Böckers.ToList();
        Console.WriteLine("Välj en bok att lägga till:");
        Console.WriteLine("ISBN:          Titel:");
        foreach (var bok in böcker)
        {
            Console.WriteLine($"{bok.Isbn13}: {bok.Titel}");  // Använd ISBN för att visa boken
        }

        // Läs in bokens ISBN (detta kommer att vara användarens val)
        string val = Console.ReadLine();


        // Hämta den valda boken baserat på ISBN
        var valdBok = context.Böckers.FirstOrDefault(b => b.Isbn13 == val || b.Titel == val );
        if (valdBok == null)
        {
            Console.WriteLine("Ogiltig bok.");
            return;
        }

        // Hämta alla butiker
        var butiker = context.Butikers.ToList();
        Console.WriteLine("Välj butik:");
        foreach (var butik in butiker)
        {
            Console.WriteLine($"{butik.ButikId}: {butik.ButiksNamn}");
        }

        // Läs in butikens ID
        int butikId = int.Parse(Console.ReadLine());

        // Läs in lagerantal
        Console.WriteLine("Hur många vill du lägga till?");
        int lagerAntal = int.Parse(Console.ReadLine());


        var hittadLagerSaldo = context.LagerSaldos.FirstOrDefault(l => l.Isbn == valdBok.Isbn13);
        if (hittadLagerSaldo == null)
        {
            var NyttLagerSaldo = new LagerSaldo { Antal = lagerAntal, Isbn = valdBok.Isbn13, ButikId = butikId }; 
            context.LagerSaldos.Add(NyttLagerSaldo);
        }
        else
        {
            hittadLagerSaldo.Antal = lagerAntal;
        }

        context.SaveChanges();

        Console.WriteLine("Bok tillagd i butik!");
    }
}



