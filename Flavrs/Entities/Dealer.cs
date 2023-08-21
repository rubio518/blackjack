using System;
namespace Flavrs.Entities
{
    public class Dealer : Player
    {
        public Dealer(string nameInput) : base(nameInput)
        {
            status = "start";
        }

        public Table? table { get; set; }
        public bool hideFirst { get; set; } = true;
        public new decimal balance { get; set; } = 10000;

        public void assignTable(Table t)
        {
            table = t;
            var c1 = t.getNextCard();
            var c2 = t.getNextCard();
            setHand(c1, c2);
        }


        public override string getHand()
        {
            var handString = "";
            var count = 0;
            foreach (var card in hand)
            {
                if (count == 0 && hideFirst)
                {
                    handString = "hidden";
                }
                else
                {
                    handString += " " + card.toString();
                }
                count++;
            }
            return handString;
        }

        public override Tuple<int, int> getScore()
        {
            if (hideFirst)
            {
                return new Tuple<int, int>(0, 0);
            }
            return base.getScore();
        }
    }
}

