using System;
using System.Threading;

namespace CybersecurityChatbot
{
    public class UIManager
    {
        private const string BORDER = "=================================================================================";
        private const string DIVIDER = "---------------------------------------------------------------------------------";
        private const string THIN_DIVIDER = ".........................................................................";

        public void DisplayHeader()
        {
            Console.Clear();

            // Big ASCII Art Title
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@"   ██████╗██╗   ██╗██████╗ ███████╗██████╗ ███████╗ ██████╗██╗   ██╗██████╗ ██╗████████╗██╗   ██╗");
            Console.WriteLine(@"  ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗██╔════╝██╔════╝╚██╗ ██╔╝██╔══██╗██║╚══██╔══╝╚██╗ ██╔╝");
            Console.WriteLine(@"  ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝███████╗██║      ╚████╔╝ ██████╔╝██║   ██║    ╚████╔╝ ");
            Console.WriteLine(@"  ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗╚════██║██║       ╚██╔╝  ██╔══██╗██║   ██║     ╚██╔╝  ");
            Console.WriteLine(@"  ╚██████╗   ██║   ██████╔╝███████╗██║  ██║███████║╚██████╗   ██║   ██████╔╝██║   ██║      ██║   ");
            Console.WriteLine(@"   ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝╚══════╝ ╚═════╝   ╚═╝   ╚═════╝ ╚═╝   ╚═╝      ╚═╝   ");
            Console.ResetColor();

            // Title Box
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"  ╔══════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine(@"  ║                        CYBERSECURITY AWARENESS ASSISTANT                           ║");
            Console.WriteLine(@"  ║                     Your Digital Guardian Against Cyber Threats                    ║");
            Console.WriteLine(@"  ╚══════════════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            // Separator
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(BORDER);
            Console.ResetColor();
            Console.WriteLine();

            // Animated typing effect for welcome
            TypeTextAnimated("Welcome to your Cybersecurity Awareness Assistant!", ConsoleColor.Green, 25);
            TypeTextAnimated("I am here to protect and educate you in the digital world.", ConsoleColor.Cyan, 25);
            Console.WriteLine();
            Thread.Sleep(500);
        }

        private void TypeTextAnimated(string text, ConsoleColor color, int delay = 30)
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

        public void DisplayWelcomeMessage(string userName)
        {
            Console.WriteLine();
            DisplayColoredText($"================================================================================", ConsoleColor.DarkGray);
            DisplayColoredText($"  WELCOME, {userName.ToUpper()}!", ConsoleColor.Green);
            DisplayColoredText($"  Let us build your cyber defense skills together!", ConsoleColor.Cyan);
            DisplayColoredText($"================================================================================", ConsoleColor.DarkGray);
            Console.WriteLine();
            DisplayColoredText($"Say 'help' anytime to see what I can teach you.", ConsoleColor.Yellow);
            DisplayColoredText($"Say 'exit' to end our conversation.", ConsoleColor.Yellow);
            DisplaySeparator();
        }

        public void DisplayGreeting(string userName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nHello {userName}! I am your Cybersecurity Awareness Assistant.");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("I am here to help you stay safe online.");
            Console.ResetColor();
            DisplaySeparator();
        }

        public void DisplayMenuPrompt()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nWhat would you like to know about today?");
            Console.ResetColor();
        }

        public void DisplayChatbotMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Assistant: ");
            Console.ForegroundColor = ConsoleColor.Cyan;

            string[] words = message.Split(' ');
            string line = "";
            int consoleWidth = Console.WindowWidth - 15;

            foreach (string word in words)
            {
                if ((line + word).Length > consoleWidth)
                {
                    Console.WriteLine(line);
                    Console.Write(new string(' ', 12));
                    line = word + " ";
                }
                else
                {
                    line += word + " ";
                }
            }
            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(line);
            }
            Console.ResetColor();
        }

        public void DisplayUserMessage(string userName, string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{userName}: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
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
            Console.WriteLine($"Error: {errorMessage}");
            Console.ResetColor();
        }

        public void DisplayDefaultResponse()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("I didn't quite understand that. Could you rephrase?");
            Console.ResetColor();
            DisplayChatbotMessage("Try asking about passwords, phishing, safe browsing, social engineering, or 2FA!");
        }

        public void DisplaySeparator()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(THIN_DIVIDER);
            Console.ResetColor();
        }

        public void DisplayBorder()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(BORDER);
            Console.ResetColor();
        }

        public void DisplayHelpHeader()
        {
            DisplaySeparator();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("================================================================================");
            Console.WriteLine("  AVAILABLE TOPICS - TYPE ANY KEYWORD TO LEARN");
            Console.WriteLine("================================================================================");
            Console.ResetColor();
        }

        public void DisplayCategoryHeader(string category, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"\n  {category}");
            Console.ResetColor();
        }

        public void DisplayTopicItem(string topic)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"    {topic}");
            Console.ResetColor();
        }

        public void DisplayLoadingAnimation(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(message);
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(300);
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}