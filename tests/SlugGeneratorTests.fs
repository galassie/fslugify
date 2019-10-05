module FSharp.Slugify.Tests

open NUnit.Framework
open FSharp.Slugify.SlugGenerator

[<SetUp>]
let Setup () =
    ()

[<TestCase("test", "test")>]
let ``Test slugify method`` (input, expectedOutput) =
    let stringSlugified = slugify [||] input
    Assert.Equals(stringSlugified, expectedOutput)
