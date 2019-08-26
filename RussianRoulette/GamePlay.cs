using System;
using System.Media;
using System.Windows;

namespace RussianRoulette
{
    public class GamePlay
    {
        public static int TotalWins = 0;
        public static int TotalLosses = 0;

        public int TotalShotsInGame = 6;
        public int FireInAirChoices = 2;

        public bool IsAway = true;

        private int bulletePosition;
        private int currentStrikerPosition;

        private int GenerateRandomNumber()
        {
            Random random = new Random();
            return random.Next(1, 7);
        }

        /// <summary>
        /// Plays Fire Gun sound
        /// </summary>
        private void FireGunSound()
        {
            SoundPlayer player = new SoundPlayer("Resources\\sound\\gun_shots.wav");
            player.Load();
            player.Play();
        }

        /// <summary>
        /// Plays Empty Gun shot sound
        /// </summary>
        private void EmptyShotSound()
        {
            SoundPlayer player = new SoundPlayer("Resources\\sound\\empty_shot.wav");
            player.Load();
            player.Play();
        }

        /// <summary>
        /// Check if Gun is Spun and Loaded
        /// </summary>
        /// <returns></returns>
        public bool IsGunReady()
        {
            if (bulletePosition == 0)
            {
                _ = MessageBox.Show("Load bullet in the gun.");
                return false;
            }
            else if (currentStrikerPosition == 0)
            {
                _ = MessageBox.Show("Please spin the chamber.");
                return false;
            }
            else
            {
                return true;
            }
        }

        public void LoadGun()
        {
            bulletePosition = GenerateRandomNumber();
        }

        public void SpinGun()
        {
            currentStrikerPosition = GenerateRandomNumber();
        }

        public static void Win()
        {
            TotalWins++;
            _ = MessageBox.Show("You Won the Game! \n Total Wins: " + TotalWins);
        }

        public static void Loss()
        {
            TotalLosses++;
            _ = MessageBox.Show("You Lost the Game! \n Total Losses: " + TotalLosses);
        }

        /// <summary>
        /// Returns true if the shot is fired. 
        /// Decreses the total number of shots by one and away choices by one if selected 
        /// </summary>
        /// <returns>true if shot is fired</returns>
        public bool IsShotFired()
        {
            TotalShotsInGame--;
            if (IsAway)
            {
                FireInAirChoices--;
            }
            if (bulletePosition == currentStrikerPosition)
            {
                FireGunSound();
                return true;
            }
            else
            {
                currentStrikerPosition = currentStrikerPosition == 6 ? 1 : ++currentStrikerPosition;
                EmptyShotSound();
                return false;
            }
        }
    }
}
