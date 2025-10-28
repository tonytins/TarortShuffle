namespace TarotShuffle;

public class Facilier(string MajorArcana, string MinorArcana, int Rounds = 3, int Select = 3)
{
    public void Begin() {
        var maJson = JsonSerializer.Deserialize<Tarot>(MajorArcana);
        var miJson = JsonSerializer.Deserialize<Tarot>(MinorArcana);

        var miJsonCards = miJson.Cards;

        var allCards = maJson.Cards.Concat(miJsonCards);
        var hashCards = Shuffler(allCards.ToList());
        var takeCards = hashCards.ToList().Take(Select);

        Console.WriteLine($"\"The cards! The cards!\"{Environment.NewLine}=========================");
        
        foreach (var card in takeCards)
            Console.WriteLine(card);
    
        PlayAgain();
    }

    private ISet<string> Shuffler(IList<string> cards)
    {
        var setRounds = Rounds;
        
        // Limit rounds to a max of 10
        if (Rounds >= 10)
            setRounds = 10;
        
        var rng = new Random();
        
        // Convert converts to List
        var cardSet = cards.ToList();
        var shuffledSet = new HashSet<string>();
        
        // Shuffle cards up to a specified rounds
        for (var round = 0; round < setRounds; round++)
            shuffledSet = cardSet.OrderBy(x => rng.Next()).ToHashSet();

        return shuffledSet;
    }

    /// <summary>
    /// Prompts the user to play again or exit
    /// </summary>
    private void PlayAgain()
    {
        Console.WriteLine($"{Environment.NewLine}Try Again? Y/N");
        
        // Check if the user pressed 'Y' to continue
        if (Console.ReadKey().Key != ConsoleKey.Y) Environment.Exit(Environment.ExitCode);
        
        Console.Clear();
        Begin();
    }
}