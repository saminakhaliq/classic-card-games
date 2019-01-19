using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace ClassicCardGames
{


    class CrazyEights
    {
        int _numberOfCards = 8;
        public List<GameCard> PlayerHand = new List<GameCard>();
        public List<GameCard> ComputerHand = new List<GameCard>();
        public GameCard ComputerSelection { get; set; }
        public List<GameCard> Deck = new List<GameCard>();
        public List<string> Suit = new List<string>();
        Random random = new Random();
        public string ComputerMoves { get; set; }
        public string Winner { get; set; }
        string chosenSuit;


        public GameCard upFacedCard;
        public bool playerTurn;
        int hearts;
        int diamonds;
        int spades;
        int clubs;
        int[] suits;


        public CrazyEights()
        {
            //Populate a list of suits 
            Suit.Add("H");
            Suit.Add("C");
            Suit.Add("D");
            Suit.Add("S");
            PopulateCardList();
        }
        private void PopulateCardList()
        {

            //Use a for loop to create 13 cards for each suit 
            for (int i = 1; i <= 13; i++)
            {
                string card = i.ToString();


                Deck.Add(new GameCard($"{i}", "H"));
                Deck.Add(new GameCard($"{i}", "D"));
                Deck.Add(new GameCard($"{i}", "C"));
                Deck.Add(new GameCard($"{i}", "S"));

            }
            

        }

        public void Draw()
        {

            //Set the upfacing card and remove it from the deck (Card Pile) 
            do
            {
                string cardNumber = random.Next(1, 14).ToString();
                string cardSuit = Suit[random.Next(0, 4)];

                upFacedCard = new GameCard(cardNumber, cardSuit);

            }
            while (!Deck.Any(card => card.CardName == upFacedCard.CardName));

            Deck.RemoveAll(card => card.CardName == upFacedCard.CardName);
            //If there are no more cards to draw there is a tie 
            if (Deck.Count == 0)
                GameOver("TIE");

        }



        public void Shuffle()
        {

            Draw();
            playerTurn = true;

            //add a set of unique cards to player and computer hands and remove from deck
            for (int i = 0; i < _numberOfCards; i++)
            {
                do
                {
                    GameCard card = Deck[random.Next(Deck.Count)];

                    PlayerHand.Add(card);


                }
                while (!Deck.Contains(PlayerHand[i]));



                Deck.Remove(PlayerHand[i]);


                do
                {
                    GameCard card = Deck[random.Next(Deck.Count)];
                    ComputerHand.Add(card);
                }
                while (!Deck.Contains(ComputerHand[i]));


                Deck.Remove(ComputerHand[i]);


            }

        }

        public int ValidatePlay(GameCard card)
        {


            // Different rules for each case if player chooses 8
            if (card.CardNumber == "8")
            {
                return 8;
            }
            // normal play if suit or number match card
            else if (card.CardSuit == upFacedCard.CardSuit || card.CardNumber == upFacedCard.CardNumber || upFacedCard.CardNumber == "8")
            {
                //if player chooses and ace
                if (card.CardNumber == "1")
                {
                    return 2;

                }

                return 1;
            }
            else
            {
                //if player makes an unvalid choice
                return 0;
            }
            
        }



        public void SetUserCard(GameCard card)
        {
            //Set user choice to upFacedCard
            upFacedCard = card;
        }

        public void SetComputerCard()
        {
            ComputerMoves = "";
            bool isMatch = true;


            for (int i = 0; i < ComputerHand.Count; i++)
            {
                //Checks for valid plays for the computer
                if (ComputerHand[i].CardNumber == "8")
                {
                    ComputerSelection = ComputerHand[i];
                    upFacedCard = ComputerSelection;
                    ComputerHand.Remove(ComputerHand[i]);


                    //if an 8 is chosen it chooses another card to put down
                    string chosenSuit = GreatestSuit();
                    foreach (GameCard card in ComputerHand)
                    {
                        if (card.CardSuit == chosenSuit)
                        {

                            ComputerSelection = card;
                            upFacedCard = ComputerSelection;
                            ComputerHand.Remove(ComputerSelection);
                            isMatch = true;
                            break;
                        }
                    }

                    ComputerMoves = "COMPUTER CHOSE A WILD CARD AND SET A NEW SUIT";

                    break;


                }
                else if (ComputerHand[i].CardSuit == upFacedCard.CardSuit)
                {


                    ComputerSelection = ComputerHand[i];
                    upFacedCard = ComputerSelection;
                    ComputerHand.Remove(ComputerSelection);
                    isMatch = true;
                    break;
                }
                else if (ComputerHand[i].CardNumber == upFacedCard.CardNumber)
                {


                    ComputerSelection = ComputerHand[i];
                    upFacedCard = ComputerSelection;
                    ComputerHand.Remove(ComputerSelection);
                    isMatch = true;

                    break;
                }

                else
                {

                    isMatch = false;

                }


            }
            //Checks if the computer has run out of cards and wins // else it draws a new card 
            if (ComputerHand.Count == 0)
            {
                GameOver("COMPUTER");

            }
            else if (isMatch == false)
            {
                ComputerMoves = "COMPUTER DREW A CARD";

                Draw();
                //if the card is an 8 computer goes again else if it is an ace it also goes again but suits must match
                if (upFacedCard.CardNumber == "8")
                {
                    chosenSuit = GreatestSuit();
                    foreach (GameCard card in ComputerHand)
                    {
                        if (card.CardSuit == chosenSuit)
                        {

                            ComputerSelection = card;
                            upFacedCard = ComputerSelection;
                            ComputerHand.Remove(ComputerSelection);
                            isMatch = true;
                            break;
                        }
                    }

                    ComputerMoves = "COMPUTER DREW A WILD CARD AND SET A NEW SUIT";

                }
                //If the drawn card id an ace the computer goes again but must match suits
                else if (upFacedCard.CardNumber == "1")
                {

                    SetComputerCard();
                    ComputerMoves = "COMPUTER DREW AN ACE AND WENT AGAIN!";

                }


            }




        }

        private string GreatestSuit()
        {
            //Counts the suits in the card hand
            foreach (GameCard card in ComputerHand)
            {
                if (card.CardSuit == "H")
                    hearts++;
                else if (card.CardSuit == "D")
                    diamonds++;
                else if (card.CardSuit == "S")
                    spades++;
                else if (card.CardSuit == "C")
                    clubs++;
            }
            //chooses the suit with the most cards
            suits = new int[] { hearts, diamonds, spades, clubs };
            if (hearts == suits.Max())
                return "H";
            else if (diamonds == suits.Max())
                return "D";

            else if (spades == suits.Max())
                return "S";

            else

                return "C";


        }
        public void GameOver(string decision)
        {
            if (decision == "TIE")
            {
                Winner = "THERE WAS A TIE!";

            }
            else
            {
                Winner = $"{decision} IS THE WINNER";

            }
        }


    }

}
