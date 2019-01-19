using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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

    public sealed partial class CrazyEightsPage : Page
    {
        private enum WhosTurn
        {
            Player,
            Computer
        }

        CrazyEights game = new CrazyEights();
        WhosTurn whosTurn = WhosTurn.Player;
        int userCardsChosen = 0;
        public CrazyEightsPage()
        {
            this.InitializeComponent();
            game.Shuffle();
            DisplayCards();



        }

        private void DisplayCards()
        {
            Card1.DisplayCard(game.PlayerHand[0].CardName);
            Card2.DisplayCard(game.PlayerHand[1].CardName);
            Card3.DisplayCard(game.PlayerHand[2].CardName);
            Card4.DisplayCard(game.PlayerHand[3].CardName);
            Card5.DisplayCard(game.PlayerHand[4].CardName);
            Card6.DisplayCard(game.PlayerHand[5].CardName);
            Card7.DisplayCard(game.PlayerHand[6].CardName);
            Card8.DisplayCard(game.PlayerHand[7].CardName);
            UpCard.DisplayCard(game.upFacedCard.CardName);
            BackCard.DisplayCard("DC");

        }
        private async System.Threading.Tasks.Task AfterTap(object sender, int index)
        {
            BackCard.IsEnabled = false;
            Moves.Text = "";
            Moves.Foreground = new SolidColorBrush(Colors.White);

            if (index == 9)//9 = Draw from Deck
            {
                game.Draw();
                UpCard.DisplayCard(game.upFacedCard.CardName);
                if (game.upFacedCard.CardNumber == "1")
                {

                    Moves.Text = "YOU DREW AN ACE! COMPUTER TURN SKIPPED, GO AGAIN.";
                    whosTurn = WhosTurn.Player;

                }
                else if (game.upFacedCard.CardNumber == "8")
                {
                    Moves.Text = "YOU DREW A WILDCARD! CHOOSE A NEW CARD WITH A DESIRED SUIT!";

                    whosTurn = WhosTurn.Player;
                }
                else
                    whosTurn = WhosTurn.Computer;
            }
            else
            {

                if (whosTurn == WhosTurn.Player)
                {
                    //Checks if players card is valid or not 

                    if (game.ValidatePlay(game.PlayerHand[index]) == 0)
                    {

                        Moves.Text = "YOU CANNOT CHOOSE THIS CARD";
                        Moves.Foreground = new SolidColorBrush(Colors.Maroon);


                        await Task.Delay(700);
                        Moves.Text = "";

                    }
                    else
                    {
                        //If valid checks for special cards 
                        if (game.ValidatePlay(game.PlayerHand[index]) == 8)//Card is eight
                        {

                            Moves.Text = "WILDCARD! CHOOSE A NEW CARD WITH A DESIRED SUIT!";

                            whosTurn = WhosTurn.Player;
                        }
                        else if (game.ValidatePlay(game.PlayerHand[index]) == 2)//Card is one
                        {

                            Moves.Text = "COMPUTER TURN SKIPPED, GO AGAIN.";

                            whosTurn = WhosTurn.Player;
                        }
                        else if (game.ValidatePlay(game.PlayerHand[index]) == 1)// Card is regular
                        {
                            whosTurn = WhosTurn.Computer;
                        }

                        userCardsChosen += 1;//Keep count of player cards chosen 
                        game.SetUserCard(game.PlayerHand[index]);// CHANGES THE UPFACED CARD TO USER CARD 
                        UpCard.DisplayCard(game.upFacedCard.CardName);

                        PlayingCards cardUsed = (PlayingCards)sender;

                        cardUsed.DisplayCard("BC");
                        cardUsed.IsEnabled = false;//Makes the chosen card unclickable 

                        if (userCardsChosen == 8)// if player plays all eight cards they win
                        {
                            game.GameOver("PLAYER");
                        }



                    }

                }

            }

            // Computer's turn
            if (whosTurn == WhosTurn.Computer && userCardsChosen != 8)
            {

                await ComputerTurnAsync();
                Moves.Text = game.ComputerMoves;

            }

            BackCard.IsEnabled = true;
            //Displays winner if there is one
            if (game.Winner != null)
            {

                DisableCards();
                Moves.Text = game.Winner;
                Moves.Foreground = new SolidColorBrush(Colors.Gold);

            }


        }

        //Sets Computer card 
        private async Task ComputerTurnAsync()
        {
            Moves.Text = "COMPUTER IS CHOOSING";

            await Task.Delay(1000);
            game.SetComputerCard();

            UpCard.DisplayCard(game.upFacedCard.CardName);
            whosTurn = WhosTurn.Player;
            if (game.ComputerSelection.CardNumber == "1" || game.ComputerSelection.CardNumber == "8")
            {
                whosTurn = WhosTurn.Computer;
                await ComputerTurnAsync();

            }
            else
                whosTurn = WhosTurn.Player;
        }

        //Disables cardds after winner is chosen 
        private void DisableCards()
        {
            Card1.IsEnabled = false;
            Card2.IsEnabled = false;
            Card3.IsEnabled = false;
            Card4.IsEnabled = false;
            Card5.IsEnabled = false;
            Card6.IsEnabled = false;
            Card7.IsEnabled = false;
            Card8.IsEnabled = false;
            BackCard.IsEnabled = false;

        }





        private void Card1_DoubleTapped(object sender, TappedRoutedEventArgs e)
        {
            AfterTap(sender, 0);



        }

        private void Card2_DoubleTapped(object sender, TappedRoutedEventArgs e)
        {
            AfterTap(sender, 1);

        }

        private void Card3_DoubleTapped(object sender, TappedRoutedEventArgs e)
        {
            AfterTap(sender, 2);
        }

        private void Card4_DoubleTapped(object sender, TappedRoutedEventArgs e)
        {
            AfterTap(sender, 3);
        }

        private void Card5_DoubleTapped(object sender, TappedRoutedEventArgs e)
        {
            AfterTap(sender, 4);

        }

        private void Card6_DoubleTapped(object sender, TappedRoutedEventArgs e)
        {
            AfterTap(sender, 5);

        }
        private void Card7_DoubleTapped(object sender, TappedRoutedEventArgs e)
        {
            AfterTap(sender, 6);
        }

        private void Card8_DoubleTapped(object sender, TappedRoutedEventArgs e)
        {
            AfterTap(sender, 7);
        }

        private void BackCard_DoubleTapped(object sender, TappedRoutedEventArgs e)
        {
            AfterTap(sender, 9);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), e);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
