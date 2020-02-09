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
