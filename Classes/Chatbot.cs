// ====================================================================
// PROGRAMMING 2A (PROG6221) - POE PART 1 & PART 2
// ====================================================================
// STUDENT NAME: Prenolan Naidoo
// STUDENT NUMBER: ST10445908
// DATE: 5/14/2026
// ====================================================================
// CLASS: Chatbot
// DESCRIPTION: Main chatbot class that handles user interactions,
//              keyword recognition, responses, and conversation flow.
//              This class has been enhanced for Part 2 to support
//              GUI integration, random responses, and memory features.
// ====================================================================
// REFERENCES:
// Albahari, J. and Albahari, B. (2022). C# 10 in a Nutshell.
//     2nd edn. Sebastopol: O'Reilly Media.
// Pieterse, H. (2021). 'The Cyber Threat Landscape in South Africa: 
//     A 10-Year Review', The African Journal of Information and 
//     Communication, 28(28). doi: 10.23962/10539/32213.
// ====================================================================

using System;
using System.Collections.Generic;
using System.Linq;

namespace CyberGuardChatbot.Classes
{
    /// <summary>
    /// Main chatbot engine that handles all user interactions, response generation,
    /// and conversation flow management for the cybersecurity awareness assistant.
    /// </summary>
    /// <remarks>
    /// This class implements keyword-based response matching, educational topic delivery,
    /// and maintains conversation state. For Part 2, it has been enhanced with
    /// additional methods for GUI integration and memory features (Albahari & Albahari, 2022).
    /// </remarks>
    public class Chatbot
    {
        // ================================================================
        // PROPERTIES
        // ================================================================

        /// <summary>
        /// Stores the user's name for personalized responses.
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// The name of the chatbot displayed to users.
        /// </summary>
        public string BotName { get; private set; } = "CyberGuard";

        /// <summary>
        /// Indicates whether the conversation is currently active.
        /// </summary>
        public bool IsRunning { get; private set; }

        // ================================================================
        // PUBLIC DICTIONARIES (Made public for Part 2 GUI access)
        // ================================================================

        /// <summary>
        /// Dictionary for keyword-based quick responses.
        /// Made public so the GUI can access it for Part 2 features.
        /// </summary>
        public Dictionary<string, string> quickResponses;

        /// <summary>
        /// Dictionary for detailed educational topics.
        /// </summary>
        public Dictionary<int, Topic> topics;

        // ================================================================
        // PRIVATE FIELDS
        // ================================================================

        // Audio manager for voice greeting
        private AudioManager audioManager;

        // Track if user has received initial greeting
        private bool hasReceivedGreeting = false;

        // Random number generator for varied responses
        private Random random = new Random();

        // ================================================================
        // CONSTRUCTOR
        // ================================================================

        /// <summary>
        /// Constructor - initializes all response dictionaries, topics,
        /// and audio components for the chatbot.
        /// </summary>
        public Chatbot()
        {
            InitializeQuickResponses();
            InitializeTopics();
            audioManager = new AudioManager();
            IsRunning = true;
        }

        // ================================================================
        // INITIALIZATION METHODS
        // ================================================================

        /// <summary>
        /// Initializes the dictionary of quick responses using keyword matching.
        /// </summary>
        /// <remarks>
        /// Uses case-insensitive string comparison to ensure user input
        /// is matched regardless of capitalization (Troelsen & Japikse, 2022).
        /// For Part 2, this dictionary is now public so the GUI can access it.
        /// </remarks>
        private void InitializeQuickResponses()
        {
            quickResponses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                // ========== GREETING RESPONSES ==========
                { "hello", $"Hello! I'm {BotName}, your cybersecurity awareness assistant. How can I help you today?" },
                { "hi", $"Hi there! I'm {BotName}. Ready to learn about staying safe online in South Africa?" },
                { "hey", $"Hey! {BotName} here. Ask me about passwords, phishing, or suspicious links!" },
                { "good morning", $"Good morning! {BotName} at your service. Let's start your day with cybersecurity awareness!" },
                { "good afternoon", $"Good afternoon! {BotName} here. Ready to boost your online safety knowledge?" },
                { "how are you", $"I'm functioning optimally, thank you for asking! I'm ready to help you stay cyber-safe." },
                
                // ========== PURPOSE & CAPABILITIES ==========
                { "what is your purpose", $"My purpose is to educate South African citizens about cybersecurity threats like phishing emails, unsafe passwords, and suspicious links. I'm part of a national initiative to improve online safety awareness (Pieterse, 2021)." },
                { "what can you do", $"I can teach you about:\n• Password safety and creating strong passwords\n• Identifying phishing emails and scams\n• Recognizing suspicious links\n• Two-Factor Authentication (2FA)\n• Reporting cybercrime in South Africa\n\nType 'menu' to see all topics!" },
                { "what can i ask", $"You can ask me about:\n• Password tips and safety\n• Phishing email detection\n• Suspicious link identification\n• South African banking scams\n• SARS-related fraud\n• General cybersecurity questions\n• Type 'menu' for educational topics!" },
                { "help", $"Need help? Here's what you can do:\n• Type 'menu' to see all cybersecurity topics\n• Ask me about 'passwords', 'phishing', or 'scams'\n• Type 'exit' to quit\n• Ask 'what can you do' for more options" },
                
                // ========== PASSWORD SAFETY RESPONSES ==========
                { "password", "Always use strong, unique passwords for each account! A strong password has at least 12 characters with a mix of uppercase, lowercase, numbers, and symbols. Never reuse passwords across different websites (NIST, 2020)." },
                { "strong password", "Create a strong password by:\n1. Using at least 12 characters\n2. Mixing uppercase and lowercase letters\n3. Including numbers and symbols\n4. Avoiding personal information\n5. Using a passphrase like 'Blue Elephant Jumps 7 Times!'" },
                { "password manager", "Password managers like Bitwarden, LastPass, or 1Password store all your passwords securely. You only need to remember one master password. This is highly recommended by cybersecurity experts (Pieterse, 2021)." },
                { "password tips", "🔐 TOP PASSWORD TIPS:\n• Never use 'password123' or 'admin'\n• Don't use your name or birthdate\n• Use a different password for each account\n• Change important passwords every 3-6 months\n• Enable Two-Factor Authentication whenever possible" },
                { "2fa", "Two-Factor Authentication (2FA) adds an extra security layer. After entering your password, you need a second verification method like an SMS code or authenticator app. Always enable 2FA on email, banking, and social media accounts!" },
                { "two factor", "Two-Factor Authentication (2FA) is one of the most effective ways to protect your accounts. It requires something you know (password) AND something you have (phone). Enable it wherever possible (Microsoft, 2024)." },
                
                // ========== PHISHING & SCAM RESPONSES ==========
                { "phishing", "Phishing is when scammers send fake emails pretending to be legitimate companies. Red flags include urgent language, poor spelling, suspicious sender addresses, and requests for personal information. Never click suspicious links!" },
                { "phishing email", "How to spot a phishing email:\n1. Check sender email address carefully\n2. Look for urgent or threatening language\n3. Watch for poor spelling and grammar\n4. Hover over links before clicking\n5. Never share personal information via email" },
                { "scam", "Common South African scams include:\n• Fake SARS refund emails\n• Bank security verification scams\n• 'You've won a prize' messages\n• WhatsApp 'free data' scams\n• Parcel delivery SMS scams\nAlways verify directly with the company!" },
                { "sassa", "SASSA will NEVER ask for your PIN or personal details via SMS, email, or phone. All SASSA communications come through official channels only. If you receive a suspicious message, report it to SASSA directly." },
                { "sars", "SARS will NEVER ask for your password, credit card details, or banking PIN via email. If you receive a suspicious SARS email, forward it to phishing@sars.gov.za and then delete it immediately (SARS, 2024)." },
                
                // ========== BANKING SECURITY RESPONSES ==========
                { "fnb", "FNB (First National Bank) will never ask for your password or full PIN via email, SMS, or phone calls. Always type fnb.co.za directly into your browser. If you receive a suspicious message, call FNB's fraud line on 087 575 9444." },
                { "capitec", "Capitec Bank will never ask for your remote PIN, app password, or card details via email or SMS. Only use the official Capitec app or type capitecbank.co.za. Report suspicious messages to phishing@capitecbank.co.za" },
                { "standard bank", "Standard Bank will never ask for your Internet Banking password or full card number. Always verify by calling their fraud department on 0800 020 600. Remember to type standardbank.co.za yourself (Standard Bank, 2024)." },
                { "absa", "ABSA will never request your PIN, password, or OTP via any communication. If you get a suspicious call claiming to be from ABSA, hang up and call their fraud line on 0860 100 372." },
                { "nedbank", "Nedbank will never ask for your online banking password or full card details via email or phone. Use the Nedbank Money app or type nedbank.co.za directly. Report scams to fraud@nedbank.co.za" },
                { "bank scam", "BANK SCAM RED FLAGS:\n• Calls claiming 'suspicious activity'\n• Emails asking you to 'verify' your account\n• Messages with urgent threats to close your account\n• Requests for your PIN or OTP\n• Links to fake banking websites\n\nAlways hang up and call your bank directly!" },
                
                // ========== LINK & URL SAFETY ==========
                { "suspicious link", "Before clicking any link:\n1. HOVER over it to see the real URL\n2. Check for misspellings (fnb-verify.com vs fnb.co.za)\n3. Look for strange domain extensions (.xyz, .top)\n4. NEVER click shortened links (bit.ly, tinyurl)\n5. When in doubt, type the address yourself!" },
                { "link safety", "LINK SAFETY CHECKLIST:\n✓ Hover before you click\n✓ Verify the domain name\n✓ Look for 'https://' (secure connection)\n✓ Be wary of urgent action messages\n✓ Type important website addresses manually\n✓ Use a link preview tool for shortened URLs" },
                { "url", "A legitimate URL for South African banks should:\n• End with .co.za (e.g., fnb.co.za)\n• Not contain extra words (fnb-verify.com is fake)\n• Have correct spelling\n• Use HTTPS (padlock icon in address bar)" },
                
                // ========== GENERAL CYBERSECURITY ==========
                { "safe online", "Top tips to stay safe online:\n1. Use strong, unique passwords\n2. Enable Two-Factor Authentication (2FA)\n3. Never click suspicious links\n4. Keep software updated\n5. Be skeptical of unsolicited messages\n6. Use antivirus software\n7. Back up important data (Pieterse, 2021)" },
                { "hacked", "IF YOU'VE BEEN HACKED:\n1. Change all passwords immediately\n2. Run a full antivirus scan\n3. Contact your bank if financial info was compromised\n4. Report to SAPS Cybercrime Unit (0860 123 123)\n5. Check for suspicious account activity\n6. Enable 2FA on all accounts" },
                { "report scam", "Report scams in South Africa:\n• SAPS Crime Stop: 08600 10111\n• Cybersecurity Hub: report.cybersecurityhub.gov.za\n• Bank Fraud Lines (call your bank)\n• SARS Phishing: phishing@sars.gov.za\n• Keep evidence (screenshots, emails)" },
                { "identity theft", "If you suspect identity theft:\n1. Contact your bank immediately\n2. Report to SAPS (get a case number)\n3. Check your credit report\n4. Contact the Credit Bureaus (Experian, TransUnion)\n5. Change all passwords\n6. Monitor your accounts closely" },
                
                // ========== EDUCATIONAL MENU ==========
                { "menu", "📚 EDUCATIONAL MENU:\n\nType 1 for PHISHING EMAILS\nType 2 for PASSWORD SAFETY\nType 3 for SUSPICIOUS LINKS\n\nEach topic provides detailed information to help you stay safe online!" },
                { "topics", "Available topics: 1-Phishing Emails, 2-Password Safety, 3-Suspicious Links. Type the number to learn more!" },
                
                // ========== EXIT & FAREWELL ==========
                { "bye", $"Stay safe online! Remember: Think before you click, use strong passwords, and enable 2FA. {BotName} signing off! 👋" },
                { "goodbye", $"Goodbye! Keep your digital life secure. Visit the Cybersecurity Hub website for more resources. Stay vigilant!" },
                { "thank you", $"You're welcome! Remember, cybersecurity is everyone's responsibility. Stay safe out there!" },
                { "thanks", $"My pleasure! Keep learning about online safety - it's your best defense against cyber threats." }
            };
        }

        /// <summary>
        /// Initializes the detailed educational topics for menu-based learning.
        /// </summary>
        /// <remarks>
        /// Each topic contains comprehensive information about specific
        /// cybersecurity threats and protection measures (Pieterse, 2021).
        /// </remarks>
        private void InitializeTopics()
        {
            topics = new Dictionary<int, Topic>();

            // Topic 1: Phishing Emails (Pieterse, 2021)
            topics.Add(1, new Topic(1, "PHISHING EMAILS",
                "Learn to identify fraudulent emails and protect your personal information",
                GetPhishingDetails()));

            // Topic 2: Password Safety (NIST, 2020)
            topics.Add(2, new Topic(2, "PASSWORD SAFETY",
                "Create strong passwords and manage them securely",
                GetPasswordDetails()));

            // Topic 3: Suspicious Links (Microsoft, 2024)
            topics.Add(3, new Topic(3, "SUSPICIOUS LINKS",
                "Spot dangerous URLs before clicking",
                GetLinkDetails()));
        }

        /// <summary>
        /// Returns detailed educational content about phishing emails.
        /// </summary>
        /// <returns>Formatted string with phishing education content</returns>
        private string GetPhishingDetails()
        {
            return @"
╔══════════════════════════════════════════════════════════════════════════════════════════════════════╗
║                                    PHISHING EMAILS - DETAILED GUIDE                                   ║
╠══════════════════════════════════════════════════════════════════════════════════════════════════════╣
║                                                                                                      ║
║  WHAT IS PHISHING?                                                                                   ║
║  ─────────────────                                                                                   ║
║  Phishing is a cybercrime where attackers disguise themselves as legitimate organizations            ║
║  to steal sensitive information such as passwords, credit card numbers, and personal data.           ║
║  In South Africa, phishing attacks increased by 300% in recent years (Pieterse, 2021).               ║
║                                                                                                      ║
║  7 CRITICAL RED FLAGS TO SPOT PHISHING EMAILS                                                        ║
║  ────────────────────────────────────────────────────                                                ║
║                                                                                                      ║
║  1️⃣ URGENT OR THREATENING LANGUAGE                                                                  ║
║     • 'Your account will be closed NOW!'                                                             ║
║     • 'Immediate action required'                                                                    ║
║     • 'You have 24 hours to respond'                                                                 ║
║                                                                                                      ║
║  2️⃣ SUSPICIOUS SENDER ADDRESS                                                                       ║
║     • Legitimate: fnb.co.za / sars.gov.za                                                            ║
║     • Fake: fnb-verify@gmail.com / sars-refund.xyz                                                   ║
║                                                                                                      ║
║  3️⃣ POOR SPELLING AND GRAMMAR                                                                       ║
║     • Legitimate companies proofread their communications                                            ║
║     • Watch for strange phrasing or typos                                                            ║
║                                                                                                      ║
║  4️⃣ UNEXPECTED ATTACHMENTS                                                                          ║
║     • Invoices you didn't request                                                                    ║
║     • Never open attachments from unknown sources!                                                   ║
║                                                                                                      ║
║  5️⃣ REQUESTS FOR PERSONAL INFORMATION                                                               ║
║     • 'Verify your password'                                                                         ║
║     • 'Confirm your ID number'                                                                       ║
║     • REAL COMPANIES ALREADY HAVE YOUR INFORMATION!                                                  ║
║                                                                                                      ║
║  6️⃣ SUSPICIOUS LINKS                                                                                ║
║     • Hover over any link to see the real destination                                                ║
║     • Look for misspelled URLs                                                                       ║
║                                                                                                      ║
║  7️⃣ TOO GOOD TO BE TRUE                                                                             ║
║     • 'You won R50,000!'                                                                             ║
║     • If it sounds too good to be true, it IS a scam!                                                ║
║                                                                                                      ║
║  SOUTH AFRICAN SCAMS TO WATCH                                                                        ║
║  ────────────────────────────                                                                        ║
║  • SASSA payment verification scams                                                                  ║
║  • Fake banking alerts (FNB, Capitec, Standard Bank)                                                 ║
║  • SARS tax refund email scams                                                                       ║
║  • 'Your parcel is waiting' SMS links                                                                ║
║                                                                                                      ║
║  REMEMBER: Legitimate companies will NEVER ask for your password via email!                          ║
║                                                                                                      ║
║  Source: Pieterse, H. (2021). The Cyber Threat Landscape in South Africa: A 10-Year Review.          ║
║                                                                                                      ║
╚══════════════════════════════════════════════════════════════════════════════════════════════════════╝
";
        }

        /// <summary>
        /// Returns detailed educational content about password safety.
        /// </summary>
        /// <returns>Formatted string with password safety education content</returns>
        private string GetPasswordDetails()
        {
            return @"
╔══════════════════════════════════════════════════════════════════════════════════════════════════════╗
║                              SAFE PASSWORD PRACTICES - DETAILED GUIDE                                 ║
╠══════════════════════════════════════════════════════════════════════════════════════════════════════╣
║                                                                                                      ║
║  WHY PASSWORD SAFETY MATTERS                                                                         ║
║  ──────────────────────────                                                                          ║
║  Weak passwords are the number one way hackers gain access to accounts. In South Africa,             ║
║  password-related breaches increased by 45% in 2024 (Pieterse, 2021).                                ║
║                                                                                                      ║
║  BEST PRACTICES FOR STRONG PASSWORDS - NIST GUIDELINES (2020)                                        ║
║  ──────────────────────────────────────────────────────────────                                      ║
║                                                                                                      ║
║  1️⃣ USE LONG PASSWORDS (Minimum 12 characters)                                                      ║
║  2️⃣ MIX CHARACTER TYPES (Uppercase, lowercase, numbers, symbols)                                    ║
║  3️⃣ NEVER REUSE PASSWORDS (Each account needs unique password)                                      ║
║  4️⃣ USE A PASSWORD MANAGER (Bitwarden, LastPass, 1Password)                                         ║
║  5️⃣ ENABLE TWO-FACTOR AUTHENTICATION (2FA)                                                          ║
║                                                                                                      ║
║  HOW TO CREATE A STRONG PASSPHRASE                                                                    ║
║  ───────────────────────────────                                                                     ║
║  Example: 'Blue Elephant Jumps Over 7 Hills!'                                                        ║
║  This is easy to remember but very hard for hackers to crack!                                        ║
║                                                                                                      ║
║  Source: NIST (2020). Digital Identity Guidelines.                                                   ║
║                                                                                                      ║
╚══════════════════════════════════════════════════════════════════════════════════════════════════════╝
";
        }

        /// <summary>
        /// Returns detailed educational content about suspicious links.
        /// </summary>
        /// <returns>Formatted string with link safety education content</returns>
        private string GetLinkDetails()
        {
            return @"
╔══════════════════════════════════════════════════════════════════════════════════════════════════════╗
║                             SUSPICIOUS LINKS - DETAILED GUIDE                                         ║
╠══════════════════════════════════════════════════════════════════════════════════════════════════════╣
║                                                                                                      ║
║  WHY LINK SAFETY MATTERS                                                                             ║
║  ─────────────────────────                                                                           ║
║  Over 90% of cyber attacks start with a malicious link (Verizon, 2024).                              ║
║                                                                                                      ║
║  HOW TO CHECK A LINK SAFELY                                                                          ║
║  ─────────────────────────                                                                           ║
║  ON COMPUTER: HOVER over the link - look at bottom-left corner                                       ║
║  ON PHONE: LONG-PRESS the link - select 'Preview'                                                    ║
║                                                                                                      ║
║  RED FLAGS FOR SUSPICIOUS LINKS                                                                      ║
║  ───────────────────────────────                                                                     ║
║  • Wrong domain (fnb-verify.com vs fnb.co.za)                                                        ║
║  • Misspellings (amaz0n.com, faceb00k.com)                                                           ║
║  • Strange extensions (.xyz, .top, .club)                                                            ║
║  • Shortened links (bit.ly, tinyurl)                                                                 ║
║                                                                                                      ║
║  GOLDEN RULE: WHEN IN DOUBT, DO NOT CLICK!                                                           ║
║                                                                                                      ║
║  Source: Verizon (2024). Data Breach Investigations Report.                                          ║
║                                                                                                      ║
╚══════════════════════════════════════════════════════════════════════════════════════════════════════╝
";
        }

        // ================================================================
        // PUBLIC METHODS FOR PART 1 (Console Version)
        // ================================================================

        /// <summary>
        /// Starts the chatbot conversation and handles the main interaction loop.
        /// Used by the console version (Part 1).
        /// </summary>
        public void Start()
        {
            // Play voice greeting
            audioManager.PlayGreeting();

            // Display welcome message
            ConsoleHelper.TypewriterEffectColored("Welcome to CyberGuard!", ConsoleColor.Green, 40);
            ConsoleHelper.TypewriterEffect($"Your personal cybersecurity awareness assistant.", 35);
            Console.WriteLine();

            // Get user name
            GetUserName();

            // Show personalized welcome
            ConsoleHelper.WriteSuccess($"Welcome, {UserName}!");
            ConsoleHelper.WriteInfo($"I'm {BotName}, and I'll help you learn about online safety.\n");

            // Display menu
            DisplayMenu();

            // Main conversation loop
            RunConversationLoop();
        }

        /// <summary>
        /// Prompts the user for their name and validates input.
        /// </summary>
        private void GetUserName()
        {
            bool validName = false;

            while (!validName)
            {
                ConsoleHelper.WriteColored("Please enter your name: ", ConsoleColor.White, false);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    ConsoleHelper.WriteError("Name cannot be empty. Please try again.");
                }
                else if (input.Length > 50)
                {
                    ConsoleHelper.WriteWarning("Name is too long. Please use a shorter name.");
                }
                else
                {
                    UserName = input.Trim();
                    validName = true;
                }
            }
        }

        /// <summary>
        /// Displays the main menu with available topics.
        /// </summary>
        private void DisplayMenu()
        {
            ConsoleHelper.DisplaySectionHeader("📚 CYBERSECURITY LEARNING MENU");

            ConsoleHelper.WriteColored("  1. PHISHING EMAILS", ConsoleColor.Green);
            ConsoleHelper.WriteColored("     Learn to identify and avoid email scams", ConsoleColor.DarkGray);
            Console.WriteLine();

            ConsoleHelper.WriteColored("  2. PASSWORD SAFETY", ConsoleColor.Green);
            ConsoleHelper.WriteColored("     Create strong passwords and keep accounts secure", ConsoleColor.DarkGray);
            Console.WriteLine();

            ConsoleHelper.WriteColored("  3. SUSPICIOUS LINKS", ConsoleColor.Green);
            ConsoleHelper.WriteColored("     Spot dangerous links before clicking", ConsoleColor.DarkGray);
            Console.WriteLine();

            ConsoleHelper.DisplayThinDivider();
            ConsoleHelper.WriteColored("  Type a number (1, 2, or 3) to learn about a topic", ConsoleColor.White);
            ConsoleHelper.WriteColored("  Type 'exit' to quit", ConsoleColor.White);
            ConsoleHelper.DisplayDivider();
            Console.WriteLine();
        }

        /// <summary>
        /// Runs the main conversation loop until user exits.
        /// Used by the console version (Part 1).
        /// </summary>
        private void RunConversationLoop()
        {
            while (IsRunning)
            {
                ConsoleHelper.WriteColored($"\n{UserName}: ", ConsoleColor.White, false);
                string userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    ConsoleHelper.WriteWarning("Please type something. I'm here to help!");
                    continue;
                }

                string response = ProcessConsoleInput(userInput);

                if (response == "EXIT")
                {
                    ConsoleHelper.WriteColored($"\n{BotName}: ", ConsoleColor.Cyan, false);
                    ConsoleHelper.TypewriterEffectColored($"Stay safe online, {UserName}! Remember: think before you click! 👋", ConsoleColor.Green);
                    IsRunning = false;
                    break;
                }

                ConsoleHelper.WriteColored($"{BotName}: ", ConsoleColor.Cyan, false);

                if (response.Contains("╔") || response.Contains("════"))
                {
                    ConsoleHelper.WriteColored(response, ConsoleColor.White);
                }
                else
                {
                    ConsoleHelper.TypewriterEffect(response, 30);
                }
            }
        }

        /// <summary>
        /// Processes console input for Part 1.
        /// </summary>
        private string ProcessConsoleInput(string userInput)
        {
            string lowerInput = userInput.ToLower().Trim();

            if (lowerInput == "exit" || lowerInput == "quit" || lowerInput == "goodbye")
            {
                return "EXIT";
            }

            if (lowerInput == "1" || lowerInput == "one" || lowerInput == "phishing")
            {
                return topics[1].Details;
            }
            else if (lowerInput == "2" || lowerInput == "two" || lowerInput == "password")
            {
                return topics[2].Details;
            }
            else if (lowerInput == "3" || lowerInput == "three" || lowerInput == "links")
            {
                return topics[3].Details;
            }

            if (lowerInput == "menu" || lowerInput == "topics")
            {
                DisplayMenu();
                return "What would you like to learn about? Type a number!";
            }

            string keywordResponse = GetKeywordResponse(userInput);
            if (keywordResponse != null)
            {
                return keywordResponse;
            }

            return GetDefaultResponse();
        }

        /// <summary>
        /// Returns a default response for unrecognized input.
        /// </summary>
        private string GetDefaultResponse()
        {
            string[] defaultResponses = {
                $"I'm not sure I understand, {UserName}. Could you rephrase that?",
                $"Hmm, I didn't quite get that. Try asking me about passwords or phishing!",
                $"Type 'menu' to see what I can teach you about.",
                $"Ask me about password safety, phishing emails, or suspicious links."
            };
            return defaultResponses[random.Next(defaultResponses.Length)];
        }

        // ================================================================
        // PUBLIC METHODS FOR PART 2 (GUI Version)
        // ================================================================

        /// <summary>
        /// Gets a response based on keyword recognition.
        /// This method is called by the GUI to process user input.
        /// </summary>
        /// <param name="userInput">The user's input text</param>
        /// <returns>A response string based on keyword matching, or null if no match</returns>
        public string GetKeywordResponse(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
                return null;

            string lowerInput = userInput.ToLower();

            // Check each keyword in the quickResponses dictionary
            foreach (var keyword in quickResponses.Keys)
            {
                if (lowerInput.Contains(keyword.ToLower()))
                {
                    string response = quickResponses[keyword];
                    // Replace placeholders with actual values
                    response = response.Replace("{UserName}", UserName);
                    response = response.Replace("{BotName}", BotName);
                    return response;
                }
            }

            return null;
        }

        /// <summary>
        /// Sets the user name (called from GUI).
        /// </summary>
        /// <param name="name">The user's name</param>
        public void SetUserName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                UserName = name.Trim();
            }
        }

        /// <summary>
        /// Gets a random cybersecurity tip (for Part 2 features).
        /// </summary>
        /// <returns>A random tip string</returns>
        public string GetRandomTip()
        {
            string[] tips = {
                "Use a password manager to generate and store strong passwords!",
                "Enable 2FA on all your important accounts - it blocks 99.9% of attacks!",
                "Never share your OTP (One-Time PIN) with anyone, even if they claim to be from your bank!",
                "Hover over links before clicking to see where they really go!",
                "SARS will never ask for your password or credit card via email!",
                "Check your bank statements regularly for unauthorized transactions!"
            };
            return tips[random.Next(tips.Length)];
        }

        /// <summary>
        /// Gets detailed topic information by ID.
        /// </summary>
        /// <param name="topicId">The topic ID (1, 2, or 3)</param>
        /// <returns>The topic details or null if not found</returns>
        public string GetTopicDetails(int topicId)
        {
            if (topics.ContainsKey(topicId))
            {
                return topics[topicId].Details;
            }
            return null;
        }
    }
}