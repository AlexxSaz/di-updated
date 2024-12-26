using FluentAssertions;
using FluentAssertions.Execution;
using TagCloud.Calculators;

namespace TagCloudTests;

public class WordSizeCalculatorShould
{
    [Test]
    public void Calculate_ShouldReturnTagsWithSize_AfterExecutionWithOneWordCollection()
    {
        var wordSizeCalculator = new WordSizeCalculator();
        var oneWordCollection = new List<string>
        {
            "ясно", "ясно", "ясно", "ясно", "ясно", "ясно"
        };
        var expectedNumberOfWords = oneWordCollection.GroupBy(x => x).Count();
        const int maxSize = 32;
        const int minSize = 12;

        var wordFrequencyDictionary = wordSizeCalculator.Calculate(oneWordCollection, maxSize, minSize);

        using var _ = new AssertionScope();
        wordFrequencyDictionary.Count.Should().Be(expectedNumberOfWords);
        wordFrequencyDictionary.First().Value.Should().Be(oneWordCollection.First());
        wordFrequencyDictionary.First().Font.Size.Should().BeInRange(minSize, maxSize);
    }
}