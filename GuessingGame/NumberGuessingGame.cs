using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessingGame
{
    public partial class NumberGuessingGame : Form
    {
        GuessingGame game;
        public NumberGuessingGame()
        {
            InitializeComponent();
            game = new GuessingGame();
        }

        private void btnGuess_Click(object sender, EventArgs e)
        {
            int guess;

            //validate number input
            if (!int.TryParse(textGuess.Text, out guess))
            {
                lblFeedback.Text = "Please enter a valid number";
                return;
            }

            if (guess>100 || guess<1)
            {
                lblFeedback.Text = "Please enter a valid number";
                return;
            }
            //Check the guess
            string result = game.CheckGuess(guess);

            //Update UI
            lblFeedback.Text = result;
            lblAttempts.Text = $"Attempts: {game.AttemptCount}";
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            game.ResetGame();
            lblFeedback.Text = "";
            lblAttempts.Text = "Attempts: 0";
            textGuess.Clear();
        }
    }
}
