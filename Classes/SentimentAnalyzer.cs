// ====================================================================
// PROGRAMMING 2A (PROG6221) - POE PART 2
// ====================================================================
// STUDENT NAME: Prenolan Naidoo
// STUDENT NUMBER: ST10445908
// DATE: 5/14/2026
// ====================================================================
// CLASS: SentimentAnalyzer
// DESCRIPTION: Detects user sentiment from text input
// ====================================================================
// REFERENCES :
// ====================================================================
// Liu, B. (2020). Sentiment Analysis: Mining Opinions, Sentiments, 
//     and Emotions. 2nd edn. Cambridge: Cambridge University Press.
//     [Online]. Available at: https://www.cambridge.org/ (Accessed: 14 May 2026).
//
// The keyword-based sentiment detection approach was adapted from:
// Hutto, C.J. and Gilbert, E.E. (2014). 'VADER: A Parsimonious Rule-based 
//     Model for Sentiment Analysis of Social Media Text', Proceedings of 
//     the 8th International Conference on Weblogs and Social Media, 
//     Ann Arbor, MI, June 1-4, pp. 216-225.
//
// Microsoft Corporation. (2024). 'String.Contains Method Documentation'.
//     Microsoft Learn. [Online]. Available at:
//     https://learn.microsoft.com/en-us/dotnet/api/system.string.contains
//     (Accessed: 14 May 2026).
// ====================================================================

using System;
using System.Collections.Generic;

namespace CyberGuardChatbot.Classes
{
    /// <summary>
    /// Analyzes user input to detect emotional sentiment
    /// </summary>
    public class SentimentAnalyzer
    {
        // Keywords for different sentiments
        private Dictionary<string, List<string>> sentimentKeywords;
        private Random random = new Random();

        public SentimentAnalyzer()
        {
            InitializeKeywords();
        }

        private void InitializeKeywords()
        {
            sentimentKeywords = new Dictionary<string, List<string>>();

            // Worried/anxious keywords
            sentimentKeywords["worried"] = new List<string>
            {
                "worried", "scared", "afraid", "nervous", "anxious",
                "concerned", "fear", "stress", "panic", "unsafe"
            };

            // Frustrated keywords
            sentimentKeywords["frustrated"] = new List<string>
            {
                "frustrated", "angry", "annoyed", "tired", "hate",
                "confusing", "difficult", "hard", "complicated", "stupid"
            };

            // Curious keywords
            sentimentKeywords["curious"] = new List<string>
            {
                "curious", "interested", "learn", "tell me", "explain",
                "how to", "what is", "why", "when", "teach me"
            };

            // Positive/grateful keywords
            sentimentKeywords["positive"] = new List<string>
            {
                "thank", "great", "good", "helpful", "useful",
                "awesome", "perfect", "excellent", "nice", "appreciate"
            };
        }

        /// <summary>
        /// Detects sentiment from user input
        /// </summary>
        public string DetectSentiment(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
                return "neutral";

            string lowerInput = userInput.ToLower();

            if (ContainsAnyKeyword(lowerInput, sentimentKeywords["worried"]))
                return "worried";
            if (ContainsAnyKeyword(lowerInput, sentimentKeywords["frustrated"]))
                return "frustrated";
            if (ContainsAnyKeyword(lowerInput, sentimentKeywords["curious"]))
                return "curious";
            if (ContainsAnyKeyword(lowerInput, sentimentKeywords["positive"]))
                return "positive";

            return "neutral";
        }

        /// <summary>
        /// Gets an empathetic response based on sentiment
        /// </summary>
        public string GetEmpatheticResponse(string sentiment, string userName)
        {
            switch (sentiment)
            {
                case "worried":
                    string[] worriedResponses = {
                        $"It's completely understandable to feel concerned, {userName}. Let me help you stay safe online.",
                        $"I hear your concern, {userName}. Cybersecurity can feel overwhelming, but we'll go through this step by step.",
                        $"Your safety matters, {userName}. It's good that you're thinking about these risks."
                    };
                    return worriedResponses[random.Next(worriedResponses.Length)];

                case "frustrated":
                    string[] frustratedResponses = {
                        $"I understand this can be frustrating, {userName}. Let me explain it more simply.",
                        $"Take a deep breath, {userName}. I'll make this as easy as possible for you.",
                        $"I know this can be annoying, {userName}. Let's break it down into smaller steps."
                    };
                    return frustratedResponses[random.Next(frustratedResponses.Length)];

                case "curious":
                    string[] curiousResponses = {
                        $"Great question, {userName}! I'm glad you're curious about staying safe online.",
                        $"That's an excellent topic to explore, {userName}. Here's what you should know.",
                        $"I love your curiosity, {userName}! Let me share some important information."
                    };
                    return curiousResponses[random.Next(curiousResponses.Length)];

                case "positive":
                    string[] positiveResponses = {
                        $"You're welcome, {userName}! I'm happy to help you stay cyber-safe.",
                        $"Thank you, {userName}! Stay safe out there and keep learning.",
                        $"It's my pleasure, {userName}! Being cyber-aware is a superpower."
                    };
                    return positiveResponses[random.Next(positiveResponses.Length)];

                default:
                    return $"I'm here to help you, {userName}. What would you like to learn about cybersecurity?";
            }
        }

        private bool ContainsAnyKeyword(string text, List<string> keywords)
        {
            foreach (string keyword in keywords)
            {
                if (text.Contains(keyword))
                    return true;
            }
            return false;
        }
    }
}