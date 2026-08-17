using System;
using System.Collections.Generic;
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
        private bool showDetailedMenu;

        public Chatbot()
        {
            uiManager = new UIManager();
            responseHandler = new ResponseHandler();
            audioPlayer = new AudioPlayer();
            isRunning = true;
            userName = "";
            showDetailedMenu = true;
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
            DisplayMainMenu();

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

            // Exit commands
            if (lowerInput == "exit" || lowerInput == "quit" || lowerInput == "bye")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n╔══════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine($"║  Goodbye {userName}! Stay safe online!                                                ║");
                Console.WriteLine("║   Remember: Cybersecurity is everyone's responsibility!                                ║");
                Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════  ╝");
                Console.ResetColor();
                isRunning = false;
                return;
            }

            // Help commands
            if (lowerInput == "help" || lowerInput == "menu" || lowerInput == "options" || lowerInput == "?")
            {
                DisplayMainMenu();
                return;
            }

            // Back command
            if (lowerInput == "back" || lowerInput == "main")
            {
                DisplayMainMenu();
                return;
            }

            // --- NUMBERED NAVIGATION SYSTEM ---

            // Check for category selection (1, 2, 3, etc.)
            if (int.TryParse(input, out int categoryNumber) && categoryNumber >= 1 && categoryNumber <= 13)
            {
                DisplayCategoryDetails(categoryNumber);
                return;
            }

            // Check for sub-topic selection (1.1, 1.2, 2.1, etc.)
            if (input.Contains("."))
            {
                string[] parts = input.Split('.');
                if (parts.Length == 2 &&
                    int.TryParse(parts[0].Trim(), out int mainCategory) &&
                    int.TryParse(parts[1].Trim(), out int subTopic))
                {
                    string keyword = GetKeywordFromNumber(mainCategory, subTopic);

                    if (keyword != null)
                    {
                        uiManager.DisplayLoadingAnimation(" Searching");

                        // Get response from ResponseHandler
                        string response = responseHandler.GetResponse(keyword, userName);

                        if (response != null)
                        {
                            uiManager.DisplayChatbotMessage(response);
                            uiManager.DisplayChatbotMessage($" Type '{mainCategory}' to see more topics in this category, or 'menu' for main menu.");
                        }
                        else
                        {
                            uiManager.DisplayError($"Topic '{keyword}' not found. Please try again.");
                        }
                        return;
                    }
                    else
                    {
                        uiManager.DisplayError($"Topic '{input}' not found. Please check the number and try again.");
                        return;
                    }
                }
            }

            // Check for keyword search (existing functionality)
            uiManager.DisplayLoadingAnimation(" Thinking");
            string keywordResponse = responseHandler.GetResponse(lowerInput, userName);

            if (keywordResponse != null)
            {
                uiManager.DisplayChatbotMessage(keywordResponse);
            }
            else
            {
                uiManager.DisplayDefaultResponse();
                uiManager.DisplayChatbotMessage(" Type 'menu' to see all available topics, or type a keyword like 'password'.");
            }
        }

        private string GetKeywordFromNumber(int category, int subTopic)
        {
            // Map category and sub-topic numbers to keywords
            var topicMap = new Dictionary<string, string>
            {
                // Category 1: Passwords
                { "1.1", "password" },
                { "1.2", "password tips" },
                { "1.3", "password safety" },
                { "1.4", "password manager" },
                { "1.5", "password spraying" },
                { "1.6", "credential stuffing" },
                { "1.7", "brute force" },
                { "1.8", "two factor authentication" },
                { "1.9", "multi factor authentication" },

                // Category 2: Phishing
                { "2.1", "phishing" },
                { "2.2", "phishing email" },
                { "2.3", "phishing scam" },
                { "2.4", "quishing" },
                { "2.5", "vishing" },
                { "2.6", "smishing" },
                { "2.7", "business email compromise" },
                { "2.8", "suspicious link" },
                { "2.9", "link" },

                // Category 3: Browsing
                { "3.1", "browsing" },
                { "3.2", "safe browsing" },
                { "3.3", "browser safety" },
                { "3.4", "digital footprint" },
                { "3.5", "safe download" },

                // Category 4: Malware
                { "4.1", "malware" },
                { "4.2", "ransomware" },
                { "4.3", "virus" },
                { "4.4", "trojan" },
                { "4.5", "spyware" },
                { "4.6", "adware" },
                { "4.7", "worm" },
                { "4.8", "ransomware as a service" },
                { "4.9", "zero day" },
                { "4.10", "supply chain attack" },
                { "4.11", "deepfake" },
                { "4.12", "ai scam" },

                // Category 5: Protection
                { "5.1", "antivirus" },
                { "5.2", "firewall" },
                { "5.3", "vpn" },
                { "5.4", "ad blocker" },

                // Category 6: Network
                { "6.1", "public wi fi" },
                { "6.2", "secure wi fi" },
                { "6.3", "hotspot" },
                { "6.4", "router security" },

                // Category 7: Data
                { "7.1", "data backup" },
                { "7.2", "software updates" },

                // Category 8: Mobile
                { "8.1", "mobile security" },
                { "8.2", "app permissions" },
                { "8.3", "phone safety" },
                { "8.4", "SIM swap" },

                // Category 9: IoT
                { "9.1", "iot security" },
                { "9.2", "smart home" },
                { "9.3", "encryption" },
                { "9.4", "zero trust" },
                { "9.5", "cloud security" },

                // Category 10: Family
                { "10.1", "children online safety" },
                { "10.2", "elder fraud" },

                // Category 11: Shopping
                { "11.1", "online shopping safety" },
                { "11.2", "email safety" },

                // Category 12: General
                { "12.1", "cybersecurity" },
                { "12.2", "cybersecurity tips" },
                { "12.3", "tips" },
                { "12.4", "social media privacy" },
                { "12.5", "identity theft" },
                { "12.6", "oversharing" },
                { "12.7", "OSINT" },
                { "12.8", "doxing" },
                { "12.9", "sextortion" },

                // Category 13: Other
                { "13.1", "hello" },
                { "13.2", "how are you" },
                { "13.3", "what is your purpose" },
                { "13.4", "what can you do" },
                { "13.5", "what can i ask you about" },
                { "13.6", "thank you" }
            };

            string key = $"{category}.{subTopic}";
            if (topicMap.ContainsKey(key))
            {
                return topicMap[key];
            }
            return null;
        }

        private void DisplayMainMenu()
        {
            uiManager.DisplayHelpHeader();

            uiManager.DisplayCategoryHeader("1. PASSWORDS & AUTHENTICATION", ConsoleColor.Green);
            uiManager.DisplayTopicItem("  Type '1' to see all password topics");

            uiManager.DisplayCategoryHeader(" 2. PHISHING & SCAMS", ConsoleColor.Red);
            uiManager.DisplayTopicItem("  Type '2' to see all phishing topics");

            uiManager.DisplayCategoryHeader("3. SAFE BROWSING & PRIVACY", ConsoleColor.Cyan);
            uiManager.DisplayTopicItem("  Type '3' to see all browsing topics");

            uiManager.DisplayCategoryHeader(" 4. MALWARE & THREATS", ConsoleColor.Red);
            uiManager.DisplayTopicItem("  Type '4' to see all malware topics");

            uiManager.DisplayCategoryHeader(" 5. PROTECTION TOOLS", ConsoleColor.Blue);
            uiManager.DisplayTopicItem("  Type '5' to see all protection tools");

            uiManager.DisplayCategoryHeader(" 6. NETWORK & WI-FI", ConsoleColor.DarkYellow);
            uiManager.DisplayTopicItem("  Type '6' to see all network topics");

            uiManager.DisplayCategoryHeader(" 7. DATA PROTECTION & BACKUP", ConsoleColor.Magenta);
            uiManager.DisplayTopicItem("  Type '7' to see data protection topics");

            uiManager.DisplayCategoryHeader(" 8. MOBILE SECURITY", ConsoleColor.DarkGreen);
            uiManager.DisplayTopicItem("  Type '8' to see all mobile security topics");

            uiManager.DisplayCategoryHeader(" 9. IoT & SMART HOME", ConsoleColor.DarkCyan);
            uiManager.DisplayTopicItem("  Type '9' to see IoT topics");

            uiManager.DisplayCategoryHeader(" 10. ONLINE SAFETY FOR ALL", ConsoleColor.Yellow);
            uiManager.DisplayTopicItem("  Type '10' to see online safety topics");

            uiManager.DisplayCategoryHeader(" 11. SHOPPING & EMAIL", ConsoleColor.DarkMagenta);
            uiManager.DisplayTopicItem("  Type '11' to see shopping topics");

            uiManager.DisplayCategoryHeader(" 12. GENERAL TIPS", ConsoleColor.White);
            uiManager.DisplayTopicItem("  Type '12' to see general tips");

            uiManager.DisplayCategoryHeader(" 13. OTHER", ConsoleColor.Gray);
            uiManager.DisplayTopicItem("  Type '13' to see other commands");

            uiManager.DisplaySeparator();
            uiManager.DisplayChatbotMessage("Type a category number (e.g., '1') to see topics, or '1.1' for specific information!");
            uiManager.DisplayChatbotMessage(" You can also type keywords like 'password' or 'phishing'.");
            uiManager.DisplayColoredText(" Type 'exit' to leave | Type 'menu' for this menu again", ConsoleColor.DarkGray);
            uiManager.DisplaySeparator();
        }

        private void DisplayCategoryDetails(int categoryNumber)
        {
            uiManager.DisplaySeparator();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"╔══════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine($"║   TOPICS IN CATEGORY {categoryNumber}                                                ║");
            Console.WriteLine($"╚══════════════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            switch (categoryNumber)
            {
                case 1:
                    uiManager.DisplayCategoryHeader(" PASSWORDS & AUTHENTICATION", ConsoleColor.Green);
                    uiManager.DisplayTopicItem("  1.1  password");
                    uiManager.DisplayTopicItem("  1.2  password tips");
                    uiManager.DisplayTopicItem("  1.3  password safety");
                    uiManager.DisplayTopicItem("  1.4  password manager");
                    uiManager.DisplayTopicItem("  1.5  password spraying");
                    uiManager.DisplayTopicItem("  1.6  credential stuffing");
                    uiManager.DisplayTopicItem("  1.7  brute force");
                    uiManager.DisplayTopicItem("  1.8  two factor authentication (2FA)");
                    uiManager.DisplayTopicItem("  1.9  multi factor authentication (MFA)");
                    break;

                case 2:
                    uiManager.DisplayCategoryHeader(" PHISHING & SCAMS", ConsoleColor.Red);
                    uiManager.DisplayTopicItem("  2.1  phishing");
                    uiManager.DisplayTopicItem("  2.2  phishing email");
                    uiManager.DisplayTopicItem("  2.3  phishing scam");
                    uiManager.DisplayTopicItem("  2.4  quishing (QR code phishing)");
                    uiManager.DisplayTopicItem("  2.5  vishing (voice phishing)");
                    uiManager.DisplayTopicItem("  2.6  smishing (SMS phishing)");
                    uiManager.DisplayTopicItem("  2.7  business email compromise");
                    uiManager.DisplayTopicItem("  2.8  suspicious link");
                    uiManager.DisplayTopicItem("  2.9  link safety");
                    break;

                case 3:
                    uiManager.DisplayCategoryHeader(" SAFE BROWSING & PRIVACY", ConsoleColor.Cyan);
                    uiManager.DisplayTopicItem("  3.1  browsing");
                    uiManager.DisplayTopicItem("  3.2  safe browsing");
                    uiManager.DisplayTopicItem("  3.3  browser safety");
                    uiManager.DisplayTopicItem("  3.4  digital footprint");
                    uiManager.DisplayTopicItem("  3.5  safe download");
                    break;

                case 4:
                    uiManager.DisplayCategoryHeader(" MALWARE & THREATS", ConsoleColor.Red);
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
                    break;

                case 5:
                    uiManager.DisplayCategoryHeader(" PROTECTION TOOLS", ConsoleColor.Blue);
                    uiManager.DisplayTopicItem("  5.1  antivirus");
                    uiManager.DisplayTopicItem("  5.2  firewall");
                    uiManager.DisplayTopicItem("  5.3  VPN (Virtual Private Network)");
                    uiManager.DisplayTopicItem("  5.4  ad blocker");
                    break;

                case 6:
                    uiManager.DisplayCategoryHeader(" NETWORK & WI-FI", ConsoleColor.DarkYellow);
                    uiManager.DisplayTopicItem("  6.1  public wi fi");
                    uiManager.DisplayTopicItem("  6.2  secure wi fi");
                    uiManager.DisplayTopicItem("  6.3  hotspot");
                    uiManager.DisplayTopicItem("  6.4  router security");
                    break;

                case 7:
                    uiManager.DisplayCategoryHeader(" DATA PROTECTION & BACKUP", ConsoleColor.Magenta);
                    uiManager.DisplayTopicItem("  7.1  data backup");
                    uiManager.DisplayTopicItem("  7.2  software updates");
                    break;

                case 8:
                    uiManager.DisplayCategoryHeader(" MOBILE SECURITY", ConsoleColor.DarkGreen);
                    uiManager.DisplayTopicItem("  8.1  mobile security");
                    uiManager.DisplayTopicItem("  8.2  app permissions");
                    uiManager.DisplayTopicItem("  8.3  phone safety");
                    uiManager.DisplayTopicItem("  8.4  SIM swap");
                    break;

                case 9:
                    uiManager.DisplayCategoryHeader(" IoT & SMART HOME", ConsoleColor.DarkCyan);
                    uiManager.DisplayTopicItem("  9.1  iot security");
                    uiManager.DisplayTopicItem("  9.2  smart home");
                    uiManager.DisplayTopicItem("  9.3  encryption");
                    uiManager.DisplayTopicItem("  9.4  zero trust");
                    uiManager.DisplayTopicItem("  9.5  cloud security");
                    break;

                case 10:
                    uiManager.DisplayCategoryHeader(" ONLINE SAFETY FOR ALL", ConsoleColor.Yellow);
                    uiManager.DisplayTopicItem("  10.1 children online safety");
                    uiManager.DisplayTopicItem("  10.2 elder fraud");
                    break;

                case 11:
                    uiManager.DisplayCategoryHeader(" SHOPPING & EMAIL", ConsoleColor.DarkMagenta);
                    uiManager.DisplayTopicItem("  11.1 online shopping safety");
                    uiManager.DisplayTopicItem("  11.2 email safety");
                    break;

                case 12:
                    uiManager.DisplayCategoryHeader(" GENERAL TIPS", ConsoleColor.White);
                    uiManager.DisplayTopicItem("  12.1 cybersecurity");
                    uiManager.DisplayTopicItem("  12.2 cybersecurity tips");
                    uiManager.DisplayTopicItem("  12.3 tips (general)");
                    uiManager.DisplayTopicItem("  12.4 social media privacy");
                    uiManager.DisplayTopicItem("  12.5 identity theft");
                    uiManager.DisplayTopicItem("  12.6 oversharing");
                    uiManager.DisplayTopicItem("  12.7 OSINT");
                    uiManager.DisplayTopicItem("  12.8 doxing");
                    uiManager.DisplayTopicItem("  12.9 sextortion");
                    break;

                case 13:
                    uiManager.DisplayCategoryHeader(" OTHER", ConsoleColor.Gray);
                    uiManager.DisplayTopicItem("  13.1 hello / hi / hey");
                    uiManager.DisplayTopicItem("  13.2 how are you");
                    uiManager.DisplayTopicItem("  13.3 what is your purpose");
                    uiManager.DisplayTopicItem("  13.4 what can you do");
                    uiManager.DisplayTopicItem("  13.5 what can i ask you about");
                    uiManager.DisplayTopicItem("  13.6 thank you / thanks");
                    break;
            }

            uiManager.DisplaySeparator();
            uiManager.DisplayChatbotMessage($" Type a number like '{categoryNumber}.1' to learn about a specific topic!");
            uiManager.DisplayChatbotMessage($" Type 'back' to return to the main menu, or 'menu' for all categories.");
            uiManager.DisplaySeparator();
        }
    }
}