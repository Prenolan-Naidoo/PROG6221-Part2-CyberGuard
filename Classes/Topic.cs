// ====================================================================
// PROGRAMMING 2A (PROG6221) - POE PART 1
// ====================================================================
// ====================================================================
// STUDENT NAME: Prenolan Naidoo
// STUDENT NUMBER: ST10445908
// DATE: 5/14/2026
// ====================================================================
// CLASS: Topic
// DESCRIPTION: Data model class representing a cybersecurity topic
//              with title, description, and detailed content.
// ====================================================================

using System;

namespace CyberGuardChatbot.Classes
{
    /// <summary>
    /// Represents a cybersecurity educational topic with associated metadata.
    /// Used to store and manage detailed information about security subjects.
    /// </summary>
    /// <remarks>
    /// This class follows the Data Transfer Object (DTO) pattern and is designed
    /// to be easily expandable for Part 2 and Part 3 of the POE (Nagel, 2023).
    /// </remarks>
    public class Topic
    {
        // Auto-implemented properties (Troelsen & Japikse, 2022)

        /// <summary>
        /// Unique identifier for the topic (1 = Phishing, 2 = Passwords, 3 = Links)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Display title of the topic (e.g., "Phishing Emails")
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Brief description shown in menu options
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Full detailed educational content about the topic
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Parameterized constructor for creating Topic objects.
        /// </summary>
        /// <param name="id">Unique identifier</param>
        /// <param name="title">Display title</param>
        /// <param name="description">Brief description</param>
        /// <param name="details">Full content</param>
        public Topic(int id, string title, string description, string details)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.Details = details;
        }

        /// <summary>
        /// Default constructor required for collection initialization.
        /// </summary>
        public Topic() { }

        /// <summary>
        /// Returns a formatted string representation of the topic.
        /// </summary>
        /// <returns>Topic title and description</returns>
        public override string ToString()
        {
            return $"{Id}. {Title} - {Description}";
        }
    }
}