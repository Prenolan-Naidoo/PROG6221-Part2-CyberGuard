// ====================================================================
// PROGRAMMING 2A (PROG6221) - POE PART 1
// ====================================================================
// STUDENT NAME: Prenolan Naidoo
// STUDENT NUMBER: ST10445908
// DATE: 5/12/2026
// ====================================================================
// CLASS: ConsoleHelper
// DESCRIPTION: Provides helper methods for console UI formatting,
//              including colored text, typing effects, and dividers.
// ====================================================================
// REFERENCES:
// Stephens, R. (2021). C# 9.0 Programmer's Reference. Indianapolis:
//     John Wiley & Sons. [Online]. Available at:
//     https://www.wiley.com/ (Accessed: 12 May 2026).
// ====================================================================

using System;
using System.Threading;

namespace CyberGuardChatbot.Classes
{
    /// <summary>
    /// Static helper class for console user interface enhancements.
    /// Provides methods for colored output, typewriter effects, and
    /// decorative borders to improve user experience.
    /// </summary>
    /// <remarks>
    /// All methods are static to allow direct calling without instantiation.
    /// This class follows the Singleton pattern implicitly through static methods.
    /// </remarks>
    public static class ConsoleHelper
    {
        // Default typing delay in milliseconds (Albahari, 2022)
        private const int DEFAULT_TYPING_DELAY = 35;

        /// <summary>
        /// Writes colored text to the console output.
        /// </summary>
        /// <param name="text">The string text to display</param>
        /// <param name="color">The ConsoleColor to apply to the text</param>
        /// <param name="newLine">If true, appends a newline character (default: true)</param>
        public static void WriteColored(string text, ConsoleColor color, bool newLine = true)
        {
            Console.ForegroundColor = color;
            if (newLine)
                Console.WriteLine(text);
            else
                Console.Write(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Displays a success message in green color.
        /// </summary>
        /// <param name="message">The success message to display</param>
        public static void WriteSuccess(string message)
        {
            WriteColored($"[✓] {message}", ConsoleColor.Green);
        }

        /// <summary>
        /// Displays a warning message in yellow color.
        /// </summary>
        /// <param name="message">The warning message to display</param>
        public static void WriteWarning(string message)
        {
            WriteColored($"[!] {message}", ConsoleColor.Yellow);
        }

        /// <summary>
        /// Displays an error message in red color.
        /// </summary>
        /// <param name="message">The error message to display</param>
        public static void WriteError(string message)
        {
            WriteColored($"[✗] {message}", ConsoleColor.Red);
        }

        /// <summary>
        /// Displays an informational message in cyan color.
        /// </summary>
        /// <param name="message">The info message to display</param>
        public static void WriteInfo(string message)
        {
            WriteColored($"[i] {message}", ConsoleColor.Cyan);
        }

        /// <summary>
        /// Displays text with a typewriter animation effect.
        /// </summary>
        /// <param name="text">The text to display character by character</param>
        /// <param name="delay">Milliseconds between each character (default: 35)</param>
        /// <remarks>
        /// Creates a conversational feel by simulating human typing speed.
        /// The delay parameter can be adjusted for faster or slower typing.
        /// </remarks>
        public static void TypewriterEffect(string text, int delay = DEFAULT_TYPING_DELAY)
        {
            foreach (char character in text)
            {
                Console.Write(character);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Displays colored text with a typewriter animation effect.
        /// </summary>
        /// <param name="text">The text to display</param>
        /// <param name="color">The color of the text</param>
        /// <param name="delay">Milliseconds between each character (default: 35)</param>
        public static void TypewriterEffectColored(string text, ConsoleColor color, int delay = DEFAULT_TYPING_DELAY)
        {
            Console.ForegroundColor = color;
            foreach (char character in text)
            {
                Console.Write(character);
                Thread.Sleep(delay);
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Displays a thick decorative divider line.
        /// </summary>
        public static void DisplayDivider()
        {
            WriteColored("════════════════════════════════════════════════════════════════════════════════════════════════════", ConsoleColor.DarkCyan);
        }

        /// <summary>
        /// Displays a thin decorative divider line.
        /// </summary>
        public static void DisplayThinDivider()
        {
            WriteColored("────────────────────────────────────────────────────────────────────────────────────────────────────", ConsoleColor.DarkGray);
        }

        /// <summary>
        /// Displays a section header with decorative borders.
        /// </summary>
        /// <param name="title">The section title text</param>
        public static void DisplaySectionHeader(string title)
        {
            Console.WriteLine();
            DisplayDivider();
            WriteColored($"  {title}", ConsoleColor.Yellow);
            DisplayDivider();
            Console.WriteLine();
        }

        /// <summary>
        /// Waits for user to press any key before continuing.
        /// </summary>
        /// <param name="message">Optional custom message (default: "Press any key to continue...")</param>
        public static void WaitForKey(string message = "Press any key to continue...")
        {
            WriteColored($"\n{message}", ConsoleColor.DarkGray);
            Console.ReadKey(true);
        }

        /// <summary>
        /// Clears the console screen and resets colors to default.
        /// </summary>
        public static void ClearConsole()
        {
            Console.Clear();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}