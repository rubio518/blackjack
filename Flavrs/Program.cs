using Flavrs.Engine;
using Flavrs.Entities;

internal class Program
{
    static int turn = 0;
    static int numOfPlayers = 0;
    static Dealer? dealer;
    static string mainLoop()
    {
        if (numOfPlayers == 0)
        {
            Console.WriteLine("Starting the game...");
            setNumOfPlayers();
        }
        if (turn == 0)
        {
            setBets();
        }
        if (dealer != null)
        {
            DisplayEngine.displayFrame(dealer);
        }
        turn++;
        foreach (var player in dealer.table?.players)
        {
            if (player.status == "blackjack" && dealer.status != "blackjack")
            {
                player.balance += player.bet * (decimal)2.5;
                continue;
            }
            if ((player.lastAction == "s" || player.status != "active") && dealer.status == "start")
            {
                continue;
            }
            if (dealer.status == "bust")
            {
                if (player.status != "bust")
                {
                    player.balance += player.bet * (decimal)1.5;
                }
                player.status = "end";
                continue;
            }
            if (player.status == "blackjack" && dealer.status == "blackjack")
            {
                player.balance += player.bet;
            }
            if (dealer.status == "active")
            {
                continue;
            }
            if (player.status == "active")
            {
                if (dealer.status == "completed")
                {
                    if (player.getBestScore() > dealer.getBestScore())
                    {
                        player.balance += player.bet * (decimal)2;
                    }
                    player.status = "end";
                    continue;
                }
                if (dealer.status == "blackjack")
                {
                    player.status = "end";
                    continue;
                }

            }
            Console.WriteLine(player.name + " actions h=hit s=stand");
            var currentAction = Console.ReadLine() ?? "";
            if (currentAction == "h")
            {
                var card = dealer.table.getNextCard();
                player.addCardToHand(card);
            }
            player.lastAction = currentAction;
        }

        if (dealer.table.players.Exists((p) => (p.lastAction != "s" && p.status == "active")))
        {
            Console.WriteLine("players turn");
            return "continue";
        }
        if (dealer.table.players.All((p) => (p.status == "end" || p.status == "bust" || p.status == "blackjack")))
        {
            DisplayEngine.displayFrame(dealer);
            Console.WriteLine("All bets were paid");
            Console.WriteLine("ending game...");
            Console.ReadLine();
            return "end";
        }
        Console.WriteLine("dealer's turn");
        dealer.hideFirst = false;
        if (dealer.status == "start")
        {
            dealer.status = "active";
        }

        var dealerScore = dealer.getBestScore();
        if (dealerScore > 16 && dealerScore < 21)
        {
            dealer.status = "completed";
        }
        if (dealer.status == "active")
        {
            var c = dealer.table.getNextCard();
            dealer.addCardToHand(c);
        }
        Console.ReadLine();
        return "continue";
    }

    private static void setBets()
    {
        foreach (var player in dealer.table?.players)
        {
            Console.WriteLine($"type bet for: {player.name}");
            var betInput = Console.ReadLine();
            player.status = "active";
            player.bet = int.Parse(betInput ?? "0");
            player.balance -= player.bet;
            player.setHand(dealer.table.getNextCard(), dealer.table.getNextCard());
        }
    }
    private static void setNumOfPlayers()
    {
        while (true)
        {
            Console.WriteLine("Enter the number of players");
            var playersRead = int.TryParse(Console.ReadLine() ?? "0", out numOfPlayers);

            if (!playersRead && numOfPlayers < 1)
            {
                Console.WriteLine("Please enter a valid # of players");
                continue;
            }
            else
            {
                Initialize(numOfPlayers);
                break;
            }
        }

    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to blackjack by RM!");

        while (true)
        {
            if (mainLoop() == "end")
            {
                Console.WriteLine("the end");
                Console.ReadKey();
                break;
            };
        }

    }

    private static void Initialize(int numOfPlayers)
    {
        var table = new Table(numOfPlayers);
        var d = new Dealer("Dealer");
        dealer = d;
        dealer.assignTable(table);
    }
}