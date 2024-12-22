namespace TagCloud.Infrastructure.Tags;

public record SimpleWordTag(string Value, int FontSize) : IWordTag;