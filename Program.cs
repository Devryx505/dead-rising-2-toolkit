using System;
using System.Threading;

class OvercomplicatedGreeting
{
    static void Main()
    {
        // A simple "Hello" completely over-engineered for absolutely no reason.
        string target = "Hello World";
        string current = "";
        Random random = new Random();

        Console.CursorVisible = false;
        Console.ForegroundColor = ConsoleColor.Green;

        for (int i = 0; i < target.Length; i++)
        {
            char correctChar = target[i];
            char guessedChar = ' ';

            // Force the CPU to guess random letters until it hits the right one
            while (guessedChar != correctChar)
            {
                // Generate random ASCII characters from space (32) to tilde (126)
                guessedChar = (char)random.Next(32, 127);
                
                Console.Write($"\rBrute-forcing reality: {current}{guessedChar}");
                Thread.Sleep(15); 
            }

            current += correctChar;
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"\n[SUCCESS] Matrix bypassed. Result: {current} \n");
        Console.ResetColor();
    }
}
