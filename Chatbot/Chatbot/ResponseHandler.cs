using System;
using System.Collections.Generic;
using System.Globalization;


namespace CybersecurityChatbot
{
    public class ResponseHandler
    {
        private Dictionary<string, string> responses;

        private Random random;

        public ResponseHandler()
        {
            random = new Random();
            InitializeResponses();
        }
        private void InitializeResponses()
        {
            responses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                // greeting
                {"hello", "Hello there! how can i help you stay safe online today? " },
                {"hi", "Hi! Ready to learn about cybersecrity?"},
                {"hey", "Hey! lets talk about online safety." },
                // status question
                {"how are you", "i'm doing great! Always ready to help you stay secure online. How are you doing today?"},
                {"how are you doing", "i'm functioning perfectly! Cybersecurity is my passion. what would you like to learn about?" },
                // purpose question
                {"what is your purpose","my purose is to educate and protect South African citizens from cyber threats. I help people understand how to stay safe online!" },
                {"what can you do",  " I can teach you about password safety, phishing scams, safe browsing habits, social engineering and much more!"},
                {"what can i ask you about", "you can ask me about passwords, phishing emails, safe browsing, social engineerung, two-factor authentication," +
                "general cybersecurity tips and how to spot suspicious links! " },
                //about password creating and safe users
                {"password", "A strong password should be at least 12 characters long and include uppercase letters, lowercase letters, numbers and special symbols." +
                "Never reuse passwords across different websites!"},
                {"password","password safety tips:\n " },
                
            }
        }
    }
}