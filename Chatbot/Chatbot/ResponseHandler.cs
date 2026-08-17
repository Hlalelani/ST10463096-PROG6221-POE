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
                // ----- GREETINGS & STATUS -----
                { "hello", "Hello there! How can I help you stay safe online today?" },
                { "hi", "Hi! Ready to learn about cybersecurity?" },
                { "hey", "Hey! Let's talk about online safety." },
                { "how are you", "I'm doing great! Always ready to help you stay secure online. How are you doing today?" },
                { "how are you doing", "I'm functioning perfectly! Cybersecurity is my passion. What would you like to learn about?" },
                { "what is your purpose", "My purpose is to educate and protect South African citizens from cyber threats. I help people understand how to stay safe online!" },
                { "what can you do", "I can teach you about:\n• Passwords & authentication\n• Phishing & scams\n• Safe browsing & social media\n• Malware & viruses\n• Network security & VPNs\n• Data protection & backups\n• And much more! Ask me about any topic." },
                { "what can i ask you about", "You can ask about:\n• Password safety, 2FA\n• Phishing, scams, suspicious links\n• Safe browsing, VPN, public Wi-Fi\n• Malware, ransomware, antivirus\n• Social media privacy, identity theft\n• Software updates, backups\n• Mobile security, IoT, encryption\n• Quishing, Vishing, Smishing\n• AI scams, Deepfakes, SIM swap\nJust type a keyword!" },

                // ----- PASSWORDS & AUTHENTICATION -----
                { "password", "A strong password should be at least 12 characters long and include uppercase, lowercase, numbers, and special symbols. Never reuse passwords across different websites! Consider using a password manager." },
                { "password tips", "Password tips:\n• Use unique passwords for every account\n• Make them at least 12 characters\n• Include uppercase, lowercase, numbers, symbols\n• Avoid common words or personal info\n• Use a password manager (e.g., Bitwarden, LastPass)\n• Enable two-factor authentication (2FA) whenever possible" },
                { "password manager", "Password managers generate, store, and autofill strong passwords for you. Popular ones: Bitwarden (free & open‑source), 1Password, LastPass, and Dashlane. They encrypt your vault with a master password – make that one strong and memorable!" },
                { "password safety", "Password safety is crucial! Use a mix of characters, avoid personal info, change them regularly, and never share them. Multi‑factor authentication adds an extra layer of security." },
                { "password spraying", "Password spraying is a brute‑force attack where hackers try common passwords (like '123456') across many accounts. Use strong, unique passwords and enable 2FA to stop this." },
                { "credential stuffing", "Attackers use stolen credentials from one breach to try them on other sites. Never reuse passwords – use a password manager to generate unique ones for every account." },
                { "brute force", "Brute force attacks try millions of password combinations. Protect against them by using long, complex passwords and rate‑limiting / account lockout mechanisms on your accounts." },

                // ----- TWO-FACTOR & MFA -----
                { "two factor authentication", "Two-factor authentication (2FA) adds a second verification step – something you have (phone) or are (fingerprint). Even if someone steals your password, they can't get in without the second factor. Use authenticator apps (Google Authenticator, Authy) instead of SMS for better security." },
                { "2fa", "2FA is one of the best ways to protect accounts. Always enable it on email, banking, and social media. App‑based tokens are more secure than SMS. Remember to save backup codes in a safe place!" },
                { "multi factor authentication", "MFA uses multiple methods: something you know (password), something you have (phone), something you are (biometrics). The more layers, the harder it is for attackers to breach your accounts." },

                // ----- PHISHING & SCAMS -----
                { "phishing", " Phishing is when scammers impersonate legitimate organizations to steal your personal info. They often create fake emails or websites that look real. Never click on suspicious links or download attachments from unknown senders. Always check the sender's email address carefully." },
                { "phishing email", " Signs of a phishing email:\n• Urgent language demanding immediate action\n• Suspicious sender addresses (e.g., @gmail.com pretending to be a bank)\n• Poor grammar and spelling errors\n• Requests for personal info like passwords or credit card numbers\n• Unexpected attachments or links\nIf in doubt, contact the organisation directly via their official website." },
                { "phishing scam", " Phishing scams are dangerous. Always verify requests through official channels. Hover over links to see the real URL before clicking. Never share OTPs (one‑time passwords) with anyone – scammers often pretend to be bank or tech support." },
                { "quishing", " Quishing (QR code phishing) uses fake QR codes to direct you to malicious websites. Scammers place them on posters, emails, or parking meters. Always check the URL after scanning and avoid scanning codes from untrusted sources." },
                { "vishing", " Vishing (voice phishing) is a phone scam where attackers impersonate banks or authorities to steal personal info. They often create urgency – *'Your account is compromised, verify your OTP'*. Hang up and call the official number directly." },
                { "smishing", " Smishing (SMS phishing) uses text messages with fake links or requests. Never click links in texts from unknown numbers, and don't reply to requests for personal info. Legitimate organisations never ask for OTPs via SMS." },
                { "business email compromise", " BEC is a sophisticated scam targeting companies. Attackers impersonate CEOs or vendors to trick employees into transferring money or revealing sensitive data. Always verify urgent payment requests via a separate communication channel." },

                // ----- SUSPICIOUS LINKS -----
                { "suspicious link", " Suspicious links often have:\n• Misspelled domain names (e.g., gooogle.com)\n• Strange characters or numbers\n• Hidden URLs when you hover over them\n• Urgent language like 'Your account will be closed'\nAlways hover to see the destination before clicking. When in doubt, type the website address manually in your browser." },
                { "link", " Be careful with links in emails, messages, or social media. Use URL checkers like VirusTotal to scan suspicious links. Cybercriminals use URL shorteners (bit.ly, tinyurl) to hide malicious destinations – think twice before clicking." },

                // ----- SAFE BROWSING & PRIVACY -----
                { "browsing", " Safe browsing habits:\n• Always look for 'https' and a padlock in the address bar\n• Don't click on suspicious pop‑ups or ads\n• Keep your browser updated\n• Use ad‑blockers and privacy extensions (e.g., uBlock Origin, Privacy Badger)\n• Consider using a privacy‑focused browser like Firefox or Brave." },
                { "safe browsing", " Tips for safe browsing:\n• Use a reputable browser with built‑in security\n• Clear your cache and cookies regularly\n• Be cautious on public Wi‑Fi – use a VPN\n• Enable 'Do Not Track' and anti‑tracking features\n• Avoid downloading files from untrusted sites." },
                { "browser safety", " Keep your browser updated – updates patch security flaws. Use security extensions like HTTPS Everywhere to enforce encrypted connections. Disable third‑party cookies and consider using a sandbox or a separate profile for sensitive activities." },
                { "digital footprint", " Your digital footprint is the trail of data you leave online – posts, photos, comments, even what others post about you. Regularly review your privacy settings, Google your name, and remove outdated or sensitive info." },
                { "safe download", "⬇ Only download files from official websites or app stores. Avoid cracked software or pirated media – they often contain malware. Scan downloads with antivirus before opening." },

                // ----- SOCIAL MEDIA & IDENTITY -----
                { "social media privacy", " Protect your privacy on social media:\n• Set profiles to private\n• Avoid sharing your location, phone number, or ID documents publicly\n• Be cautious of quizzes and posts that ask for personal information (they may be used for security questions)\n• Review your friends/followers list regularly\n• Use strong, unique passwords for each social platform." },
                { "identity theft", " Identity theft occurs when someone steals your personal info (ID number, bank details, etc.) to commit fraud. Prevent it by:\n• Shredding sensitive documents\n• Monitoring your bank and credit reports\n• Not sharing personal info online\n• Using two‑factor authentication\n• Being cautious of unsolicited requests for your details." },
                { "oversharing", " Oversharing on social media gives attackers material for social engineering. Avoid posting your full name, birthdate, address, travel plans, and photos of ID documents. Scammers use this info to answer security questions or impersonate you." },
                { "OSINT", " Open Source Intelligence (OSINT) is the collection of publicly available info about you (social media, news, etc.). Attackers use it to craft convincing scams. Limit what you share publicly – less is better." },
                { "doxing", " Doxing is the malicious sharing of personal info (address, phone, etc.) to harass or threaten. Protect yourself by using privacy settings and avoiding oversharing online." },
                { "sextortion", " Sextortion is blackmail using intimate images or threats to expose them. Never share sensitive content with strangers, and report any threats to the police. Use strong privacy controls on social media." },

                // ----- MALWARE & THREATS -----
                { "malware", " Malware (malicious software) includes viruses, worms, ransomware, spyware, and trojans. It can steal data, encrypt files, or take control of your device. Protect yourself by:\n• Keeping software updated\n• Using antivirus software\n• Not downloading from untrusted sources\n• Being careful with email attachments and links." },
                { "ransomware", " Ransomware encrypts your files and demands payment to unlock them. It often spreads through phishing emails or malicious downloads. Protect yourself:\n• Regularly back up your important files offline\n• Keep your OS and software updated\n• Use a reputable antivirus with ransomware protection\n• Never pay the ransom – it encourages criminals and there's no guarantee you'll get your data back." },
                { "ransomware as a service", " Ransomware-as-a-Service (RaaS) is a criminal business model where hackers sell ransomware tools to other criminals. This makes ransomware more common. Regular offline backups and strong endpoint protection are your best defence." },
                { "virus", " A computer virus is a type of malware that attaches to legitimate files and spreads when you run them. Always scan downloads with antivirus, keep your system updated, and avoid opening suspicious email attachments." },
                { "trojan", "Trojan malware disguises itself as a legitimate program. Once installed, it can steal data, spy on you, or give attackers remote access. Download only from official app stores or trusted websites." },
                { "spyware", "Spyware secretly monitors your activity, capturing keystrokes, passwords, and browsing history. It can be hidden in free software or browser extensions. Use anti‑spyware tools, and review your installed programs regularly." },
                { "adware", "Adware floods your screen with unwanted ads and can track your browsing. It often comes bundled with free software. Use ad‑blockers and always choose 'custom installation' to avoid unwanted extras." },
                { "worm", "A worm is a self‑replicating malware that spreads across networks without user action. Keep your firewall enabled, update your system, and use strong passwords to prevent network‑based attacks." },
                { "zero day", " A zero‑day vulnerability is a software flaw unknown to the vendor – hackers exploit it before a patch exists. Protect yourself by keeping software updated, using a firewall, and limiting your exposure (e.g., disabling unnecessary services)." },
                { "supply chain attack", " Attackers compromise a trusted third‑party (like a software provider) to distribute malware to many victims. Regularly check for vendor security advisories and keep all software patched. Use only reputable vendors." },
                { "deepfake", " Deepfakes use AI to create realistic fake audio or video – used in scams to impersonate executives or loved ones. Always verify through a second channel (e.g., a phone call to a known number) before acting on unusual requests." },
                { "ai scam", " AI scams include automated phishing calls, chatbots impersonating customer support, and fake investment schemes. Be sceptical of unsolicited offers and always verify identities through official websites." },

                // ----- PROTECTION TOOLS -----
                { "antivirus", " Antivirus software detects and removes malicious software. Use a reputable one (e.g., Windows Defender, Bitdefender, Kaspersky, Avast) and keep it updated. Run regular scans and enable real‑time protection." },
                { "firewall", " A firewall monitors incoming and outgoing network traffic and blocks unauthorized access. Windows has a built‑in firewall – ensure it's enabled. For extra protection, consider a hardware firewall on your router." },
                { "vpn", " A VPN (Virtual Private Network) encrypts your internet traffic, hiding your activity from your ISP and protecting you on public Wi‑Fi. Use a trusted VPN service (e.g., ExpressVPN, NordVPN, ProtonVPN). Avoid free VPNs that may sell your data." },
                { "ad blocker", "Ad blockers (like uBlock Origin) block malicious ads and pop‑ups, reducing the risk of drive‑by downloads and phishing attempts. They also speed up your browsing and protect your privacy." },

                // ----- NETWORK & WI-FI -----
                { "public wi fi", " Public Wi‑Fi (in cafes, airports, etc.) is insecure – attackers can intercept your data. Protect yourself by:\n• Using a VPN\n• Avoiding sensitive transactions (banking, shopping) on public networks\n• Turning off file sharing\n• Using HTTPS websites\n• Forgetting the network after use." },
                { "secure wi fi", " Secure your home Wi‑Fi by:\n• Changing the default router password\n• Using WPA3 or WPA2 encryption\n• Hiding your SSID (network name)\n• Keeping your router's firmware updated\n• Disabling WPS (Wi‑Fi Protected Setup) to prevent brute‑force attacks." },
                { "hotspot", " When using your phone as a hotspot, set a strong password and use WPA2 encryption. Only share it with trusted people, and turn it off when not needed to prevent unauthorised access." },
                { "router security", "Your router is the gateway to your home network. Secure it by:\n• Changing the admin password\n• Updating firmware regularly\n• Disabling remote management\n• Using a guest network for visitors\n• Enabling logging to monitor unusual activity." },

                // ----- DATA PROTECTION & BACKUP -----
                { "data backup", " Backing up your data protects against ransomware, hardware failure, and accidental deletion. Follow the 3‑2‑1 rule:\n• 3 copies of your data (1 original + 2 backups)\n• 2 different storage media (e.g., external hard drive and cloud)\n• 1 copy stored off‑site (or in the cloud).\nSchedule automatic backups and test restores regularly." },
                { "software updates", " Keeping your operating system, apps, and antivirus updated is one of the easiest ways to stay secure. Updates patch known security holes. Enable automatic updates where possible, and don't ignore update notifications." },

                // ----- MOBILE SECURITY -----
                { "mobile security", " Protect your smartphone:\n• Use a strong passcode or biometric lock\n• Only install apps from official stores (Google Play, Apple App Store)\n• Review app permissions – why does a flashlight app need access to your contacts?\n• Keep your OS and apps updated\n• Enable remote tracking and wipe (Find My Device / Find My iPhone)\n• Avoid public USB charging stations – they can install malware." },
                { "app permissions", " When installing an app, carefully review the permissions it requests. If a game asks for your location, contacts, or SMS, be suspicious. You can revoke permissions later via your device settings." },
                { "phone safety", " For phone safety:\n• Don't click on links in SMS from unknown numbers\n• Beware of SIM swap scams – call your provider immediately if you lose signal unexpectedly\n• Use two‑factor authentication with app‑based tokens, not SMS, for critical accounts." },
                { "SIM swap", " In a SIM swap attack, criminals convince your mobile provider to move your number to their SIM, bypassing SMS‑based 2FA. Use app‑based authenticators (Google Authenticator) instead of SMS for 2FA, and set a PIN on your mobile account." },

                // ----- IOT & ADVANCED -----
                { "iot security", " IoT (Internet of Things) devices like smart cameras, thermostats, and assistants can be hacked. Secure them by:\n• Changing default passwords\n• Keeping firmware updated\n• Segmenting them on a separate network (guest Wi‑Fi)\n• Disabling unnecessary features (remote access, microphone)\n• Researching devices before buying – choose those with good security track records." },
                { "smart home", " Smart home devices (lights, locks, cameras) can be hacked. Change default passwords, update firmware, and consider a separate Wi‑Fi network for IoT devices to isolate them from your main devices." },
                { "encryption", " Encryption scrambles data so only authorised parties can read it. Ensure your devices (laptops, phones) use full‑disk encryption (e.g., BitLocker, FileVault). Use end‑to‑end encrypted messaging apps (Signal, WhatsApp) for private conversations." },
                { "zero trust", " Zero Trust is a security model that assumes no one is trusted by default – even inside your network. It means verifying every access request, using least‑privilege access, and continuously monitoring. For individuals, adopt a 'never trust, always verify' mindset for emails and links." },
                { "cloud security", " When using cloud services (Google Drive, iCloud, OneDrive), enable 2FA, use strong passwords, and review sharing settings. Encrypt sensitive files before uploading, and backup important data locally too." },

                // ----- CHILDREN & ELDERLY -----
                { "children online safety", " Protect children online by using parental controls, teaching them not to share personal info, and monitoring their activity. Have open conversations about online strangers and the risks of oversharing." },
                { "elder fraud", " Seniors are often targeted by tech support scams or fake grandchild emergencies. Educate elder relatives to never give remote access to unknown callers and to verify any urgent requests by calling a trusted family member." },

                // ----- ONLINE SHOPPING & EMAIL -----
                { "online shopping safety", " When shopping online:\n• Use secure payment methods (credit cards or PayPal) that offer fraud protection\n• Look for 'https' and the padlock before entering payment details\n• Avoid making purchases on public Wi‑Fi\n• Use a virtual credit card for extra safety\n• Check reviews and seller reputation\n• Save order confirmation emails and receipts." },
                { "email safety", " Protect your email inbox:\n• Enable 2FA on your email account\n• Be cautious of unexpected attachments even from known senders (their accounts may be hacked)\n• Use spam filters and report suspicious emails\n• Never reply to unsolicited requests for personal info\n• Use separate email addresses for different purposes (personal, banking, social media)." },

                // ----- GENERAL CYBERSECURITY TIPS -----
                { "cybersecurity", " Cybersecurity is everyone's responsibility! Key practices:\n• Use strong, unique passwords and a password manager\n• Enable 2FA on all important accounts\n• Keep software updated\n• Be careful with emails and links\n• Use antivirus and firewall\n• Back up your data\n• Limit what you share online\n• Use a VPN on public Wi‑Fi\n• Stay informed about new threats." },
                { "cybersecurity tips", " Top tips for South Africans:\n• Don't share personal info on social media\n• Be extra cautious with banking alerts – verify via official app\n• Regularly check your credit report for fraud\n• Use a secure DNS service (like Cloudflare 1.1.1.1)\n• Enable two‑factor on email and banking\n• Educate your family members – threats often spread through loved ones." },
                { "tips", " Quick cybersecurity checklist:\n• Think before you click\n• Question unusual requests (even from known contacts – their account may be hacked)\n• Protect your personal information\n• Keep devices and apps updated\n• Use a security tool (antivirus, firewall)\n• Avoid using the same password everywhere\n• Back up your important files.\nRemember: security is a habit, not a one‑time fix." },
                { "help", "I'm here to help! You can ask me about:\n• Passwords & 2FA\n• Phishing & scams (Quishing, Vishing, Smishing)\n• Safe browsing & VPNs\n• Malware & antivirus\n• Social media privacy & identity theft\n• Backups & updates\n• Mobile & IoT security\n• AI scams, Deepfakes, SIM swap, Zero‑day\n• Cloud security & digital footprint\nType any of these keywords to learn more!" },

                // ----- ACKNOWLEDGEMENTS -----
                { "okay", "Great! Is there anything specific you'd like to learn about?" },
                { "ok", "Awesome! What cybersecurity topic interests you?" },
                { "yes", "Excellent! What would you like to know more about?" },
                { "no", "No worries! Whenever you're ready, I'm here to help with cybersecurity awareness." },
                { "thank you", "You're welcome! Stay safe online and remember, cybersecurity is everyone's responsibility! 🛡️" },
                { "thanks", "You're welcome! Feel free to come back anytime if you have more cybersecurity questions." }
            };
        }

        public string GetResponse(string input, string userName)
        {
            // Clean the input
            string cleanInput = input.ToLower().Trim();

            // DIRECT MATCH - Check if the exact key exists
            if (responses.ContainsKey(cleanInput))
            {
                return responses[cleanInput];
            }

            // 1. Check if input contains any dictionary key (case‑insensitive)
            foreach (var pair in responses)
            {
                if (cleanInput.Contains(pair.Key.ToLower()))
                {
                    return pair.Value;
                }
            }

            // 2. Fallback patterns for combined queries
            if (cleanInput.Contains("how") && cleanInput.Contains("you"))
                return "I'm doing great! Always ready to help you stay secure online!";

            if (cleanInput.Contains("password") && cleanInput.Contains("safe"))
                return responses["password safety"];

            if (cleanInput.Contains("phish") || cleanInput.Contains("scam"))
                return responses["phishing"];

            if (cleanInput.Contains("brows") || cleanInput.Contains("web") || cleanInput.Contains("internet"))
                return responses["safe browsing"];

            if (cleanInput.Contains("social") && cleanInput.Contains("engineer"))
                return responses["social engineering"];

            if (cleanInput.Contains("2fa") || cleanInput.Contains("two factor") || cleanInput.Contains("2 factor"))
                return responses["2fa"];

            // 3. No match
            return null;
        }
    }
}