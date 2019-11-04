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
        public void Slugify_WithDefaultOptions(string input, string expectedOutput)
        {
            var option = DefaultSlugGeneratorOptions;
            var sut = new SlugGeneratorObj(option);

            var stringSlugified = sut.Slugify(input); 

            Assert.AreEqual(expectedOutput, stringSlugified);
        }
    }
}