using DSD_01.view;
using System;
using System.Windows;

namespace DSD_01
{
    public class RussianRoulette
    {
        private int bulletePosition;
        private int chamberPosition;

        public int Chances;
        public int AwayChoices;

        public static int Wins = 0;
        public static int Losses = 0;

        public PlayArea PlayArea;

        public RussianRoulette()
        {
            AwayChoices = 2;
            Chances = 6;
        }

        /// <summary>
        /// Updates the away and total shots label after each gun click
        /// </summary>
        public void UpdateShotsLabel()
        {
            PlayArea.AwayShots.Content = "Away Shots Remaining: " + AwayChoices;
            PlayArea.TotalShots.Content = "Total Shots Remaining: " + Chances;
        }

        /// <summary>
        /// Checks if the gun is Spinned at least once and Loaded.
        /// i.e verifies if the bullet and chamber position not set to 0.
        /// </summary>
        public bool IsGunSpunAndLoaded()
        {
            if (bulletePosition == 0)
            {
                _ = MessageBox.Show("Gun is not loaded.");
                return false;
            }
            else if (chamberPosition == 0)
            {
                _ = MessageBox.Show("Please spin the chamber before starting the game.");
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// returns random integer between 1 to 6
        /// </summary>
        /// <returns></returns>
        private int GetRandomPosition()
        {
            Random random = new Random();
            return random.Next(1, 7);
        }

        /// <summary>
        /// Sets bullet postion to any random number between 1 to 6.
        /// Plays gun loading sound
        /// </summary>
        public void LoadGun()
        {
            bulletePosition = GetRandomPosition();
            Sound.PlayLoadGunSound();
        }

        /// <summary>
        /// Sets current chamber position to any random integer between 1 to 6.
        /// Plays chamber spinning sound.
        /// </summary>
        public void SpinChamber()
        {
            chamberPosition = GetRandomPosition();
            Sound.PlaySpinChamberSound();
        }

        /// <summary>
        /// Increse the win count by one and display win message
        /// </summary>
        private void Win()
        {
            Wins++;
            _ = MessageBox.Show("You Won the Game!");
        }

        /// <summary>
        /// Increse the loss count by one and display loss message
        /// </summary>
        private void Loss()
        {
            Losses++;
            _ = MessageBox.Show("You Lost the Game");
        }

        /// <summary>
        /// Fires the shot and checks if the user won or lost. Plays the gun fire and empty
        /// gun shot sounds on respective occurances.
        /// </summary>
        /// <param name="isAway">Gun postion: true if away else false</param>
        /// <returns>True if game is over. False if the game is not over</returns>
        public bool FireShot(bool isAway)
        {
            bool isShotFired;
            bool gameOver;

            //if the bullet postio and the chamber postion is same then the shot is fired.
            if (bulletePosition == chamberPosition)
            {
                Sound.PlayFireBulletSound();
                isShotFired = true;
            }
            else
            {
                //Set chamber postion to 1 if the current postion is 6 else 
                //Increse the gun chamber position by one.
                chamberPosition = chamberPosition == 6 ? 1 : ++chamberPosition;
                Sound.PlayEmptyGunShotSound();
                isShotFired = false;
            }
            gameOver = isShotFired;
            if (isAway)
            {
                //Decrese the away choices by one.
                AwayChoices--;
                if (isShotFired)
                {
                    //If gun is away and shot is fired then Player won.
                    Win();
                }
                else
                {
                    if (AwayChoices == 0)
                    {
                        //Shot not fired and no away choices are left so the Player lost and game is over 
                        Loss();
                        gameOver = true;
                    }

                }
            }
            else
            {
                if (isShotFired)
                {
                    //If the shot is fired at head then player lost
                    Loss();
                }
            }

            Chances--;
            UpdateShotsLabel();
            return gameOver;
        }
    }
}
