namespace FSharp.Slugify.Tests

open NUnit.Framework
open FSharp.Slugify.SlugGenerator

type SlugGeneratorTests() =

    [<TestCase("test", "test")>]
    [<TestCase("url with spaces", "url-with-spaces")>]
    [<TestCase("       url to trim    ", "url-to-trim")>]
    member this.``Test slugify method`` (input, expectedOutput) =
        let stringSlugified = slugify [||] input
        Assert.AreEqual(expectedOutput, stringSlugified)