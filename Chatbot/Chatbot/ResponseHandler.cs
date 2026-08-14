using System;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class ResponseHandler
    {
        private Dictionary<string, string> responses;

        public ResponseHandler()
        {
            InitializeResponses();
        }

        private void InitializeResponses()
        {
            responses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                // ----- Greetings -----
                { "hello", "Hello there! How can I help you stay safe online today?" },
                { "hi", "Hi! Ready to learn about cybersecurity?" },
                { "hey", "Hey! Let's talk about online safety." },

                // ----- Status & Purpose -----
                { "how are you", "I'm doing great! Always ready to help you stay secure online. How are you doing today?" },
                { "how are you doing", "I'm functioning perfectly! Cybersecurity is my passion. What would you like to learn about?" },
                { "what is your purpose", "My purpose is to educate and protect South African citizens from cyber threats. I help people understand how to stay safe online!" },
                { "what can you do", "I can teach you about password safety, phishing scams, safe browsing habits, social engineering, and much more!" },
                { "what can i ask you about", "You can ask me about passwords, phishing, safe browsing, social engineering, two-factor authentication, and general cybersecurity tips." },

                // ----- Password Topics -----
                { "password", "A strong password should be at least 12 characters long and include uppercase, lowercase, numbers, and special symbols. Never reuse passwords across different websites!" },
                { "password tips", "🔐 Password tips:\n• Use unique passwords for each account\n• Make them at least 12 characters long\n• Include uppercase, lowercase, numbers, and symbols\n• Consider using a password manager\n• Enable two-factor authentication when possible" },
                { "password manager", "Password managers are excellent tools! They generate and store complex passwords for you. Popular options include LastPass, 1Password, and Bitwarden." },
                { "password safety", "🔐 Password safety is crucial! Use a mix of characters, avoid personal information, change passwords regularly, and never share them with anyone." },

                // ----- Phishing Topics -----
                { "phishing", "📧 Phishing is when scammers pretend to be legitimate organizations to steal your personal information. Never click on suspicious links or download attachments from unknown senders." },
                { "phishing email", "📧 Signs of a phishing email:\n• Urgent language demanding immediate action\n• Suspicious sender email addresses\n• Poor grammar and spelling\n• Requests for personal information\n• Unexpected attachments or links" },
                { "phishing scam", "🛑 Phishing scams are dangerous! Always verify requests for sensitive information through official channels. When in doubt, contact the organization directly." },

                // ----- Safe Browsing -----
                { "browsing", "🔒 Safe browsing habits:\n• Always look for 'https' in the URL\n• Check for the padlock icon in the address bar\n• Don't click on suspicious pop-ups\n• Keep your browser updated" },
                { "safe browsing", "🛡️ Tips for safe browsing:\n• Use a reputable browser with security features\n• Clear your cache and cookies regularly\n• Be cautious when using public Wi-Fi\n• Use a VPN for additional privacy" },
                { "browser safety", "🌐 Browser safety is essential! Keep your browser updated, use security extensions, and be careful what you download." },

                // ----- Social Engineering -----
                { "social engineering", "🎯 Social engineering is when attackers manipulate people into giving away sensitive information. They might pretend to be IT support, a colleague, or a trusted organization. Always verify identities before sharing information!" },
                { "social engineering attack", "⚠️ Social engineering attacks can happen through phone calls, emails, or even in person. If someone asks for your password or personal information, take a moment to verify their identity." },

                // ----- Suspicious Links -----
                { "suspicious link", "⚠️ Suspicious links often have:\n• Misspelled domain names (like gooogle.com)\n• Strange characters or numbers\n• Hidden URLs when you hover over them\n• Urgent language in the message\n\nAlways hover over links to see the real destination before clicking!" },
                { "link", "🔗 Be careful with links in emails and messages. Check the URL before clicking. Scammers use URL shortening and domain spoofing to trick you." },

                // ----- Two‑Factor Authentication -----
                { "two factor authentication", "📱 Two-factor authentication (2FA) adds an extra layer of security. Even if someone gets your password, they'll need a second verification method like a code sent to your phone or an authenticator app. Always enable 2FA when it's available!" },
                { "multi factor authentication", "🔐 Multi-factor authentication (MFA) uses multiple verification methods. This could include something you know (password), something you have (phone), and something you are (fingerprint). The more layers, the better!" },
                { "2fa", "📱 Two-factor authentication is one of the best ways to protect your accounts! Use authenticator apps like Google Authenticator or Authy for the most secure experience." },

                // ----- General Tips -----
                { "cybersecurity", "🔒 Cybersecurity is everyone's responsibility! Key practices include:\n• Use strong, unique passwords\n• Keep software updated\n• Be careful what you click\n• Use antivirus software\n• Back up your data regularly" },
                { "cybersecurity tips", "🛡️ Top cybersecurity tips for South Africans:\n• Don't share personal information on social media\n• Be cautious with public Wi-Fi\n• Regularly check your bank statements\n• Use security software\n• Stay informed about common scams" },
                { "tips", "💡 General cybersecurity tips:\n• Think before you click\n• Question unusual requests\n• Protect your personal information\n• Keep devices updated\n• Use security software" },

                // ----- Acknowledgements -----
                { "okay", "Great! Is there anything specific you'd like to learn about?" },
                { "ok", "Awesome! What cybersecurity topic interests you?" },
                { "yes", "Excellent! What would you like to know more about?" },
                { "no", "No worries! Whenever you're ready, I'm here to help with cybersecurity awareness." },
                { "thank you", "You're welcome! Stay safe online and remember, cybersecurity is everyone's responsibility! 🛡️" },
                { "thanks", "You're welcome! Feel free to come back anytime if you have more cybersecurity questions." },
                { "help", "I'm here to help! You can ask me about passwords, phishing, safe browsing, social engineering, or two-factor authentication. What would you like to learn about?" }
            };
        }

        public string GetResponse(string input, string userName)
        {
            // 1. First, check if the input contains any of the dictionary keys
            foreach (var pair in responses)
            {
                if (input.Contains(pair.Key.ToLower()))
                {
                    return pair.Value;
                }
            }

            // 2. If not found, try specific pattern checks (for safety)
            if (input.Contains("how") && input.Contains("you"))
                return "I'm doing great! Always ready to help you stay secure online!";

            if (input.Contains("password") && input.Contains("safe"))
                return responses["password safety"];

            if (input.Contains("phish") || input.Contains("scam"))
                return responses["phishing"];

            if (input.Contains("brows") || input.Contains("web") || input.Contains("internet"))
                return responses["safe browsing"];

            if (input.Contains("social") && input.Contains("engineer"))
                return responses["social engineering"];

            if (input.Contains("2fa") || input.Contains("two factor") || input.Contains("2 factor"))
                return responses["2fa"];

            // 3. No match – return null to trigger default response
            return null;
        }
    }
}