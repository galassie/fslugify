namespace FSharp.Slugify

module SlugGenerator =
    
    type SlugGeneratorOptions = string array

    let slugify (options: string array) (toSlugify: string) =
        let mapChar char = 
            match char with
            | ' ' -> "-"
            | _ -> sprintf "%c" char

        toSlugify
        |> String.collect mapChar