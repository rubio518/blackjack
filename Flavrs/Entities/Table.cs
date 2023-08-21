using System;

namespace Flavrs.Entities
{
    public class Table
    {
        private static Random rng = new Random();
        private int _numberOfPlayers;
        private List<Card> _cards = new List<Card>();
        public List<Player> players { get; set; } = new List<Player>();

        public Table(int numOfPlayers)
        {
            _numberOfPlayers = numOfPlayers;
            fillCards();
            shuffleDeck();
            for (int i = 0; i < numOfPlayers; i++)
            {
                var player = new Player("player" + i);
                players.Add(player);
            }
        }

        private void fillCards()
        {
            string[] suits = { "spades", "hearts", "diamonds", "clubs" };
            int cardsPerSuit = 13;
            foreach (var suit in suits)
            {
                for (int i = 1; i <= cardsPerSuit; i++)
                {
                    _cards.Add(new Card { number = i, suit = suit });
                }
            }
        }

        public Card getNextCard()
        {
            var card = _cards[0];
            _cards.Remove(card);
            return card;
        }

        public int getNumberOfPlayers()
        {
            return _numberOfPlayers;
        }

        public List<Card> getDeck()
        {
            return _cards;
        }

        public void shuffleDeck()
        {
            _cards = _cards.OrderBy(a => rng.Next()).ToList<Card>();
        }

        public void serveCards()
        {

        }
    }
}

