using System;

namespace CybersecurityChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
#pragma warning disable CA1416
            Console.Title = " Cybersecurity Awareness Assistant";
            Console.SetWindowSize(120, 45);
#pragma warning restore CA1416

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║   Starting Cybersecurity Awareness Assistant...                                      ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();

            Chatbot chatbot = new Chatbot();
            chatbot.Start();

            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}