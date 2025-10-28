namespace TarotShuffle;

public record Tarot(
    [property: JsonPropertyName("cards")] IEnumerable<string> Cards,
    [property: JsonPropertyName("name")] string Name
);