namespace TarotShuffle;

public class Facilier(string MajorArcana, string MinorArcana, int Rounds = 3, int Select = 3)
{
    private const string SEPARATOR = "=========================";
    
    public void Begin() {
        var maJson = JsonSerializer.Deserialize<Tarot>(MajorArcana);
        var miJson = JsonSerializer.Deserialize<Tarot>(MinorArcana);

        var miJsonCards = miJson.Cards;

        var allCards = maJson.Cards.Concat(miJsonCards);
        var takeCards = ShuffleAndTake(allCards);

        Console.WriteLine($"\"The cards! The cards!\"{Environment.NewLine}{SEPARATOR}{Environment.NewLine}");
        
        foreach (var card in takeCards)
            Console.WriteLine(card);
    
        PlayAgain();
    }

    private IList<string> ShuffleAndTake(IEnumerable<string> cards)
    {
        var setRounds = Rounds;
        var rng = new Random();
        var hashedCards = new  HashSet<string>();
        
        // Limit rounds to a max of 10
        if (Rounds >= 10)
            setRounds = 10;
        
        // Convert to list
        var cardSet = cards.ToList();
        
        // Shuffle cards up to a specified rounds
        for (var round = 0; round < setRounds; round++)
            hashedCards = cardSet.OrderBy(x => rng.Next()).ToHashSet();
        
        return hashedCards.Take(Select).ToList();
    }

    /// <summary>
    /// Prompts the user to play again or exit
    /// </summary>
    private void PlayAgain()
    {
        Console.WriteLine($"{Environment.NewLine}{SEPARATOR}{Environment.NewLine}Try Again? Y/N");
        
        // Check if the user pressed 'Y' to continue
        if (Console.ReadKey().Key != ConsoleKey.Y) Environment.Exit(Environment.ExitCode);
        
        Console.Clear();
        Begin();
    }
}