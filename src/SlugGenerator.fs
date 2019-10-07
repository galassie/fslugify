namespace FSharp.Slugify

open FSharp.Slugify.Charsets

module SlugGenerator =
    
    type SlugGeneratorOptions = string array

    let slugify (options: string array) (toSlugify: string) =
        let map (replacer: char) (charSeq: char * char option) = 
            match charSeq with
            | (x, Some y) ->
                match x, y with
                | (rep1, rep2) when rep1 = replacer && rep1 = rep2
                    -> StringUtils.empty
                | (l, u) when LowercaseCharset.Contains l && UppercaseCharset.Contains u
                    -> sprintf "%c%c" l replacer
                | (_,_)
                    -> sprintf "%c" x
            | (x, None)
                -> sprintf "%c" x

        let replaceChars (replacer: char) (input: char) =
            match input with
            | s when not (AnycaseCharset.Contains s) -> replacer
            | _ -> input 

        toSlugify
        |> StringUtils.toCharArray
        |> Array.map (replaceChars '-')
        |> StringUtils.toCharSequence
        |> StringUtils.mapCharSequence (map '-')
        |> StringUtils.trim '-'
        |> StringUtils.toLower