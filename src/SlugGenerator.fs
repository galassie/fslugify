namespace FSharp.Slugify

[<RequireQualifiedAccess>]
module StringUtils =
    
    let trim (input: string) =
        input.Trim() 

    let toLowerCase (input: string) =
        input.ToLower()

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
        |> StringUtils.toLowerCase
        |> StringUtils.collect mapChar