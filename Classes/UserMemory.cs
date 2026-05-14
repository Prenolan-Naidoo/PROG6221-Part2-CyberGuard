// ====================================================================
// PROGRAMMING 2A (PROG6221) - POE PART 2
// ====================================================================
// STUDENT NAME: Prenolan Naidoo
// STUDENT NUMBER: ST10445908
// DATE: 5/14/2026
// ====================================================================
// CLASS: UserMemory
// DESCRIPTION: Stores user information for personalized responses
// ====================================================================
// REFERENCES :
// ====================================================================
// Troelsen, A. and Japikse, P. (2022). Pro C# 10 with .NET 6.
//     11th edn. New York: Apress. [Online]. Available at:
//     https://www.apress.com/ (Accessed: 14 May 2026).
//
// Albahari, J. and Albahari, B. (2022). C# 10 in a Nutshell.
//     2nd edn. Sebastopol: O'Reilly Media. [Online]. Available at:
//     https://www.oreilly.com/ (Accessed: 14 May 2026).
//
// McTear, M., Callejas, Z. and Griol, D. (2016). The Conversational Interface:
//     Talking to Smart Devices. Cham: Springer International Publishing.
// ====================================================================

using System;
using System.Collections.Generic;

namespace CyberGuardChatbot.Classes
{
    /// <summary>
    /// Manages user memory for personalized chatbot interactions
    /// </summary>
    public class UserMemory
    {
        // Stores user's name
        public string UserName { get; set; } = "Friend";

        // Current topic being discussed
        public string CurrentTopic { get; set; } = string.Empty;

        // User's favorite cybersecurity topic
        public string FavoriteTopic { get; set; } = string.Empty;

        // Whether user wants more information
        public bool AwaitingMoreInfo { get; set; } = false;

        // Count of tips given
        public int TipsGivenCount { get; set; } = 0;

        // Dictionary for additional preferences
        private Dictionary<string, string> preferences = new Dictionary<string, string>();

        /// <summary>
        /// Stores a user preference
        /// </summary>
        public void StorePreference(string key, string value)
        {
            if (preferences.ContainsKey(key))
                preferences[key] = value;
            else
                preferences.Add(key, value);
        }

        /// <summary>
        /// Gets a stored preference
        /// </summary>
        public string GetPreference(string key)
        {
            return preferences.ContainsKey(key) ? preferences[key] : string.Empty;
        }

        /// <summary>
        /// Returns a summary of what the chatbot remembers
        /// </summary>
        public string GetMemorySummary()
        {
            string summary = $"I remember your name is {UserName}. ";
            if (!string.IsNullOrEmpty(FavoriteTopic))
                summary += $"You're interested in {FavoriteTopic}. ";
            if (TipsGivenCount > 0)
                summary += $"I've shared {TipsGivenCount} tips with you. ";
            return summary;
        }
    }
}