using System;
namespace Flavrs.Entities
{
    public class Player
    {
        public string name { get; }
        public List<Card> hand { get; } = new List<Card>();
        public string lastAction { get; set; } = "";
        public string status { get; set; } = "active";
        public int bet { get; set; } = 0;
        public decimal balance { get; set; } = 1000;

        public Player(string nameInput)
        {
            name = nameInput;
        }

        public void setHand(Card card1, Card card2)
        {
            hand.Add(card1);
            hand.Add(card2);
            calculateStatus();


        }

        public int getBestScore()
        {
            var score = getScore();
            return score.Item2 > 21 ? score.Item1 : score.Item2;
        }

        public void addCardToHand(Card card)
        {
            hand.Add(card);
            calculateStatus();
        }

        public virtual Tuple<int, int> getScore()
        {
            var scoreLow = 0;
            var scoreHigh = 0;
            foreach (var card in hand)
            {
                var delta = card.number;
                if (card.number > 10)
                {
                    delta = 10;
                }
                scoreLow += delta;
                scoreHigh += delta;
                if (card.number == 1)
                {
                    scoreHigh += 10;
                }
            }
            return new Tuple<int, int>(scoreLow, scoreHigh);
        }


        public void calculateStatus()
        {
            var currentScore = getScore();
            if (currentScore.Item1 == 21 || currentScore.Item2 == 21)
            {
                status = "blackjack";
            }
            if (currentScore.Item1 > 21)
            {
                status = "bust";
            }
        }

        public virtual string getHand()
        {
            var handString = "";
            foreach (var card in hand)
            {
                handString += card.toString() + " ";
            }
            return handString;
        }
    }
}

