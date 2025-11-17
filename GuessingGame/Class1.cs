using System;

namespace GuessingGame
{
    //Abstract Game Class
    public abstract class Game
    {
        //Min and Max values for number range 
        public int Min { get; set; }
        public int Max { get; set; }

        private Random random;

        //Constructor 
        public Game()
        {
            Min = 1;
            Max = 100;
            random = new Random();
        }
        //Method to generate a random number in range 
        public int GenerateRandomNumber()
        {
            int num = random.Next(Min, Max + 1);
            return num;
        }
        
        //Abstract method to reset the game
        public abstract void ResetGame();
    }

    //GuessingGame class that inherits Game class
    public class GuessingGame : Game
    {
        public int SecretNumber { get; set; }
        public int AttemptCount { get; set; }
        //Constructor generates number, and sets count to 0
        public GuessingGame()
        {
            ResetGame();
        }
        //Method to check if guess is correct, too high, or too low 
        public string CheckGuess(int guess)
        {
            string hint;
            AttemptCount++;
            if (guess > SecretNumber)
            {
                hint = "Guess is too high!";
            }
            else if (guess < SecretNumber)
            {
                hint = "Guess is too low!";
            }
            else
            {
                hint = "Correct!";
            }
            return hint;
        }
        
        //Method to reset game
        public override void ResetGame()
        {
            SecretNumber = GenerateRandomNumber();
            AttemptCount = 0;
        }
    }
}
