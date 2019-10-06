namespace FSharp.Slugify

open FSharp.Slugify.Charsets

[<RequireQualifiedAccess>]
module StringUtils =
    
    let empty = ""

    let trim (input: string) =
        input.Trim() 

    let toLower (input: string) =
        input.ToLowerInvariant()
    
    let toCharSequence (input: string) = 
        let maxIndex = input.Length - 1
        let charArray = input.ToCharArray()
        [|
            for i in 0..maxIndex do 
                if i <> maxIndex then
                    yield (charArray.[i], Some charArray.[i+1])
                else
                    yield (charArray.[i], None)
        |]

    let mapCharSequence (map: char * char option -> string) (input: (char * char option) array) =
        [| for el in input do yield map el |]
        |> String.concat empty

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