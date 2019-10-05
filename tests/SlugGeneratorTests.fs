namespace FSharp.Slugify.Tests

open NUnit.Framework
open FSharp.Slugify.SlugGenerator

type SlugGeneratorTests() =

    [<TestCase("test", "test")>]
    member this.``Test slugify method`` (input, expectedOutput) =
        let stringSlugified = slugify [||] input
        Assert.AreEqual(stringSlugified, expectedOutput)