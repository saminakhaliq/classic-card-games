using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ClassicCardGames
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TopCardPage : Page
    {

            TopCard game = new TopCard();
            public int _countShuffleClicks = 1; //keeps track of times shuffle is clicked
            public int _cardTapCounter = 0; //keep track of times cards are tapped
            string winner;

            public TopCardPage()
            {
                this.InitializeComponent();
                DisplayCards();

            }

            private void DisplayCards()
            {
                Card1.DisplayCard($"{game.PlayerCards[0]}C");
                Card2.DisplayCard($"{game.PlayerCards[1]}C");
                Card3.DisplayCard($"{game.PlayerCards[2]}C");
            }

            private void ShuffleButton_Click(object sender, RoutedEventArgs e)
            {
                 Winner.Text = "";
                Card1.IsEnabled = true;
                Card2.IsEnabled = true;
                Card3.IsEnabled = true;

                if (_countShuffleClicks >= 3)
                {
                    Shuffle_Button.IsEnabled = false;
                    Card1.IsEnabled = false;
                    Card2.IsEnabled = false;
                    Card3.IsEnabled = false;

                }
                else
                {
                    game.Shuffle();
                    DisplayCards();
                    _countShuffleClicks++;
                }
            }

            private void UpdateScores()
            {
                UIPlayerTurnScore.Text = $"Your Score is : {game.PlayerTurnScore}";
                PlayerScore.Text = $"Your Overall Score is: {game.PlayerScore}";
                UIComputerTurnScore.Text = $"Computer Score is: {game.ComputerTurnScore}";
                ComputerScore.Text = $"Computer Overall Score is  { game.ComputerScore}";

            }
            private async System.Threading.Tasks.Task AfterTapAsync(object sender, int index)
            {
                PlayingCards cardUsed = (PlayingCards)sender;

                //1. Display card on the table
                PlayerCard.DisplayCard($"{game.PlayerCards[index]}C");

                //2. hide selected card

                cardUsed.DisplayCard("BC");
                cardUsed.IsEnabled = false;
                Shuffle_Button.IsEnabled = false;

                //3. show the computer selection
                game.SetPlayerCard(game.PlayerCards[index]);
                CompCard.DisplayCard($"{game.ComputerSelection}C");

                UpdateScores();

                _cardTapCounter++;

                if (_cardTapCounter == 3)
                {

                    if (game.ComputerScore > game.PlayerScore)
                    {

                        
                        game.ComputerScore = 0;
                        game.PlayerScore = 0;
                        winner = "COMPUTER";
                    }
                    else if (game.ComputerScore < game.PlayerScore)
                    {
                        game.ComputerScore = 0;
                        game.PlayerScore = 0;
                        winner = "PLAYER";
                    }

                Winner.Text = $"{winner} IS THE WINNER";
                   


                    Shuffle_Button.IsEnabled = true;

                    _cardTapCounter = 0;
                }

            }



            private void Card1_Tapped(object sender, TappedRoutedEventArgs e)
            {
                AfterTapAsync(sender, 0);


            }
            private void Card2_Tapped(object sender, TappedRoutedEventArgs e)
            {
                AfterTapAsync(sender, 1);


            }
            private void Card3_Tapped(object sender, TappedRoutedEventArgs e)
            {
                AfterTapAsync(sender, 2);

            }

      

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), e);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
