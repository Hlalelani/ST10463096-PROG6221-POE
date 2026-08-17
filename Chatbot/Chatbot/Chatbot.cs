using System;
using System.Threading;

namespace CybersecurityChatbot
{
    public class Chatbot
    {
        private string userName;
        private bool isRunning;
        private UIManager uiManager;
        private ResponseHandler responseHandler;
        private AudioPlayer audioPlayer;

        public Chatbot()
        {
            uiManager = new UIManager();
            responseHandler = new ResponseHandler();
            audioPlayer = new AudioPlayer();
            isRunning = true;
            userName = "";
        }

        public void Start()
        {
            try
            {
                audioPlayer.PlayGreeting();
                uiManager.DisplayHeader();
                GetUserName();
                uiManager.DisplayWelcomeMessage(userName);
                StartConversation();
            }
            catch (Exception ex)
            {
                uiManager.DisplayError($"An error occurred: {ex.Message}");
            }
        }

        private void GetUserName()
        {
            bool validName = false;
            while (!validName)
            {
                uiManager.DisplayColoredText("Please enter your name: ", ConsoleColor.Cyan);
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    uiManager.DisplayError("Name cannot be empty. Please try again.");
                    continue;
                }
                if (input.Length > 50)
                {
                    uiManager.DisplayError("Name is too long. Please enter a shorter name.");
                    continue;
                }

                bool isValid = true;
                foreach (char c in input)
                {
                    if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    {
                        isValid = false;
                        break;
                    }
                }

                if (!isValid)
                {
                    uiManager.DisplayError("Please use only letters and spaces in your name.");
                    continue;
                }

                userName = input.Trim();
                validName = true;
            }
        }

        private void StartConversation()
        {
            uiManager.DisplaySeparator();
            uiManager.DisplayChatbotMessage($"Hello {userName}! I'm your Cybersecurity Awareness Assistant.");
            uiManager.DisplayChatbotMessage("I'm here to help you stay safe online.");
            uiManager.DisplaySeparator();
            DisplayHelp();

            while (isRunning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"\n {userName}: ");
                Console.ResetColor();

                string userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    uiManager.DisplayError("I didn't catch that. Please type something.");
                    continue;
                }
                ProcessUserInput(userInput);
            }
        }

        private void ProcessUserInput(string input)
        {
            string lowerInput = input.ToLower().Trim();

            if (lowerInput == "exit" || lowerInput == "quit" || lowerInput == "bye")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n╔══════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine($"║   Goodbye {userName}! Stay safe online!                                               ║");
                Console.WriteLine("║   Remember: Cybersecurity is everyone's responsibility!                                ║");
                Console.WriteLine("  ╚══════════════════════════════════════════════════════════════════════════════════════╝");
                Console.ResetColor();
                isRunning = false;
                return;
            }

            if (lowerInput == "help" || lowerInput == "menu" || lowerInput == "options" || lowerInput == "?")
            {
                DisplayHelp();
                return;
            }

            // Show loading animation
            uiManager.DisplayLoadingAnimation(" Thinking");

            string response = responseHandler.GetResponse(lowerInput, userName);

            if (response != null)
            {
                uiManager.DisplayChatbotMessage(response);
            }
            else
            {
                uiManager.DisplayDefaultResponse();
            }
        }
        private void DisplayHelp()
        {
            uiManager.DisplayHelpHeader();

            // Category 1: Passwords
            uiManager.DisplayCategoryHeader(" 1. PASSWORDS & AUTHENTICATION", ConsoleColor.Green);
            uiManager.DisplayTopicItem("  1.1  password");
            uiManager.DisplayTopicItem("  1.2  password tips");
            uiManager.DisplayTopicItem("  1.3  password safety");
            uiManager.DisplayTopicItem("  1.4  password manager");
            uiManager.DisplayTopicItem("  1.5  password spraying");
            uiManager.DisplayTopicItem("  1.6  credential stuffing");
            uiManager.DisplayTopicItem("  1.7  brute force");
            uiManager.DisplayTopicItem("  1.8  two factor authentication (2FA)");
            uiManager.DisplayTopicItem("  1.9  multi factor authentication (MFA)");

            // Category 2: Phishing
            uiManager.DisplayCategoryHeader(" 2. PHISHING & SCAMS", ConsoleColor.Red);
            uiManager.DisplayTopicItem("  2.1  phishing");
            uiManager.DisplayTopicItem("  2.2  phishing email");
            uiManager.DisplayTopicItem("  2.3  phishing scam");
            uiManager.DisplayTopicItem("  2.4  quishing (QR code phishing)");
            uiManager.DisplayTopicItem("  2.5  vishing (voice phishing)");
            uiManager.DisplayTopicItem("  2.6  smishing (SMS phishing)");
            uiManager.DisplayTopicItem("  2.7  business email compromise");
            uiManager.DisplayTopicItem("  2.8  suspicious link");
            uiManager.DisplayTopicItem("  2.9  link safety");

            // Category 3: Browsing
            uiManager.DisplayCategoryHeader(" 3. SAFE BROWSING & PRIVACY", ConsoleColor.Cyan);
            uiManager.DisplayTopicItem("  3.1  browsing");
            uiManager.DisplayTopicItem("  3.2  safe browsing");
            uiManager.DisplayTopicItem("  3.3  browser safety");
            uiManager.DisplayTopicItem("  3.4  digital footprint");
            uiManager.DisplayTopicItem("  3.5  safe download");

            // Category 4: Malware
            uiManager.DisplayCategoryHeader(" 4. MALWARE & THREATS", ConsoleColor.Red);
            uiManager.DisplayTopicItem("  4.1  malware");
            uiManager.DisplayTopicItem("  4.2  ransomware");
            uiManager.DisplayTopicItem("  4.3  virus");
            uiManager.DisplayTopicItem("  4.4  trojan");
            uiManager.DisplayTopicItem("  4.5  spyware");
            uiManager.DisplayTopicItem("  4.6  adware");
            uiManager.DisplayTopicItem("  4.7  worm");
            uiManager.DisplayTopicItem("  4.8  ransomware as a service");
            uiManager.DisplayTopicItem("  4.9  zero day");
            uiManager.DisplayTopicItem("  4.10 supply chain attack");
            uiManager.DisplayTopicItem("  4.11 deepfake");
            uiManager.DisplayTopicItem("  4.12 ai scam");

            // Category 5: Protection
            uiManager.DisplayCategoryHeader("🛡 5. PROTECTION TOOLS", ConsoleColor.Blue);
            uiManager.DisplayTopicItem("  5.1  antivirus");
            uiManager.DisplayTopicItem("  5.2  firewall");
            uiManager.DisplayTopicItem("  5.3  VPN (Virtual Private Network)");
            uiManager.DisplayTopicItem("  5.4  ad blocker");

            // Category 6: Network
            uiManager.DisplayCategoryHeader(" 6. NETWORK & WI-FI", ConsoleColor.DarkYellow);
            uiManager.DisplayTopicItem("  6.1  public wi fi");
            uiManager.DisplayTopicItem("  6.2  secure wi fi");
            uiManager.DisplayTopicItem("  6.3  hotspot");
            uiManager.DisplayTopicItem("  6.4  router security");

            // Category 7: Data
            uiManager.DisplayCategoryHeader(" 7. DATA PROTECTION & BACKUP", ConsoleColor.Magenta);
            uiManager.DisplayTopicItem("  7.1  data backup");
            uiManager.DisplayTopicItem("  7.2  software updates");

            // Category 8: Mobile
            uiManager.DisplayCategoryHeader(" 8. MOBILE SECURITY", ConsoleColor.DarkGreen);
            uiManager.DisplayTopicItem("  8.1  mobile security");
            uiManager.DisplayTopicItem("  8.2  app permissions");
            uiManager.DisplayTopicItem("  8.3  phone safety");
            uiManager.DisplayTopicItem("  8.4  SIM swap");

            // Category 9: IoT
            uiManager.DisplayCategoryHeader(" 9. IoT & SMART HOME", ConsoleColor.DarkCyan);
            uiManager.DisplayTopicItem("  9.1  iot security");
            uiManager.DisplayTopicItem("  9.2  smart home");
            uiManager.DisplayTopicItem("  9.3  encryption");
            uiManager.DisplayTopicItem("  9.4  zero trust");
            uiManager.DisplayTopicItem("  9.5  cloud security");

            // Category 10: Family
            uiManager.DisplayCategoryHeader(" 10. ONLINE SAFETY FOR ALL", ConsoleColor.Yellow);
            uiManager.DisplayTopicItem("  10.1 children online safety");
            uiManager.DisplayTopicItem("  10.2 elder fraud");

            // Category 11: Shopping
            uiManager.DisplayCategoryHeader(" 11. SHOPPING & EMAIL", ConsoleColor.DarkMagenta);
            uiManager.DisplayTopicItem("  11.1 online shopping safety");
            uiManager.DisplayTopicItem("  11.2 email safety");

            // Category 12: General
            uiManager.DisplayCategoryHeader(" 12. GENERAL TIPS", ConsoleColor.White);
            uiManager.DisplayTopicItem("  12.1 cybersecurity");
            uiManager.DisplayTopicItem("  12.2 cybersecurity tips");
            uiManager.DisplayTopicItem("  12.3 tips (general)");
            uiManager.DisplayTopicItem("  12.4 social media privacy");
            uiManager.DisplayTopicItem("  12.5 identity theft");
            uiManager.DisplayTopicItem("  12.6 oversharing");
            uiManager.DisplayTopicItem("  12.7 OSINT");
            uiManager.DisplayTopicItem("  12.8 doxing");
            uiManager.DisplayTopicItem("  12.9 sextortion");

            // Category 13: Other
            uiManager.DisplayCategoryHeader(" 13. OTHER", ConsoleColor.Gray);
            uiManager.DisplayTopicItem("  13.1 hello / hi / hey");
            uiManager.DisplayTopicItem("  13.2 how are you");
            uiManager.DisplayTopicItem("  13.3 what is your purpose");
            uiManager.DisplayTopicItem("  13.4 what can you do");
            uiManager.DisplayTopicItem("  13.5 what can i ask you about");
            uiManager.DisplayTopicItem("  13.6 thank you / thanks");
            uiManager.DisplayTopicItem("  13.7 help (shows this menu)");

            uiManager.DisplaySeparator();
            uiManager.DisplayChatbotMessage(" Type any keyword (e.g., 'password' or 'phishing') to learn more!");
            uiManager.DisplayColoredText(" Type 'exit' to leave | Type 'help' to see this menu again", ConsoleColor.DarkGray);
            uiManager.DisplaySeparator();
        }

    }
}