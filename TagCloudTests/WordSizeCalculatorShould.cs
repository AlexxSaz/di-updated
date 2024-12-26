using FluentAssertions;
using FluentAssertions.Execution;
using TagCloud.Calculators;
using TagCloud.Infrastructure;

namespace TagCloudTests;

public class WordSizeCalculatorShould
{
    [Test]
    public void Calculate_ShouldReturnTagsWithSize_AfterExecutionWithOneWordCollection()
    {
        var imageSettings = new ImageSettings();
        var wordSizeCalculator = new WordSizeCalculator(imageSettings);
        var oneWordCollection = new List<string>
        {
            "ясно", "ясно", "ясно", "ясно", "ясно", "ясно"
        };
        var expectedNumberOfWords = oneWordCollection.GroupBy(x => x).Count();

        var wordFrequencyDictionary = wordSizeCalculator.Calculate(oneWordCollection);

        using var _ = new AssertionScope();
        wordFrequencyDictionary.Count.Should().Be(expectedNumberOfWords);
        wordFrequencyDictionary.First().Value.Should().Be(oneWordCollection.First());
        wordFrequencyDictionary.First().Font.Size.Should()
            .BeInRange(imageSettings.MinFontSize, imageSettings.MaxFontSize);
    }
}