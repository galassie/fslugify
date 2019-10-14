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

    [<TestCase("Test Case", '@', "test@case")>]
    [<TestCase("    MORE   TEST    CASE  ", '#', "more#test#case")>]
    [<TestCase("{With} [Symbols)", '.', "with.symbols")>]
    [<TestCase("Déjà Vu!!!", '§', "deja§vu")>]
    member this.``Test slugify method with custom separator`` (input, customSeparator, expectedOutput) =
        let stringSlugified = slugify { Separator = Some customSeparator; Lowercase = None } input
        Assert.AreEqual(expectedOutput, stringSlugified)

    [<TestCase("Test Case", "Test@Case")>]
    [<TestCase("    MORE   TEST    CASE  ", "MORE@TEST@CASE")>]
    [<TestCase("{With} [Symbols)", "With@Symbols")>]
    [<TestCase("DÉJÀ VU!!!", "DEJA@VU")>]
    member this.``Test slugify method with lowercase false`` (input, expectedOutput) =
        let stringSlugified = slugify { Separator = Some '@'; Lowercase = Some false } input
        Assert.AreEqual(expectedOutput, stringSlugified)