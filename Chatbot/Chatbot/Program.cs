using System;

namespace CybersecurityChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
#pragma warning disable CA1416

            Console.Title = "Cybersecurity Awareness Bot";

            Console.SetWindowSize(120, 40);
#pragma warning restore CA1416

            Chatbot chatbot = new Chatbot();

            chatbot.Start();

            Console.WriteLine("\n\nPress any Key to exit...");
            Console.ReadKey();
        }
    }
}
