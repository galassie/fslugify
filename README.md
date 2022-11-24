# FSlugify

[![Build status](https://ci.appveyor.com/api/projects/status/7xa66bc8a9ruw5wm?svg=true)](https://ci.appveyor.com/project/galassie/fslugify) [![NuGet](https://img.shields.io/nuget/v/FSlugify.svg)](https://nuget.org/packages/FSlugify)

Simple and minimalistic slug generator library written entirely in F#.

It's easy to use and has no extra dependencies.

## Add package

If you want to add this package to your project, execute the following command:

``` shell
dotnet add package FSlugify --version 1.2.0
```

## Build on your machine

If you want to build this library on your machine, execute the following commands:

``` shell
git clone https://github.com/galassie/fslugify.git
cd fslugify
dotnet build
```

If you want to run the tests, execute the following command:

``` shell
dotnet test
```

## Build in Docker

Required:
- Install [Docker](https://hub.docker.com/search/?type=edition&offering=community) for your system

Build a Docker image called `fslugify`. This will work without any local .NET Core installation.

```shell
docker build -t fslugify .
```

Use the following to instantiate a Docker container from the `fslugify` image and run the tests inside:

```shell
docker run --rm fslugify dotnet test
```

## Usage

You can see the some examples in the folder "samples" (both in C# and F#).

Here how it looks a simple F# program that uses this library:

``` fsharp
open FSlugify.SlugGenerator

[<EntryPoint>]
let main argv =
    printfn "This is a series of examples on how to use the SlugGenerator!\n"

    slugify DefaultSlugGeneratorOptions "Déjà Vu!"
    |> printfn "Slug generated from \"Déjà Vu!\" with default options: \"%s\"\n"

    slugify { DefaultSlugGeneratorOptions with Separator = '#' } "Déjà Vu!"
    |> printfn "Slug generated from \"Déjà Vu!\" with custom separator: \"%s\"\n"
    
    slugify { DefaultSlugGeneratorOptions with Lowercase = false } "Déjà Vu!"
    |> printfn "Slug generated from \"Déjà Vu!\" without lowercase: \"%s\"\n"
    
    let customMap = [("|", " or "); ("🤡", " clown ")]
    slugify { DefaultSlugGeneratorOptions with CustomMap = customMap } "Test | 🤡"
    |> printfn "Slug generated from \"Test | 🤡\" with custom map: \"%s\"\n"
    0

```
This program will output the following text:

``` shell
This is a series of examples on how to use the SlugGenerator!

Slug generated from "Déjà Vu!" with default options: "deja_vu"

Slug generated from "Déjà Vu!" with custom separator: "deja#vu"

Slug generated from "Déjà Vu!" without lowercase: "Deja_Vu"

Slug generated from "Test | 🤡" with custom map: "test_or_clown"

```

## Slug Custom Computation Expression

It is possible to use the custom Computation Expression in order to define your custom slugify function.

Here a simple example:

``` fsharp
open FSlugify.Builder

[<EntryPoint>]
let main argv =
    printfn "This example shows how to use the custom Slug Computation Expression!\n"

    let customSlugify = slug {
            separator '@'
            lowercase false
            custom_map ("|", " or ")
            custom_map ("&", " and ")
            custom_map ("⏳", " hourglass ")
            custom_map ("🤡", " clown")
        }

    customSlugify "Test | Case"
    |> printfn "Slug generated from \"Test | Case\": \"%s\"\n"

    customSlugify " Test  &  ⏳ "
    |> printfn "Slug generated from \"  Test  &  ⏳  \": \"%s\"\n"

    customSlugify "HI 🤡!!!"
    |> printfn "Slug generated from \"HI 🤡!!!\": \"%s\"\n"
    0

```
This program will output the following text:

``` shell
This example shows how to use the custom Slug Computation Expression!

Slug generated from "Test | Case": "Test@or@Case"

Slug generated from "  Test  &  ⏳  ": "Test@and@hourglass"

Slug generated from "HI 🤡!!!": "HI@clown"

```

## FSlugify.Adapter

Although the library is usable as it is in a C# project (as it shown in the C# sample), for a better usability (both in syntax and usability) it's preferred to use the library [FSlugify.Adapter](https://github.com/galassie/fslugify-adapter). 

## Contributing

Code contributions are more than welcome! 😻

Please commit any pull requests against the `master` branch.  
If you find any issue, please [report it](https://github.com/galassie/fslugify/issues)!

## License

This project is licensed under [The MIT License (MIT)](https://raw.githubusercontent.com/galassie/fslugify/master/LICENSE.md).

Author: [Enrico Galassi](https://twitter.com/enricogalassi88)
