using NUnit.Framework;
using FSlugify.Adapter;
using static FSlugify.SlugGenerator;

namespace FSlugify.Adapter.Tests
{
    public class SlugGeneratorObjTests
    {
        [TestCase("test", "test")]
        [TestCase("url with spaces", "url_with_spaces")]
        [TestCase("       url to trim    ", "url_to_trim")]
        [TestCase("To Lower", "to_lower")]
        [TestCase("ToSeparate", "to_separate")]
        [TestCase("toSeparate", "to_separate")]
        [TestCase("EVERY CHAR CAPSLOCK", "every_char_capslock")]
        [TestCase("{with} [symbols)", "with_symbols")]
        [TestCase("{with!  #@? symbols)", "with_symbols")]
        [TestCase("!£$% symbols at start end !£$%  ", "symbols_at_start_end")]
        [TestCase("Test with numbers23", "test_with_numbers23")]
        [TestCase("Déjà Vu!", "deja_vu")]
        public void Slugify_WithDefaultOptions_ShouldReturnExpectedSlugifiedString(string input, string expectedOutput)
        {
            var option = DefaultSlugGeneratorOptions;
            var sut = new SlugGeneratorObj(option);

            var stringSlugified = sut.Slugify(input); 

            Assert.AreEqual(expectedOutput, stringSlugified);
        }

        [TestCase("Test Case", '@', "test@case")]
        [TestCase("    MORE   TEST    CASE  ", '#', "more#test#case")]
        [TestCase("{With} [Symbols)", '.', "with.symbols")]
        [TestCase("Déjà Vu!!!", '§', "deja§vu")]
        public void Slugify_WithCustomSeparator_ShouldReturnExpectedSlugifiedString(string input, char customSeparator, string expectedOutput)
        {
            var option = new SlugGeneratorOptionsBuilder()
                            .Init()
                            .WithCustomSeparator(customSeparator)
                            .Build();
            var sut = new SlugGeneratorObj(option);

            var stringSlugified = sut.Slugify(input); 

            Assert.AreEqual(expectedOutput, stringSlugified);
        }

        [TestCase("Test Case", "Test@Case")]
        [TestCase("    MORE   TEST    CASE  ", "MORE@TEST@CASE")]
        [TestCase("{With} [Symbols)", "With@Symbols")]
        [TestCase("DÉJÀ VU!!!", "DEJA@VU")]
        public void Slugify_WithCustomSeparator_ShouldReturnExpectedSlugifiedString(string input, string expectedOutput)
        {
            var option = new SlugGeneratorOptionsBuilder()
                            .Init()
                            .WithCustomSeparator('@')
                            .WithLowercaseOn(false)
                            .Build();
            var sut = new SlugGeneratorObj(option);

            var stringSlugified = sut.Slugify(input); 

            Assert.AreEqual(expectedOutput, stringSlugified);
        }

        [TestCase("Test | Case", "test_or_case")]
        [TestCase("  &  MORE   TEST  &  CASE  ", "and_more_test_and_case")]
        [TestCase("{With}⏳[Symbols)", "with_hourglass_symbols")]
        [TestCase("DÉJÀ 🤡!!!", "deja_clown")]
        public void Slugify_WithCustomMaps_ShouldReturnExpectedSlugifiedString(string input, string expectedOutput)
        {
            var option = new SlugGeneratorOptionsBuilder()
                            .Init()
                            .AddCustomMap("|", " or ")
                            .AddCustomMap("&", " and ")
                            .AddCustomMap("⏳", " hourglass ")
                            .AddCustomMap("🤡", " clown")
                            .Build();
            var sut = new SlugGeneratorObj(option);

            var stringSlugified = sut.Slugify(input); 

            Assert.AreEqual(expectedOutput, stringSlugified);
        }

        [TestCase("", "")]
        [TestCase("                    ", "")]
        [TestCase("B", "b")]
        [TestCase("a", "a")]
        [TestCase("Ç", "c")]
        [TestCase(null, "")]
        public void Slugify_WithEdgeCases_ShouldReturnExpectedSlugifiedString(string input, string expectedOutput)
        {
            var option = DefaultSlugGeneratorOptions;
            var sut = new SlugGeneratorObj(option);

            var stringSlugified = sut.Slugify(input); 

            Assert.AreEqual(expectedOutput, stringSlugified);
        }

        [TestCase("ښ ۍ", "x_ai")]
        [TestCase("Ф Щ ЮЯЁ", "f_shh_yu_ya_yo")]
        public void Slugify_WithSpecialCharsAlphabet_ShouldReturnExpectedSlugifiedString(string input, string expectedOutput)
        {
            var option = DefaultSlugGeneratorOptions;
            var sut = new SlugGeneratorObj(option);

            var stringSlugified = sut.Slugify(input); 

            Assert.AreEqual(expectedOutput, stringSlugified);
        }

        [TestCase("Test Case", '@', "test_case")]
        [TestCase("    MORE   TEST    CASE  ", '#', "more_test_case")]
        [TestCase("{With} [Symbols)", '.', "with_symbols")]
        [TestCase("Déjà Vu!!!", '§', "deja_vu")]
        public void Slugify_WhenPassingOptionAsArgument_ShouldUseArgumentsPassedAndReturnExpectedSlugifiedString(string input, char customSeparator, string expectedOutput)
        {
            var option = new SlugGeneratorOptionsBuilder()
                            .Init()
                            .WithCustomSeparator(customSeparator)
                            .WithLowercaseOn(false)
                            .AddCustomMap("!", " bang ")
                            .Build();
            var sut = new SlugGeneratorObj(option);

            var stringSlugified = sut.Slugify(input, DefaultSlugGeneratorOptions); 

            Assert.AreEqual(expectedOutput, stringSlugified);
        }
    }
}