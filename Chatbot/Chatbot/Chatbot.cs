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
        private string lastTopic;
        private List<string> conversationHistory;
        private Random random;

        public Chatbot()
        {
            uiManager = new UIManager();
            responseHandler = new ResponseHandler();
            audioPlayer = new AudioPlayer();
            random = new Random();
            isRunning = true;
            userName = "";
            lastTopic = "";
            conversationHistory = new List<string>();
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
            // Step 1: Greeting first
            uiManager.DisplaySeparator();
            uiManager.DisplayGreeting(userName);
            uiManager.DisplaySeparator();

            // Step 2: Ask how user is doing
            AskHowUserIsDoing();

            // Step 3: Then show the menu
            DisplayMainMenu();

            while (isRunning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"\n{userName}: ");
                Console.ResetColor();

                string userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    uiManager.DisplayError("I didn't catch that.");
                    continue;
                }
                ProcessUserInput(userInput);
            }
        }

        private void AskHowUserIsDoing()
        {
            string[] askResponses = {
                $"How are you feeling today, {userName}?",
                $"I hope you are having a great day, {userName}! How are you?",
                $"Before we start, how are you doing today, {userName}?"
            };
            string response = askResponses[random.Next(askResponses.Length)];
            uiManager.DisplayChatbotMessage(response);
        }

        private void ProcessUserInput(string input)
        {
            string lowerInput = input.ToLower().Trim();
            conversationHistory.Add(lowerInput);

            // Exit commands
            if (lowerInput == "exit" || lowerInput == "quit" || lowerInput == "bye" ||
                lowerInput == "goodbye" || lowerInput == "see you" || lowerInput == "later")
            {
                ShowExitMessage();
                return;
            }

            // Help / Menu commands
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

            // Follow-up questions
            if (lowerInput == "tell me more" || lowerInput == "more" || lowerInput == "another tip" ||
                lowerInput == "another" || lowerInput == "continue" || lowerInput == "go on" ||
                lowerInput == "and then" || lowerInput == "what else" || lowerInput == "more info")
            {
                HandleFollowUp();
                return;
            }

            // ====== NATURAL CONVERSATION RESPONSES ======

            // 1. How are you responses (User asks bot)
            if (lowerInput.Contains("how are you") || lowerInput.Contains("how do you do") ||
                lowerInput.Contains("how you doing") || lowerInput.Contains("how is it going") ||
                lowerInput.Contains("how's it going"))
            {
                HandleHowAreYou();
                return;
            }

            // 2. User says they are feeling something
            if (lowerInput.Contains("i am") || lowerInput.Contains("i'm") || lowerInput.Contains("feeling") ||
                lowerInput.Contains("i feel"))
            {
                HandleUserMood(lowerInput);
                return;
            }

            // 3. Positive responses: good, fine, great, well, okay
            if (lowerInput == "good" || lowerInput == "fine" || lowerInput == "great" ||
                lowerInput == "well" || lowerInput == "okay" || lowerInput == "ok" ||
                lowerInput == "not bad" || lowerInput == "doing well" || lowerInput == "i am good" ||
                lowerInput == "i am fine" || lowerInput == "im good" || lowerInput == "im fine" ||
                lowerInput.Contains("am good") || lowerInput.Contains("am fine") ||
                lowerInput.Contains("doing good") || lowerInput.Contains("doing fine"))
            {
                HandlePositiveResponse();
                return;
            }

            // 4. Negative responses: bad, not good, tired, stressed
            if (lowerInput.Contains("bad") || lowerInput.Contains("not good") ||
                lowerInput.Contains("tired") || lowerInput.Contains("stressed") ||
                lowerInput.Contains("worried") || lowerInput.Contains("scared") ||
                lowerInput.Contains("anxious") || lowerInput.Contains("overwhelmed") ||
                lowerInput.Contains("sad") || lowerInput.Contains("not great"))
            {
                HandleNegativeResponse();
                return;
            }

            // 5. Thank you responses
            if (lowerInput.Contains("thank") || lowerInput.Contains("thanks") || lowerInput == "ty")
            {
                HandleThankYou();
                return;
            }

            // 6. Greetings
            if (lowerInput == "hello" || lowerInput == "hi" || lowerInput == "hey" || lowerInput == "howdy")
            {
                HandleGreeting();
                return;
            }

            // 7. What is your name
            if (lowerInput.Contains("what is your name") || lowerInput.Contains("who are you"))
            {
                uiManager.DisplayChatbotMessage($"I am your Cybersecurity Awareness Assistant! You can call me CyberGuard.");
                uiManager.DisplayChatbotMessage($"I am here to help you stay safe online, {userName}.");
                return;
            }

            // 8. What can you do / capabilities
            if (lowerInput.Contains("what can you do") || lowerInput.Contains("capabilities") ||
                lowerInput.Contains("help me with") || lowerInput.Contains("what do you do"))
            {
                uiManager.DisplayChatbotMessage($"I can help you with cybersecurity topics like:");
                uiManager.DisplayChatbotMessage("  - Creating strong passwords");
                uiManager.DisplayChatbotMessage("  - Recognizing phishing scams");
                uiManager.DisplayChatbotMessage("  - Protecting your privacy");
                uiManager.DisplayChatbotMessage("  - Avoiding malware and viruses");
                uiManager.DisplayChatbotMessage("  - Securing your devices");
                uiManager.DisplayChatbotMessage($"Just ask me about any topic, {userName}!");
                return;
            }

            // Check if input is a topic (keyword recognition)
            string topicResponse = responseHandler.GetResponse(lowerInput, userName);

            if (topicResponse != null)
            {
                lastTopic = lowerInput;
                HandleTopicResponse(lowerInput, topicResponse);
                return;
            }

            // Default response
            HandleDefaultResponse();
        }

        // ====== HANDLER METHODS ======

        private void ShowExitMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n================================================================================");
            Console.WriteLine($"  Goodbye {userName}! Stay safe online!");
            Console.WriteLine("  Remember: Cybersecurity is everyone's responsibility!");
            Console.WriteLine("  Come back anytime you need security advice!");
            Console.WriteLine("================================================================================");
            Console.ResetColor();
            isRunning = false;
        }

        private void HandleFollowUp()
        {
            if (!string.IsNullOrEmpty(lastTopic))
            {
                uiManager.DisplayLoadingAnimation("Let me find more information");
                string response = responseHandler.GetResponse(lastTopic, userName);
                if (response != null)
                {
                    uiManager.DisplayChatbotMessage($"Of course! Here is more about {lastTopic}:");
                    uiManager.DisplayChatbotMessage(response);
                    uiManager.DisplayChatbotMessage($"Would you like to know more about {lastTopic}?");
                    return;
                }
            }
            uiManager.DisplayChatbotMessage("I would love to tell you more. What topic are you interested in?");
        }

        private void HandleHowAreYou()
        {
            string[] responses = {
                $"I am doing great, {userName}! Thanks for asking. How are you doing today?",
                $"I am always ready to help you stay secure online! What about you, {userName}?",
                $"I am functioning perfectly! I love helping people learn about cybersecurity. How are you feeling?",
                $"I am wonderful, {userName}! It is a great day to learn about staying safe online. How are you?"
            };
            string response = responses[random.Next(responses.Length)];
            uiManager.DisplayChatbotMessage(response);
        }

        private void HandleUserMood(string input)
        {
            if (input.Contains("happy") || input.Contains("good") || input.Contains("great") ||
                input.Contains("fine") || input.Contains("wonderful"))
            {
                string[] responses = {
                    $"That is wonderful to hear, {userName}! A positive attitude makes learning about security even better.",
                    $"I am so glad you are feeling good, {userName}! Let us make your day even better with some cybersecurity tips.",
                    $"Great mood, {userName}! That is the perfect mindset to learn about staying safe online."
                };
                string response = responses[random.Next(responses.Length)];
                uiManager.DisplayChatbotMessage(response);
                uiManager.DisplayChatbotMessage("What topic would you like to explore today?");
            }
            else if (input.Contains("worried") || input.Contains("scared") || input.Contains("anxious"))
            {
                string[] responses = {
                    $"I understand you are feeling worried, {userName}. Cybersecurity can seem scary, but I am here to help!",
                    $"It is completely normal to feel anxious about online threats. Let me help you feel more secure.",
                    $"Do not worry, {userName}! I will guide you through everything step by step. You are not alone in this."
                };
                string response = responses[random.Next(responses.Length)];
                uiManager.DisplayChatbotMessage(response);
                uiManager.DisplayChatbotMessage("Let's start with something simple - what would you like to learn about?");
            }
            else if (input.Contains("tired") || input.Contains("stressed") || input.Contains("overwhelmed"))
            {
                string[] responses = {
                    $"I hear you, {userName}. Cybersecurity can be overwhelming. Let us keep it simple and clear.",
                    $"Take a deep breath, {userName}. I am here to make this easy for you.",
                    $"I understand you are feeling tired or stressed. Let me explain things in a simple way, {userName}."
                };
                string response = responses[random.Next(responses.Length)];
                uiManager.DisplayChatbotMessage(response);
                uiManager.DisplayChatbotMessage("What would you like to learn about today?");
            }
            else
            {
                string[] responses = {
                    $"I appreciate you sharing that with me, {userName}. How can I help you today?",
                    $"Thank you for telling me, {userName}. What cybersecurity topic interests you?",
                    $"I am here to listen and help, {userName}. What would you like to learn about?"
                };
                string response = responses[random.Next(responses.Length)];
                uiManager.DisplayChatbotMessage(response);
            }
        }

        private void HandlePositiveResponse()
        {
            string[] responses = {
                $"That is great to hear, {userName}! I am glad you are doing well.",
                $"Wonderful! A positive day makes learning about cybersecurity even better, {userName}.",
                $"Excellent! Let us make today productive with some cybersecurity knowledge, {userName}."
            };
            string response = responses[random.Next(responses.Length)];
            uiManager.DisplayChatbotMessage(response);
            uiManager.DisplayChatbotMessage($"What would you like to learn about today, {userName}?");
        }

        private void HandleNegativeResponse()
        {
            string[] responses = {
                $"I am sorry to hear that, {userName}. I hope learning about cybersecurity helps you feel more secure.",
                $"That is not great to hear, {userName}. I am here to help you stay safe online.",
                $"I understand things can be tough sometimes, {userName}. I am here to support you."
            };
            string response = responses[random.Next(responses.Length)];
            uiManager.DisplayChatbotMessage(response);
            uiManager.DisplayChatbotMessage($"What cybersecurity topic would you like me to explain, {userName}?");
        }

        private void HandleThankYou()
        {
            string[] responses = {
                $"You are welcome, {userName}! I am glad I could help.",
                $"Happy to help, {userName}! Stay safe online!",
                $"My pleasure, {userName}! Is there anything else you would like to know?",
                $"You are welcome! Remember, I am always here to help you stay secure, {userName}."
            };
            string response = responses[random.Next(responses.Length)];
            uiManager.DisplayChatbotMessage(response);
        }

        private void HandleGreeting()
        {
            string[] responses = {
                $"Hello again, {userName}! How can I help you today?",
                $"Hi there, {userName}! Ready to learn more about cybersecurity?",
                $"Hey, {userName}! What would you like to know about today?",
                $"Good to see you again, {userName}! How are you doing?"
            };
            string response = responses[random.Next(responses.Length)];
            uiManager.DisplayChatbotMessage(response);
        }

        private void HandleTopicResponse(string topic, string response)
        {
            uiManager.DisplayLoadingAnimation($"Let me think about that");
            uiManager.DisplayChatbotMessage($"Great question about {topic}, {userName}!");
            uiManager.DisplayChatbotMessage(response);
            uiManager.DisplayChatbotMessage($"Would you like me to share more about {topic}?");
        }

        private void HandleDefaultResponse()
        {
            string[] responses = {
                $"That is an interesting question, {userName}. Let me think...",
                $"I want to make sure I give you the best answer, {userName}.",
                $"Could you tell me more about what you would like to know, {userName}?",
                $"I am here to help with cybersecurity topics like passwords, phishing, and privacy.",
                $"I am not sure I understand, {userName}. Could you rephrase that?",
                $"Let me think about that for a moment, {userName}."
            };
            string response = responses[random.Next(responses.Length)];
            uiManager.DisplayChatbotMessage(response);
            uiManager.DisplayChatbotMessage("Feel free to ask about anything cybersecurity-related.");
        }

        // ====== DISPLAY METHODS ======

        private void DisplayMainMenu()
        {
            uiManager.DisplaySeparator();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("================================================================================");
            Console.WriteLine("  WHAT I CAN HELP YOU WITH");
            Console.WriteLine("  Ask me about any topic below");
            Console.WriteLine("================================================================================");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n  PASSWORDS AND AUTHENTICATION");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    - password");
            Console.WriteLine("    - password tips");
            Console.WriteLine("    - password safety");
            Console.WriteLine("    - password manager");
            Console.WriteLine("    - two factor authentication or 2FA");
            Console.WriteLine("    - multi factor authentication");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n  PHISHING AND SCAMS");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    - phishing");
            Console.WriteLine("    - phishing email");
            Console.WriteLine("    - phishing scam");
            Console.WriteLine("    - suspicious link");
            Console.WriteLine("    - vishing, smishing, quishing");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n  SAFE BROWSING AND PRIVACY");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    - safe browsing");
            Console.WriteLine("    - browser safety");
            Console.WriteLine("    - digital footprint");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n  MALWARE AND THREATS");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    - malware");
            Console.WriteLine("    - ransomware");
            Console.WriteLine("    - virus");
            Console.WriteLine("    - trojan");
            Console.WriteLine("    - spyware");
            Console.WriteLine("    - zero day");
            Console.WriteLine("    - deepfake");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n  PROTECTION TOOLS");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    - antivirus");
            Console.WriteLine("    - firewall");
            Console.WriteLine("    - VPN");
            Console.WriteLine("    - ad blocker");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n  MOBILE AND IOT SECURITY");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    - mobile security");
            Console.WriteLine("    - SIM swap");
            Console.WriteLine("    - IoT security");
            Console.WriteLine("    - smart home");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n  ONLINE SAFETY");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    - children online safety");
            Console.WriteLine("    - elder fraud");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n  DATA PROTECTION");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    - data backup");
            Console.WriteLine("    - software updates");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n  GENERAL TIPS");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    - cybersecurity");
            Console.WriteLine("    - cybersecurity tips");
            Console.WriteLine("    - social media privacy");
            Console.WriteLine("    - identity theft");

            uiManager.DisplaySeparator();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  WHAT YOU CAN ASK:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    - Ask: tell me more for follow-up information");
            Console.WriteLine("    - Ask: how are you to check in with me");
            Console.WriteLine("    - Ask: what can you do to see my capabilities");
            Console.WriteLine("    - Tell me how you are feeling (good, worried, tired)");
            Console.WriteLine("    - Say: thank you and I will respond warmly");
            Console.ResetColor();

            uiManager.DisplaySeparator();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  {userName}, what would you like to learn about today?");
            Console.ResetColor();

            uiManager.DisplayColoredText("  Say 'exit' when you are done.", ConsoleColor.DarkGray);
            uiManager.DisplaySeparator();
        }
    }
}