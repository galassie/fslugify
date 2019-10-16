namespace FSharp.Slugify

open FSharp.Slugify.Charsets
open FSharp.Slugify.Charmaps

module SlugGenerator =
    
    type SlugGeneratorOptions = {
        Separator: char option
        Lowercase: bool option
        CustomMap: Map<string, string> option
    }

    let DefaultSlugGeneratorOptions = {
        Separator = Some '_'
        Lowercase = Some true
        CustomMap = Some (Map.ofArray [| |])
    }

    let slugify (options: SlugGeneratorOptions) (toSlugify: string) =
        
        let opts = {|
            Separator = options.Separator |> function | Some x -> x | None -> '_'
            Lowercase = options.Lowercase |> function | Some x -> x | None -> true
            CustomMap = options.CustomMap |> function | Some x -> x | None -> Map.ofArray [| |]
        |}

        let rec doCustoMap (customMap: List<(string * string)>) (input: string) =
            match customMap with
            | (replaceWhat, replaceWith)::tail -> doCustoMap tail (StringUtils.replace replaceWhat replaceWith input)
            | _ -> input

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
        |> doCustoMap (Map.toList opts.CustomMap)
        |> StringUtils.toCharArray
        |> Array.map (replaceChars opts.Separator)
        |> StringUtils.toCharSequence
        |> StringUtils.mapCharSequence (map opts.Separator)
        |> StringUtils.trim opts.Separator
        |> optionalToLower