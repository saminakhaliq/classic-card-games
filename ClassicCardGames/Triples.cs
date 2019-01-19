using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCardGames
{
    class Triples
    {

        Random random = new Random();
        public List<string> Suit = new List<string>();
        public List<GameCard> CardPile = new List<GameCard>();
        public GameCard upFacedCard;
        public List<string> Combination = new List<string>();
        private int _numberOfCards = 3;
        public List<GameCard> PlayerHand = new List<GameCard>();
        public List<GameCard> ComputerHand = new List<GameCard>();
        public string Moves { get; set; }


        public Triples()
        {

            Suit.Add("H");
            Suit.Add("C");
            Suit.Add("D");
            Suit.Add("S");
            PopulateCardList();
        }
        private void PopulateCardList()
        {


            for (int i = 1; i <= 13; i++)
            {
                string card = i.ToString();


                CardPile.Add(new GameCard($"{i}", "H"));
                CardPile.Add(new GameCard($"{i}", "D"));
                CardPile.Add(new GameCard($"{i}", "C"));
                CardPile.Add(new GameCard($"{i}", "S"));

            }

        }


        public void SetUpfaceCard()
        {

            //Set the upfacing card and remove it from the deck (Card Pile) 

            do
            {
                string cardNumber = random.Next(1, 14).ToString();
                string cardSuit = Suit[random.Next(0, 4)];

                upFacedCard = new GameCard(cardNumber, cardSuit);

            }
            while (!CardPile.Any(card => card.CardName == upFacedCard.CardName));

            CardPile.RemoveAll(card => card.CardName == upFacedCard.CardName);




        }

        // Player gets 3 cards, computer gets 3 cards 
        public void ShufflePlayerCards()
        {

            for (int i = 0; i < _numberOfCards; i++)
            {
                do
                {
                    GameCard card = CardPile[random.Next(CardPile.Count)];

                    PlayerHand.Add(card);


                }
                while (!CardPile.Contains(PlayerHand[i]) && PlayerHand.Contains(PlayerHand[i]));

                CardPile.Remove(PlayerHand[i]);

                do
                {
                    GameCard card = CardPile[random.Next(CardPile.Count)];
                    ComputerHand.Add(card);
                }
                while (!CardPile.Contains(ComputerHand[i]) && ComputerHand.Contains(ComputerHand[i]));


                CardPile.Remove(ComputerHand[i]);

            }

        }

        public string GameOver(bool player)
        {
            string message;

            if (player == true)
            {
                message = "YOU ARE THE  WINNER!";
                return message;
            }
            else
            {
                message = "THE COMPUTER WINS!";
                return message;
            }
        }

        //Checks player cards are all the same 
        public bool MatchCombination(List<GameCard> PlayerCards)
        {
            bool match = false;

            if (PlayerHand[0].CardNumber == PlayerHand[1].CardNumber && PlayerHand[1].CardNumber == PlayerHand[2].CardNumber)
            {
                match = true;
            }

            return match;

        }

        //Switches the upfaced card with the discarded player card 
        public void ReplaceCards(int index, GameCard card)
        {


            PlayerHand[index] = upFacedCard;

            SetUpfaceCard();


        }

        //Checks the Computer card and switches the index
        public bool SetComputerCard()
        {
            int indexRemove;


            if (ComputerHand[0].CardNumber == ComputerHand[1].CardNumber)
            {
                indexRemove = 2;

            }
            else if (ComputerHand[0].CardNumber == ComputerHand[2].CardNumber)
                indexRemove = 1;

            else
                indexRemove = 0;



            if (ComputerHand[0].CardNumber == ComputerHand[1].CardNumber && ComputerHand[0].CardNumber == ComputerHand[2].CardNumber)
            {
                ComputerHand[indexRemove] = upFacedCard;
                return true;
            }
            else
            {
                ComputerHand[indexRemove] = upFacedCard;
                return false;
            }
        }
    }
}
