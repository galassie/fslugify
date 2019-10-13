namespace FSharp.Slugify.Tests

open NUnit.Framework
open FSharp.Slugify.SlugGenerator

type SlugGeneratorTests() =

    [<TestCase("test", "test")>]
    [<TestCase("url with spaces", "url_with_spaces")>]
    [<TestCase("       url to trim    ", "url_to_trim")>]
    [<TestCase("To Lower", "to_lower")>]
    [<TestCase("ToSeparate", "to_separate")>]
    [<TestCase("toSeparate", "to_separate")>]
    [<TestCase("EVERY CHAR CAPSLOCK", "every_char_capslock")>]
    [<TestCase("{with} [symbols)", "with_symbols")>]
    [<TestCase("{with!  #@? symbols)", "with_symbols")>]
    [<TestCase("!£$% symbols at start end !£$%  ", "symbols_at_start_end")>]
    [<TestCase("Test with numbers23", "test_with_numbers23")>]
    [<TestCase("Déjà Vu!", "deja_vu")>]
    member this.``Test slugify method with default options`` (input, expectedOutput) =
        let stringSlugified = slugify DefaultSlugGeneratorOptions input
        Assert.AreEqual(expectedOutput, stringSlugified)

    [<TestCase("test case", '@', "test@case")>]
    member this.``Test slugify method with custom separator`` (input, customSeparator, expectedOutput) =
        let stringSlugified = slugify { Separator = Some customSeparator } input
        Assert.AreEqual(expectedOutput, stringSlugified)