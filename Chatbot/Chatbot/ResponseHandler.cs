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
                {"password","password safety tips:\n Use unique passwords for each account\n Make them at least 1 2 characters long\n Include uppercase, lowercase, numbers, and " +
                "symbols\n Consider using a password manager\n Enable two-factor authentication when possible" },
                {"password manager","Password managers are excellent tools! They generate and store complex passwords for you. Popular options include LastPass, 1Password, and " +
                "Bitwarden. Just remember to use a strong master password!" },
                {"Password safety", "Password safety is crucial! Use a mix of characters, avoid personal information, change password regularly, and naver share them with anyone." +
                "Consider using multi-factor authentication for extra security" },

                // Phishing topics
                {"phishing","phishing is when scammers pretend to be legitimate organizations to steal your personal information. Never click on suspicious link or download attachments " +
                "from unknown senders. Always check the senders email address carefully!" },
                {"phishing email", "Signs of phishing email:\n Urgent language demanding immediate action\n Suspicious sender email addresses\n poor grammar and spelling\n" +
                "Requests for personal information\n Unexpected attachments or links" },
                {"Phishing scam", "Phishing scams are dangerous! always verify requests for sensitive information through official channels. When in doubt, conntact the organization" +
                "directly using their official website or phone number." },

                // safety of browsing online

                {"Browsing",  "Safe browsing haits:\n Always look for'https' in the URL\n Check for the padlock icon in the address bar\n Dont click on suspicious pop-ups\n keep your" +
                "browser updated\n Use ad-blockers and privacy extensions" },
                {"safe browsing","Tips for safe browsing:\n Use reputable browser with security features\n Clear your cache and cookies regularly\n Be cautious when using public" +
                "Wi-fi\n Use a VPN for additional privacy"},
                {"Browser Safety","Browser safety is essential! keep your browser updated, use security extensions and be careful what you download. Consider uaing browsers with" +
                "build in security features like chrome or firefox with security add-ons." },

                //Social engineering
                {"Social engineering","Social engineering is when attackers manipulate people into giving away sensitive information. They might pretend to be IT support, a colleague" +
                "Always verify identities before sharing information!" },
                {"Social engineering at tack","Social enginnering attacks can happen through phone calls, emails or even in person. if someone asks for your password or personal " +
                "information, take a moment to verify their identity. Legitimate organizations won't ask for sensitive information unexpected. " },

                // Suspicious links
                {"Suspicious link","Suspicious links often have:\n Misspelled domain names(like gooogle.com)\n Strange characters or numbers\n Hidden URLs when you hover over them\n" +
                "Urgent language in the message\n\nAlways hover over links to see the real destination before clicking!" },
                {"link","Be careful with links in emails and messages. Check the URL before clicking. Scammers use trchiques like URL shortening and domain spoofing to trick you. When in " +
                "doubt, type the website address manually in your browser." },

                // General tips
                {"Cybersecurity","Cybersecurity is everyone's responsibility! Key parctices include:\n Use strong, unique passwords\n keep software updated\n Be careful what you click\n " +
                "Use antivirus software\n Back up your data regularly." },
                {"Cybersecurity tips","Top cybersecurity tips for south Africans:\n Don't share personal information on social media\n Be cautious with public Wi-fi\n Regularly check your" +
                "bank statements\n Use security software\n stay informed about common scams" },
                {"Tips", "General cybersecurity tips\n Think before you click\n Question unusual requests\n protect your personal information\n keep devices updated\n use a security tool" +
                "or antivirus" },
                {"Helps","I'm here to help! you can ask me about passwords, pjishing, safe browsing, social engineering or tow-factor authentication. what would you like to learn about?" },

                // Tow-factor authentication
                {"two factor authentication","Two-factor authentication(2FA) adds an extra layer of security. Even if someone gets your password, they'll need a second verification method like a " +
                "code sent to your phone or an authenticator app. Always enable 2FA when it's available!" },
                {"Multi factor authentication","Multi-factor authetication(MFA) uses multiple verification methods. this could include something you know(password), something you have" +
                "(phone) and  something you are(fingerprint). The more layers the better!" },
                {"2fa","Two-factor authentication is one of the best ways to protect your accounts! Use authenticat or apps like Google Authenticator or Authy for the most secure exper" },
            };
        }




    }
}