// ====================================================================
// PROGRAMMING 2A (PROG6221) - POE PART 1
// ====================================================================
// STUDENT NAME: Prenolan Naidoo
// STUDENT NUMBER: ST10445908
// DATE: 5/14/2026
// ====================================================================
// CLASS: AudioManager
// DESCRIPTION: Manages audio playback for the chatbot's voice greeting,
//              including file handling and error management.
// ====================================================================
// REFERENCES:
// Microsoft Corporation. (2024). System.Media.SoundPlayer Class Documentation.
//     Microsoft Learn. [Online]. Available at:
//     https://learn.microsoft.com/en-us/dotnet/api/system.media.soundplayer
//     (Accessed: 12 May 2026).
// ====================================================================

using System;
using System.IO;
using System.Media;

namespace CyberGuardChatbot.Classes
{
    /// <summary>
    /// Manages audio playback for the chatbot's voice greeting feature.
    /// Uses System.Media.SoundPlayer to play WAV audio files.
    /// </summary>
    /// <remarks>
    /// This class handles file path resolution, error handling, and
    /// synchronous audio playback to ensure the greeting completes
    /// before the conversation begins (Microsoft, 2024).
    /// </remarks>
    public class AudioManager
    {
        // Path to the greeting audio file (Troelsen & Japikse, 2022)
        private string audioFilePath;

        /// <summary>
        /// Constructor - initializes the audio manager and resolves file path.
        /// </summary>
        /// <remarks>
        /// The constructor uses directory traversal to locate the Audio folder
        /// regardless of where the executable is running from.
        /// </remarks>
        public AudioManager()
        {
            // Get the current executable directory
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Navigate up to project root (bin/Debug/net8.0/ -> Project Root)
            // This accounts for the build output folder structure (Price, 2023)
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.Parent.FullName;

            // Construct the full path to the audio file
            audioFilePath = Path.Combine(projectDirectory, "Audio", "greeting.wav");
        }

        /// <summary>
        /// Plays the greeting audio file synchronously.
        /// </summary>
        /// <remarks>
        /// The method checks if the file exists before attempting playback.
        /// If the file is missing or corrupted, it gracefully continues
        /// without crashing the application (Sharp, 2023).
        /// </remarks>
        public void PlayGreeting()
        {
            // Verify audio file exists before attempting playback
            if (File.Exists(audioFilePath))
            {
                try
                {
                    // Create and configure sound player (Microsoft, 2024)
                    using (SoundPlayer greetingPlayer = new SoundPlayer(audioFilePath))
                    {
                        // PlaySync ensures audio completes before code continues
                        greetingPlayer.PlaySync();
                    }
                }
                catch (FileNotFoundException fileEx)
                {
                    ConsoleHelper.WriteWarning($"Audio file not found: {fileEx.Message}");
                    ConsoleHelper.WriteInfo("Continuing without voice greeting...");
                }
                catch (InvalidOperationException invalidEx)
                {
                    ConsoleHelper.WriteWarning($"Unable to play audio: {invalidEx.Message}");
                    ConsoleHelper.WriteInfo("Continuing with text-only mode...");
                }
                catch (Exception generalEx)
                {
                    ConsoleHelper.WriteError($"Unexpected audio error: {generalEx.Message}");
                    ConsoleHelper.WriteInfo("Continuing with text-only mode...");
                }
            }
            else
            {
                // Audio file missing - continue without sound (Skeet, 2019)
                ConsoleHelper.WriteWarning("Greeting audio file not found in Audio folder.");
                ConsoleHelper.WriteInfo("Continuing with text-only mode...");
            }
        }

        /// <summary>
        /// Checks whether the audio file exists in the expected location.
        /// </summary>
        /// <returns>True if audio file exists, false otherwise</returns>
        public bool DoesAudioFileExist()
        {
            return File.Exists(audioFilePath);
        }

        /// <summary>
        /// Gets the full path to the audio file.
        /// </summary>
        /// <returns>The complete file path as a string</returns>
        public string GetAudioFilePath()
        {
            return audioFilePath;
        }
    }
}