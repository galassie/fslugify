namespace FSharp.Slugify

[<RequireQualifiedAccess>]
module StringUtils =
    
    let trim (input: string) =
        input.Trim() 

    let collect (mapChar: char -> string) (input: string) =
        input |> String.collect mapChar

module SlugGenerator =
    
    type SlugGeneratorOptions = string array

    let slugify (options: string array) (toSlugify: string) =
        let mapChar char = 
            match char with
            | ' ' -> "-"
            | _ -> sprintf "%c" char

        toSlugify.Trim()
        |> StringUtils.trim
        |> StringUtils.collect mapChar