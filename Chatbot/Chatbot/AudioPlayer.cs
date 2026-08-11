using System;
using System.Media;
using System.IO;

namespace CybersecurityChatbot
{
    public class AudioPlayer
    {
        private string audioFilePath;

        public AudioPlayer()
        {
            audioFilePath = FindAudioFile();
        }
        private string FindAudioFile()
        {
         string[] possiblePaths =
                { Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greeting.wav"), 
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, " ..", "..", "..", "greeting.wav"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "greeting.wav"), "greeting.wav" };

            foreach (string Path in possiblePaths)
            {
                if (File.Exists(Path))
                {
                    return Path;
                }
            }
            return "greeting.wav ";
        }

        public void PlayGreeting()
        {
            try
            {
                if (!File.Exists(audioFilePath))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Audio file not found. voice greeting skipped.");

                    Console.ResetColor();

                    return;
                }

                using (SoundPlayer player =new SoundPlayer(audioFilePath))
                {
                    player.Play();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Playing voice greeting...");
                    Console.ResetColor();
                }
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Could not play audio : {ex.Message}");
                Console.ResetColor();
            }
        }

        

    }
}
