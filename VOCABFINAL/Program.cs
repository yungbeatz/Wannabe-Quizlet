using System;
using System.IO;
using System.Collections;

namespace LA1300
{




    class Program
    {
        static void Main(string[] args)
        {
            ArrayList Firstword = new ArrayList();
            ArrayList Secondword = new ArrayList();

            bool QueLoopForAdd = true;
            bool WordDeclareLoop = true;
            bool QueLoopForOrder = true;
            string Voci = "";
            string outPath = @"..\..\..\..\savedwords.txt";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
 __          __                     _             ____        _     _      _   
 \ \        / /                    | |           / __ \      (_)   | |    | |  
  \ \  /\  / /_ _ _ __  _ __   __ _| |__   ___  | |  | |_   _ _ ___| | ___| |_ 
   \ \/  \/ / _` | '_ \| '_ \ / _` | '_ \ / _ \ | |  | | | | | |_  / |/ _ \ __|
    \  /\  / (_| | | | | | | | (_| | |_) |  __/ | |__| | |_| | |/ /| |  __/ |_ 
     \/  \/ \__,_|_| |_|_| |_|\__,_|_.__/ \___|  \___\_\\__,_|_/___|_|\___|\__|
                                                                                
                                                                               
");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Made by: Ilona Zinge / Nina Wösten / Igor Martic / Dijar Fazliu" + Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.White;

            while (WordDeclareLoop)
            {
                Console.WriteLine("Geben Sie Ihr Voci ein: [Deutsch]");
                Firstword.Add(Console.ReadLine());
                Console.WriteLine("Geben Sie die dazugehörige Übersetzung ein: [Fremdwort]");
                Secondword.Add(Console.ReadLine());
                QueLoopForAdd = true;
                while (QueLoopForAdd)
                {
                    Console.WriteLine("Wollen Sie noch ein Wort hinzufügen? [y/n]");
                    string Repeat = Console.ReadLine().ToLower();

                    switch (Repeat)
                    {
                        case "y":
                            QueLoopForAdd = false;
                            break;

                        case "n":
                            QueLoopForAdd = false;
                            WordDeclareLoop = false;

                            for (int b = 0; b < Firstword.Count; b++)
                            {
                                Voci += Firstword[b] + "   " + Secondword[b] + Environment.NewLine;
                            }
                            File.WriteAllText(outPath, Voci);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nBTW: Deine Wörter wurden in der Datei SAVEDWORDS.txt gespeichert" + Environment.NewLine);
                            Console.ForegroundColor = ConsoleColor.White;
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ungültige Eingabe, versuchen Sie was anderes:");
                            Console.ForegroundColor = ConsoleColor.White;

                            break;
                    }


                }

            }
            Console.WriteLine("Möchten Sie deutsch zur Fremdsprache übersetzen [d/f], oder die Fremdsprache zu deutsch? [f/d]");
            while (QueLoopForOrder)
            {
                string Order = Console.ReadLine().ToLower();
                switch (Order)
                {
                    case "d/f":
                        Eingabe(Firstword, Secondword);
                        QueLoopForOrder = false;
                        break;

                    case "f/d":
                        Eingabe(Secondword, Firstword);
                        QueLoopForOrder = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ihre Eingabe war ungütlig, geben Sie was anderes ein.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }
        static void Eingabe(ArrayList array1, ArrayList array2)
        {
            Console.Clear();
            int WhichWord = 0;
            int Highscore = 0;
            Random Rand = new Random();
            int Score = 0;
            ArrayList SecondTry = new ArrayList();
            ArrayList SecondWord = new ArrayList();
            string UserGuess = "";
            bool WrongWordLoop = false;
            while (true)
            {
                try
                {
                    Console.WriteLine(array1[WhichWord]);
                }
                catch
                {
                    break;
                }
                UserGuess = Console.ReadLine();

                if (UserGuess == Convert.ToString(array2[WhichWord]))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Richtig.");
                    Console.ForegroundColor = ConsoleColor.White;
                    int LengthOfCorrectWord = UserGuess.Length;

                    if (1 < LengthOfCorrectWord && LengthOfCorrectWord <= 4)
                    {
                        Score = Rand.Next(1, 10);
                    }
                    else if (4 < LengthOfCorrectWord && LengthOfCorrectWord <= 7)
                    {
                        Score = Rand.Next(10, 20);
                    }
                    else if (7 < LengthOfCorrectWord)
                    {
                        Score = Rand.Next(20, 30);
                    }

                    Highscore = Highscore + Score;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Falsch");
                    Console.ForegroundColor = ConsoleColor.White;
                    SecondTry.Add(array1[WhichWord]);
                    SecondWord.Add(array2[WhichWord]);
                    WrongWordLoop = true;
                }
                WhichWord++;
            }
            int WhichWrongWord = 0;
            while (WrongWordLoop)
            {
                try
                {
                    Console.WriteLine(SecondTry[WhichWrongWord]);
                }
                catch
                {
                    break;
                }

                UserGuess = Console.ReadLine();

                while (true)
                {
                    if (UserGuess == Convert.ToString(SecondWord[WhichWrongWord]))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Richtig.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"Die richtige Antwort wäre {SecondWord[WhichWrongWord]}, geben Sie das nochmal ein.");
                        Console.ForegroundColor = ConsoleColor.White;

                        UserGuess = Console.ReadLine();
                    }
                }
                WhichWrongWord++;
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Ihr Highscore: {Highscore}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("CYA NEXT TIME ^^");
        }
    }
}