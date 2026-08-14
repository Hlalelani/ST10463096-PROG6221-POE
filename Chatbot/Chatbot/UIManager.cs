using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CybersecurityChatbot
{
    public class UIManager
    {
        private const string BORDER = "═══════════════════════════════════════════════════════════════════════════════════════════════";

        private const string DIVIDER = "───────────────────────────────────────────────────────────────────────────────────────────";

        public void DisplayHeader()
        {
            Console.Clear();

            DisplayAsciiArt();
             
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                          CYBERSECURITY AWARENESS BOT                              ║");
            Console.WriteLine("║                              Your Digital Guardian                                ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════╝");

            Console.ResetColor();

            TypeText("Welcome to the Cybersecurity Awareness Bot!", ConsoleColor.Cyan);
            TypeText("I'M here to help you stay in the digital world.", ConsoleColor.Green);
            Thread.Sleep(500);
        }

        private void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"    _____             __ _               _                    _   _           ");
            Console.WriteLine(@"   / ____|           / _| |             | |                  | \ | |          ");
            Console.WriteLine(@"  | |     ___  _ __ | |_| |__   ___  ___| | _____  _ __   __|  \| | __ _ _ __ ");
            Console.WriteLine(@"  | |    / _ \| '_ \|  _| '_ \ / _ \/ __| |/ _ \ \/ '_ \ / _` |\  |/ _` | '__|");
            Console.WriteLine(@"  | |___| (_) | | | | | | |_) |  __/ (__| |  __/>  <| |_) | (_| | | | (_| | | ");
            Console.WriteLine(@"   \_____\___/|_| |_|_| |_.__/ \___|\___|_|\___/_/\_\ .__/ \__,_|_|_|\__,_|_| ");
            Console.WriteLine(@"                                                   | |                        ");
            Console.WriteLine(@"                                                   |_|                        ");

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════");
            Console.ResetColor();
        }

        public void DisplayWelcomeMessage(string userName)
        {
            Console.WriteLine();
            DisplayColoredText($"Hello {userName}!", ConsoleColor.Green);
            DisplayChatbotMessage($"It's great to have you here, {userName}!");
            DisplayChatbotMessage("I'll teach you how to protect yourself from cybe threats.");

            DisplaySeparator();
        }
        public void DisplayChatbotMessage(string message)
        {
            DisplayColoredText($"Bot:{message}", ConsoleColor.Magenta);
        }
        public void DisplayColoredText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public void DisplayError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" {errorMessage}");
            Console.ResetColor();
        }
        public void DisplayDefaultResponse()
        {
            DisplayColoredText(" I didn't quite understand that. Could you rephrase?", ConsoleColor.Yellow);
            DisplayChatbotMessage("Try asking about passwords, phishing, or safe browsing!");
        }
        public void DisplaySeparator()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(DIVIDER);
            Console.ResetColor();
        }
        public void DisplayBorder()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(BORDER);
            Console.ResetColor();
        }
        public void TypeText(string text, ConsoleColor color, int delay = 30)
        {
            Console.ForegroundColor = color;

            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}

