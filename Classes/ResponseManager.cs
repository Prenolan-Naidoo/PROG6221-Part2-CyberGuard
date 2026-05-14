// ====================================================================
// PROGRAMMING 2A (PROG6221) - POE PART 2
// ====================================================================
// STUDENT NAME: Prenolan Naidoo
// STUDENT NUMBER: ST10445908
// DATE: 5/14/2026
// ====================================================================
// CLASS: ResponseManager
// DESCRIPTION: Manages responses for cybersecurity topics
// ====================================================================
// REFERENCES :
// ====================================================================
// Nagel, C. (2023). Professional C# and .NET 8. Hoboken: John Wiley & Sons.
//     [Online]. Available at: https://www.wiley.com/ (Accessed: 14 May 2026).
//
// The use of List<T> for storing multiple response options was based on:
// Stephens, R. (2021). C# 9.0 Programmer's Reference. Indianapolis:
//     John Wiley & Sons. [Online]. Available at:
//     https://www.wiley.com/ (Accessed: 14 May 2026).
//
// Random response selection technique adapted from:
// Price, M. (2023). C# 12 and .NET 8 Modern Cross-Platform Development.
//     8th edn. New York: Packt Publishing. [Online]. Available at:
//     https://www.packtpub.com/ (Accessed: 14 May 2026).
// ====================================================================

using System;
using System.Collections.Generic;

namespace CyberGuardChatbot.Classes
{
    /// <summary>
    /// Manages responses including random selections for variety
    /// </summary>
    public class ResponseManager
    {
        private Random random = new Random();

        // Lists of random responses for different topics
        private List<string> phishingTips;
        private List<string> passwordTips;
        private List<string> scamTips;
        private List<string> privacyTips;

        public ResponseManager()
        {
            InitializeResponseLists();
        }

        private void InitializeResponseLists()
        {
            // Phishing tips for random selection
            phishingTips = new List<string>
            {
                "🔍 Phishing Red Flag #1: Urgent language like 'Your account will be closed NOW!' - scammers create panic!",
                "🔍 Phishing Red Flag #2: Check the sender's email address - 'bank-verify@gmail.com' is NOT your bank!",
                "🔍 Phishing Red Flag #3: Poor spelling and grammar - legitimate companies proofread their emails.",
                "🔍 Phishing Red Flag #4: Unexpected attachments - don't open invoices you didn't request!",
                "🔍 Phishing Red Flag #5: Requests for personal info - real companies already have your details!",
                "🔍 Phishing Red Flag #6: Hover over links before clicking to see where they really go!",
                "🔍 Phishing Red Flag #7: Too good to be true - you didn't win a prize you never entered!"
            };

            // Password tips for random selection
            passwordTips = new List<string>
            {
                "🔐 Create passwords with at least 12 characters - longer is stronger!",
                "🔐 Never use 'password123', 'admin', or your name as your password!",
                "🔐 Use a passphrase: 'Purple Elephant Jumps 7 Times!' - easy to remember!",
                "🔐 Don't reuse passwords - if one account gets hacked, others stay safe!",
                "🔐 Use a password manager to store all your unique passwords securely!",
                "🔐 Change important passwords every 3-6 months for better security!",
                "🔐 Enable Two-Factor Authentication (2FA) whenever possible!"
            };

            // Scam tips for random selection
            scamTips = new List<string>
            {
                "⚠️ Scammers pretend to be SARS, banks, or MTN/Vodacom - always verify the source!",
                "⚠️ Never share your OTP (One-Time PIN) with anyone - not even 'bank officials'!",
                "⚠️ If someone calls claiming to be from your bank, hang up and call the official number!",
                "⚠️ 'Free data' messages on WhatsApp are almost always scams to steal your info!",
                "⚠️ Report scams to SAPS at 10111 or the Cybersecurity Hub online!"
            };

            // Privacy tips for random selection
            privacyTips = new List<string>
            {
                "🛡️ Review your social media privacy settings - set posts to 'Friends only' where possible!",
                "🛡️ Don't post your location while on holiday - post after you get home!",
                "🛡️ Remove old apps that have access to your Facebook or Google account!",
                "🛡️ Use different email addresses for different purposes (banking vs shopping)!",
                "🛡️ Think before you post - once online, it's very hard to permanently delete!"
            };
        }

        /// <summary>
        /// Gets a random phishing tip
        /// </summary>
        public string GetRandomPhishingTip()
        {
            return phishingTips[random.Next(phishingTips.Count)];
        }

        /// <summary>
        /// Gets a random password tip
        /// </summary>
        public string GetRandomPasswordTip()
        {
            return passwordTips[random.Next(passwordTips.Count)];
        }

        /// <summary>
        /// Gets a random scam tip
        /// </summary>
        public string GetRandomScamTip()
        {
            return scamTips[random.Next(scamTips.Count)];
        }

        /// <summary>
        /// Gets a random privacy tip
        /// </summary>
        public string GetRandomPrivacyTip()
        {
            return privacyTips[random.Next(privacyTips.Count)];
        }

        /// <summary>
        /// Gets more information about current topic (for "tell me more")
        /// </summary>
        public string GetMoreInfo(string currentTopic)
        {
            switch (currentTopic?.ToLower())
            {
                case "phishing":
                    return GetRandomPhishingTip() + "\n\nWould you like another tip? Just ask!";
                case "password":
                    return GetRandomPasswordTip() + "\n\nWant more password advice? Just say 'another tip'!";
                case "scam":
                    return GetRandomScamTip() + "\n\nKeep learning about scams - knowledge is your best protection!";
                case "privacy":
                    return GetRandomPrivacyTip() + "\n\nYour privacy matters - every small step helps protect it!";
                default:
                    return GetRandomPhishingTip();
            }
        }
    }
}