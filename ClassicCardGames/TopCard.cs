using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCardGames
{
    class TopCard
    {
        public int[] PlayerCards { get; set; }

        public int PlayerScore { get; set; }

        public int PlayerTurnScore { get; set; }

        public int ComputerTurnScore { get; set; }

        private int[] ComputerCards { get; set; }

        public int ComputerSelection { get; private set; }

        public int ComputerScore { get; set; }

        private int _numberOfCards = 3;


        public List<int> InPlayCards = new List<int>();


        public TopCard()
        {
            PlayerCards = new int[_numberOfCards];
            ComputerCards = new int[_numberOfCards]; 
            PopulateCardList();
            Shuffle();
        }

        private void PopulateCardList()
        {

            InPlayCards.Clear();
            for(int i=1;i<=13;i++)
            InPlayCards.Add(i);
           


        }
        public void Shuffle()
        {

            PopulateCardList();


            ComputerCards = new int[_numberOfCards];
            Random random = new Random();





            for (int i = 0; i < _numberOfCards; i++)
            {
                do
                {
                    PlayerCards[i] = random.Next(1, 14);
                }
                while (!InPlayCards.Contains(PlayerCards[i]));

                InPlayCards.Remove(PlayerCards[i]);

                do
                {
                    ComputerCards[i] = random.Next(1, 14);
                }
                while (!InPlayCards.Contains(ComputerCards[i]));

                InPlayCards.Remove(ComputerCards[i]);

            }


        }


        private void SelectComputerCard(int playerCard)
        {

            foreach (int i in ComputerCards)
            {

                if (i == ComputerCards.Min() && i > playerCard)
                {
                    ComputerSelection = i;
                }
                else if (i > playerCard && i < ComputerCards.Max())
                {
                    ComputerSelection = i;
                }
                else if (i == ComputerCards.Max() && i > playerCard)
                {
                    ComputerSelection = i;
                }
                else if (ComputerCards.Max() < playerCard)
                {
                    ComputerSelection = ComputerCards.Min();
                }
            }

        }

        private void RemoveComputerCard()
        {
            List<int> compCardList = ComputerCards.ToList();
            compCardList.Remove(ComputerSelection);
            ComputerCards = compCardList.ToArray();
        }
        public void SetPlayerCard(int playerCard)
        {
            SelectComputerCard(playerCard);
            UpdateScores(playerCard);
            RemoveComputerCard();
        }

        private void UpdateScores(int playerCard)
        {
            int score = (playerCard + ComputerSelection) * 10;

            if (ComputerSelection > playerCard)
            {
                ComputerScore += score;
                ComputerTurnScore = score;
                PlayerTurnScore = 0;

            }
            else if (playerCard > ComputerSelection)
            {
                PlayerScore += score;
                PlayerTurnScore = score;
                ComputerTurnScore = 0;
            }


        }

    }
}
