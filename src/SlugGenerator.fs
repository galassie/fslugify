namespace FSharp.Slugify

open FSharp.Slugify.Charsets

module SlugGenerator =
    
    type SlugGeneratorOptions = string array

    let slugify (options: string array) (toSlugify: string) =
        let map (charSeq: char * char option) = 
            match charSeq with
            | (x, Some y) ->
                match x, y with
                | (' ', _) -> "-"
                | (l, u) when LowercaseCharset.Contains l && UppercaseCharset.Contains u -> sprintf "%c-" l
                | (_,_) -> sprintf "%c" x
            | (x, None) ->
                match x with
                | ' ' -> StringUtils.empty
                | _ -> sprintf "%c" x

        toSlugify.Trim()
        |> StringUtils.trim
        |> StringUtils.toCharSequence
        |> StringUtils.mapCharSequence map
        |> StringUtils.toLower