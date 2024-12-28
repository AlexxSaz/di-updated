using FluentAssertions;
using TagCloud.Readers;
using TagCloud.WordHandlers;

namespace TagCloudTests;

public class WordHandlerShould
{
    private static readonly HashSet<string> TestWords =
    [
        "он", "ты", "вы", "а", "в", "привет", "мир", "контур", "компания", "лучшая"
    ];

    private static readonly HashSet<string> UpperCaseWords =
    [
        "ЯСНО", "ПОНЯТНО", "СЛОВО", "ДВА", "ДВАДЦАТЬДВА"
    ];

    private static readonly IFileReader Reader = new SingleWordInRowFileReader();

    [Test]
    public void Handle_ShouldReturnWordsInLowerCase_AfterExecutionWithUpperCaseWords()
    {
        var wordHandler = new StandardWordHandler(Reader);
        var expectedUpperCaseWords = new HashSet<string>
        {
            "ясно", "понятно", "слово", "два", "двадцатьдва"
        };

        var handledWords = wordHandler.Handle(UpperCaseWords).ToHashSet();

        handledWords.Should().BeEquivalentTo(expectedUpperCaseWords);
    }

    [Test]
    public void Handle_ShouldExcludeBoringWords_AfterExecution()
    {
        var wordHandler = new StandardWordHandler(Reader);
        var expectedGoodWords = new HashSet<string>
        {
            "привет", "мир", "контур", "компания", "лучшая"
        };

        var handledWords = wordHandler.Handle(TestWords).ToHashSet();

        handledWords.Should().BeEquivalentTo(expectedGoodWords);
    }
}