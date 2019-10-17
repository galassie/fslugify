namespace FSharp.Slugify

open FSharp.Slugify.Charsets
open FSharp.Slugify.Charmaps

module SlugGenerator =
    
    type SlugGeneratorOptions = {
        Separator: char
        Lowercase: bool
        CustomMap: (string * string) list
    }

    let DefaultSlugGeneratorOptions = {
        Separator = '_'
        Lowercase = true
        CustomMap = [ ]
    }

    let slugify (opts: SlugGeneratorOptions) (toSlugify: string) =

        let rec doCustoMap (customMap: (string * string) list) (input: string) =
            match customMap with
            | (replaceWhat, replaceWith)::tail -> doCustoMap tail (StringUtils.replace replaceWhat replaceWith input)
            | [] -> input

        let replaceChars (replacer: char) (input: char) =
            match input with
            | m when InternalCharmap.ContainsKey m -> InternalCharmap.Item m
            | s when not (AnycaseCharset.Contains s) -> replacer
            | _ -> input

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

        let optionalToLower = opts.Lowercase |> function | true -> StringUtils.toLower | false -> id

        toSlugify
        |> doCustoMap opts.CustomMap
        |> StringUtils.toCharArray
        |> Array.map (replaceChars opts.Separator)
        |> StringUtils.toCharSequence
        |> StringUtils.mapCharSequence (map opts.Separator)
        |> StringUtils.trim opts.Separator
        |> optionalToLower