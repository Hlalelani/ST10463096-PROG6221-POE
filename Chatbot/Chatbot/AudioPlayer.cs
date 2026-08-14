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
            string[] possiblePaths =
            {
                "greeting.wav",

                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greeting.wav"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "greeting.wav"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "greeting.wav")
            };
            audioFilePath = "greeting.wav";

            foreach(string path in possiblePaths)
            {

            
                if (File.Exists(path))
            {

            
                audioFilePath = path;
                break;
        }
    }
}
        public void PlayGreeting()
        {
         try
            {
                if (!File.Exists(audioFilePath))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Voice greeting file not found. Continuing with text only...");

                    Console.ResetColor();

                    return;
                }
#pragma warning disable CA1416

                using (SoundPlayer player = new SoundPlayer(audioFilePath))
                {
                    player.Play();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Playing voice greeting...");
                    Console.ResetColor();
                }
#pragma warning restore CA1416
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

        

    

