using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCardGames
{
   
        public class GameCard
        {
            public string CardSuit { get; set; }
            public string CardNumber { get; set; }

            public string CardName { get; set; }

            public GameCard(string number, string suit)
            {
                CardSuit = suit;
                CardNumber = number;
                CardName = number + suit;
            }
        }
    
}
