// ====================================================================
// PROGRAMMING 2A (PROG6221) - POE PART 1
// ====================================================================
// STUDENT NAME: Prenolan Naidoo
// STUDENT NUMBER: ST10445908
// DATE: 5/14/2026
// ====================================================================
// CLASS: Logo
// DESCRIPTION: Displays ASCII art logo for the chatbot's visual branding.
// ====================================================================
// REFERENCES:
// Nagel, C. (2023). Professional C# and .NET 8. Hoboken: John Wiley & Sons.
//     [Online]. Available at: https://www.wiley.com/ (Accessed: 12 May 2026).
// ====================================================================

using System;

namespace CyberGuardChatbot.Classes
{
    /// <summary>
    /// Static class responsible for displaying the ASCII art logo.
    /// Creates a visual brand identity for the CyberGuard chatbot.
    /// </summary>
    /// <remarks>
    /// The ASCII art was designed to represent cybersecurity with a shield-like
    /// appearance and the word "CYBERGUARD" integrated into the design.
    /// </remarks>
    public static class Logo
    {
        /// <summary>
        /// Displays the ASCII art logo in cyan color.
        /// </summary>
        /// <remarks>
        /// The logo is displayed at application startup to create
        /// a professional first impression for users.
        /// </remarks>
        public static void Display()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            string logo = @"
╔══════════════════════════════════════════════════════════════════════════════════════════════════════╗
║                                                                                                      ║
║      ██████╗██╗   ██╗██████╗ ███████╗██████╗  ██████╗ ██╗   ██╗ █████╗ ██████╗ ██████╗                ║
║     ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗██╔════╝ ██║   ██║██╔══██╗██╔══██╗██╔══██╗               ║
║     ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝██║  ███╗██║   ██║███████║██████╔╝██║  ██║               ║
║     ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗██║   ██║██║   ██║██╔══██║██╔══██╗██║  ██║               ║
║     ╚██████╗   ██║   ██████╔╝███████╗██║  ██║╚██████╔╝╚██████╔╝██║  ██║██║  ██║██████╔╝               ║
║      ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═════╝                ║
║                                                                                                      ║
║                       C Y B E R S E C U R I T Y   A W A R E N E S S                                  ║
║                              A S S I S T A N T   C H A T B O T                                       ║
║                                                                                                      ║
║                         Protecting South African Citizens Online                                      ║
║                                                                                                      ║
║            ┌─────────────────────────────────────────────────────────────────────────┐              ║
║            │  Phishing Protection  │  Password Safety  │  Link Security  │  Scam Alert  │              ║
║            └─────────────────────────────────────────────────────────────────────────┘              ║
║                                                                                                      ║
╚══════════════════════════════════════════════════════════════════════════════════════════════════════╝
";

            Console.WriteLine(logo);
            Console.ResetColor();

            // Pause briefly for visual effect (Skeet, 2019)
            System.Threading.Thread.Sleep(1500);
        }
    }
}