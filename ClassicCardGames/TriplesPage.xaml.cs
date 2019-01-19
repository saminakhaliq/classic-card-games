using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class TriplesPage : Page
    {
        Triples game = new Triples();

        public TriplesPage()
        {
            this.InitializeComponent(); 
            game.ShufflePlayerCards();
            game.SetUpfaceCard();

            DisplayCards();
            GameMoves.Text = "DISCARD AN UNWANTED CARD ";
        }

        private void DisplayCards()
        {
            Card1.DisplayCard(game.PlayerHand[0].CardName);
            Card2.DisplayCard(game.PlayerHand[1].CardName);
            Card3.DisplayCard(game.PlayerHand[2].CardName);
            upFaced.DisplayCard(game.upFacedCard.CardName);


            Card4.DisplayCard(game.ComputerHand[0].CardName);
            Card5.DisplayCard(game.ComputerHand[1].CardName);
            Card6.DisplayCard(game.ComputerHand[2].CardName);


        }
        private void DisableCards()
        {
            Card1.IsEnabled = false;
            Card2.IsEnabled = false;
            Card3.IsEnabled = false;

        }


        private async void CardTapped(int index)
        {

            GameMoves.Text = "";

            game.ReplaceCards(index, game.PlayerHand[index]);
            upFaced.DisplayCard(game.upFacedCard.CardName);
            DisplayCards();

            if (game.MatchCombination(game.PlayerHand) == true)
            {
                GameOver(true);
                DisableCards();

            }
            else
            {
                await Task.Delay(1000);

                DisplayCards();
                if (game.SetComputerCard())
                {
                    GameOver(false);
                    DisableCards();
                }
                else
                {
                    if (game.CardPile.Count == 0)
                    {
                        GameMoves.Text = "THERE IS A TIE!";
                        GameMoves.Foreground = new SolidColorBrush(Colors.ForestGreen);
                        DisableCards();
                    }
                    else
                    {
                        game.SetUpfaceCard();
                        DisplayCards();
                        await Task.Delay(1000);

                        GameMoves.Text = "DISCARD AN UNWANTED CARD";

                    }
                }
            }

        }



        private void Card1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CardTapped(0);

        }

        private void Card2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CardTapped(1);

        }

        private void Card3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CardTapped(2);

        }


        //Sets the winner 
        public void GameOver(bool winner)
        {
            string message = game.GameOver(winner);
            GameMoves.Text = message;
            GameMoves.Foreground = new SolidColorBrush(Colors.Gold);

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
