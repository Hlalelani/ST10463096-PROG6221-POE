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
        }  // <-- FIXED: Added missing brace for Start()

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
            uiManager.DisplayChatbotMessage($"Hello {userName}! I'm your Cybersecurity Awareness Assistant.");
            uiManager.DisplayChatbotMessage("I'm here to help you stay safe online.");
            uiManager.DisplaySeparator();
            DisplayHelp();

            while (isRunning)
            {
                uiManager.DisplayColoredText($"\n{userName}: ", ConsoleColor.Yellow);
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
                uiManager.DisplayChatbotMessage($"Goodbye {userName}! Stay safe online!");
                isRunning = false;
                return;
            }

            if (lowerInput == "help" || lowerInput == "menu" || lowerInput == "options")
            {
                DisplayHelp();
                return;
            }

            string response = responseHandler.GetResponse(lowerInput, userName);

            if (response != null)
            {
                uiManager.DisplayChatbotMessage(response);
            }
            else
            {
                uiManager.DisplayDefaultResponse();
            }
        }  // <-- FIXED: Added missing brace for ProcessUserInput()

        private void DisplayHelp()
        {
            uiManager.DisplaySeparator();
            uiManager.DisplayColoredText("📚 What can I help you with?", ConsoleColor.Cyan);
            uiManager.DisplayColoredText("  • Password safety", ConsoleColor.White);
            uiManager.DisplayColoredText("  • Phishing scams", ConsoleColor.White);
            uiManager.DisplayColoredText("  • Safe browsing", ConsoleColor.White);
            uiManager.DisplayColoredText("  • Social engineering", ConsoleColor.White);
            uiManager.DisplayColoredText("  • Two-factor authentication", ConsoleColor.White);  // <-- FIXED: "Tow" -> "Two"
            uiManager.DisplayColoredText("  • General cybersecurity tips", ConsoleColor.White);

            uiManager.DisplayChatbotMessage("Just ask me about any of these topics!");
            uiManager.DisplayColoredText("\nType 'exit' to leave or 'help' to see this menu again.", ConsoleColor.Gray);  // <-- FIXED: "tp" -> "to"

            uiManager.DisplaySeparator();
        }
    }
}