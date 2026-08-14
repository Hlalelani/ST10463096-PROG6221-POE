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
            audioFilePath = "greeting.wav";
        }
        public void PlayGreeting()
        {
         try
            {
                if (!File.Exists(audioFilePath))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Audio file not found. Voice greeting skipped.");

                    Console.ResetColor();

                    return;
                }

                using (SoundPlayer player = new SoundPlayer(audioFilePath))
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

        

    

