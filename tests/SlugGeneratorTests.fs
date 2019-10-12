namespace FSharp.Slugify.Tests

open NUnit.Framework
open FSharp.Slugify.SlugGenerator

type SlugGeneratorTests() =

    [<TestCase("test", "test")>]
    [<TestCase("url with spaces", "url-with-spaces")>]
    [<TestCase("       url to trim    ", "url-to-trim")>]
    [<TestCase("To Lower", "to-lower")>]
    [<TestCase("ToSeparate", "to-separate")>]
    [<TestCase("toSeparate", "to-separate")>]
    [<TestCase("EVERY CHAR CAPSLOCK", "every-char-capslock")>]
    [<TestCase("{with} [symbols)", "with-symbols")>]
    [<TestCase("{with!  #@? symbols)", "with-symbols")>]
    [<TestCase("!£$% symbols at start end !£$%  ", "symbols-at-start-end")>]
    [<TestCase("Test with numbers23", "test-with-numbers23")>]
    member this.``Test slugify method with default options`` (input, expectedOutput) =
        let stringSlugified = slugify [||] input
        Assert.AreEqual(expectedOutput, stringSlugified)