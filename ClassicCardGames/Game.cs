using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace ClassicCardGames
{
    public class Game
    {
        public string GameName { get; set; }
        public Image Image { get; set; }
        public string Description { get; set; }

        public string Instruction { get; set; }

        public List<int> InPlayCards = new List<int>();

        public int NumberOfCards { get; set; }

        public Game()
        {

        }
        public Game(string gameName, string imageFilename, string description, string instruction)
        {
            this.GameName = gameName;
            this.Description = description;
            this.Instruction = instruction;

            Image = new Image();
            Image.Source = new BitmapImage(new Uri($"ms-appx:///Assets/{imageFilename}", UriKind.RelativeOrAbsolute)); // ms-appx = loading a local file 



        }
        public static List<Game> AllGames()
            
        {
            return new List<Game>
            {
                 new Game
                (
                    gameName:"TOP CARD",
                    imageFilename:"topcard_icon.png",
                    description:"Top Card is a game where the highest card wins the round, collect the most points to beat your opponent",
                    instruction:"---INSTRUCTIONS---\n\nPlayer will be dealt three cards.\n\nSelect the highest card and the winner recieves the total of the two cards combined times 10.\n\nPlayer with the most points wins!\n\n\nGood Luck! "

                ),


                 new Game
                (
                    gameName:"CRAZY 8'S",
                    imageFilename:"crazy8s_icon.png",
                    description:"Crazy Eights is a game where the goal of the game is to be the first to get rid of all the player's cards to a discard pile.",
                    instruction:"---INSTRUCTIONS---\n\nPlayer will be dealt eight cards.\n\nCard played must match the suit or the number of the upfacing card ( Unless it is an eight )\n\nIf there are no matching cards in players hand select 'DRAW' to display one from the deck\n\nEights and Aces are special cards \n\n8 - Wild card can be placed on any suit or number and player selects a new card to play\n\nA - The other player's turn is skipped\n\nGood Luck! "

                ),


                  new Game
                (
                    gameName:"TRIPLES",
                    imageFilename:"jack_triples.png",
                    description:"Triples is a game where each player is dealt three cards and must get a set of three of the same cards.",
                    instruction:"---INSTRUCTIONS---\n\nPlayer will be dealt three cards.\nDraw a card and discard a card until all your cards are the same.\n\n Who ever matches first wins!\n\n If the draw pile finishes before the comination is achieved there is a tie."

                ),



            };
        }
       
        
    }

}
