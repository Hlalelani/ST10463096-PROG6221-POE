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

        public void start()
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
                uiManager.DisplayColoredText("Please enter your name:  ", ConsoleColor.Cyan);

                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) )
                {
                    uiManager.DisplayError("Name cannot be empty. Please try age in. ");

                    continue;
                }
                if (input.Length > 50)
                {
                    uiManager.DisplayError("Name is too long. please enter a shorter name.");
                    continue;
                }
                bool isValid = true;
                foreach ( char c in input )
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
            uiManager.DisplayChatbotMessage($"Hello {userName} ! I'M your Cybersecurity Awareness Assistant.");
            uiManager.DisplayChatbotMessage("I'm here to help you stay safe online.");

            uiManager.DisplaySeparator();

            DisplayHelp();

            while (isRunning)
            {
                uiManager.DisplayColoredText($"\n{userName}:  ", ConsoleColor.Yellow);

                string userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    uiManager.DisplayError("I didn't catch that. please type something.");

                    continue;
                }
            }
        }
}
