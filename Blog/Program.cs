using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogg
{
    internal class Program
    {

        static string[] LäggInlägg()
        {
            string[] inlägg = new string[3]; // Inlägget inkluderar titel, meddelande och datum 
            for (int i = 0; i < inlägg.Length; i++) // loop kommer att fortsätta 3 gånger, index böjiar fråm 0 till 2 
            {
                if (i==0)
                {
                    Console.WriteLine("Lägg till titel");
                    inlägg[i] = Console.ReadLine(); // Lägg titel
                }
                else if (i==1)
                {
                    Console.WriteLine("Lägg till meddelande");
                    inlägg[i] = Console.ReadLine(); // Lägg meddelande
                }
                else
                    inlägg[i] = DateTime.Now.ToString("MMMM dd, yyyy"); // Lägg till dagens datum och format datum
            }

            return inlägg;
        }

        static void Main(string[] args)
        {
            bool isRunning = true;
            List<string[]> bloggLista = new List<string[]>();

            while (isRunning) // Loop kommer att fortsätta tills användaren bestämmer sig för att avsluta
            {
                Console.WriteLine("\nVälkommen till bloggen!");
                Console.WriteLine("[1] Skriv nytt inlägg i bloggen");
                Console.WriteLine("[2] Skriv ut alla blogginlägg");
                Console.WriteLine("[3] Sök inlägg i bloggen");
                Console.WriteLine("[4] Ta bort ett blogginlägg");
                Console.WriteLine("[5] Avsluta programmet");
                Console.Write("Välj: ");


                Int32.TryParse(Console.ReadLine(), out int input); // spara menyval och felhantering

                switch (input)
                {
                    case 1:
                        bloggLista.Add(LäggInlägg()); // Anropa en funktion för att lägga till ett inlägg
                        break;

                    case 2:
                        Console.WriteLine(bloggLista.ToString());
                        if (bloggLista.Count>0){
                            Console.WriteLine("Total:" + bloggLista.Count + " blogginlägg");

                            for (int i = 0; i < bloggLista.Count; i++) //Skriv ut alla  bloginlägg
                            {
                                Console.WriteLine("\ninlägg:" + (i+1) );
                                for (int j = 0; j < bloggLista[i].Length; j++) 
                                {
                                    if (j==0)
                                        Console.Write("Titel: ");
                                    else if (j==1)
                                        Console.Write("Mddelande: ");
                                    else
                                        Console.Write("Datum: ");


                                    Console.WriteLine(bloggLista[i][j]);
                                }
                            }

                        }
                        
                        break;

                    case 3:
                        Console.WriteLine("Ange sökord");
                        string sökOrd = Console.ReadLine(); //Användaren's matar
                        bool knapp = false; //Visa om element hittades eller inte

                        for (int i = 0; i < bloggLista.Count; i++)
                        {
                            if (bloggLista[i][0].ToLower() == sökOrd.ToLower())
                            {
                                knapp = true;
                                Console.WriteLine("Blogginlägg hittades");
                                for (int j = 0; j < bloggLista[i].Length; j++)
                                {
                                    if (j==0)
                                        Console.Write("\nTitel: ");
                                    else if (j==1)
                                        Console.Write("Mddelande: ");
                                    else
                                        Console.Write("Datum: ");
                                    Console.WriteLine(bloggLista[i][j]);
                                }
                            }
                        }
                        if (knapp== false) //om det inte finns i bloggLista
                        {
                            Console.WriteLine("Hittade inget blogginlägg");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Vilket inlägg vill du ta bort? Ange titel");
                        bool ärRaderad = false;
                        string inläggTitel = Console.ReadLine();
                        for (int i = 0; i < bloggLista.Count; i++)
                        {
                            if (bloggLista[i][0].ToLower() == inläggTitel.ToLower())
                            {
                                bloggLista.RemoveAt(i); // Ta bort inlägg (index i)
                                ärRaderad = true;
                                Console.WriteLine("Inlägg med " + inläggTitel +" har tagits bort");
                            }
                        }
                        if (ärRaderad== false) //om det inte finns i bloggLista
                        {
                            Console.WriteLine("Hittade inget blogginlägg");
                        }
                        break;

                    case 5:
                        isRunning = false; //Avsluta menyloopen
                        break;

                    default:
                        Console.WriteLine("Du måste välja  mellan menyval 1-4");
                        break;
                }

            }

            Console.ReadLine();
        }
    }
}
