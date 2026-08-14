using System;

namespace CybersecurityChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Bot";

            Console.SetWindowSize(120, 40);

            Chatbot chatbot = new Chatbot();

            chatbot.start();

            Console.WriteLine("\n\nPress any Key to exit...");
            Console.ReadKey();
        }
    }
}
