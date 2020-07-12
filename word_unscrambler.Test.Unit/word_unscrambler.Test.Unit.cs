using Xunit;

namespace word_unscrambler.Test.Unit
{
    public class WordMatcherTest
    {
        private readonly WordMatcher wordMatcher = new WordMatcher();

        [Fact]
        public void testWordMatcher()
        {
            string[] words = {"cat", "chair", "more"};
            string[] scrambledWords = {"omre"};
            var matchedWords = wordMatcher.Match(scrambledWords, words);

            Assert.True(matchedWords.Count == 1);
            Assert.True(matchedWords[0].ScrambledWord.Equals("omre"));
            Assert.True(matchedWords[0].Word.Equals("more"));
        }
    }
}