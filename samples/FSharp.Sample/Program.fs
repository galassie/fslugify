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
    
    slugify { DefaultSlugGeneratorOptions with CustomMap = [("|", " or "); ("🤡", " clown ")] } "Test | 🤡"
    |> printfn "Slug generated from \"Test | 🤡\" with custom map: \"%s\"\n"
    0
