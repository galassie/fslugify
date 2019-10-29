namespace FSlugify

open FSlugify.CharSets
open FSlugify.CharMaps

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

    type private CharType =
        | LowercaseChar of char
        | UppercaseChar of char
        | Separator of char
        | EndOfLine

    let private charTypeToChar (eol: char) (input: CharType) = 
        match input with
        | LowercaseChar l -> l
        | UppercaseChar u -> u
        | Separator s -> s
        | EndOfLine -> eol

    let rec private doCustomMap (customMap: (string * string) list) (input: string) =
        match customMap with
        | (replaceWhat, replaceWith)::tail -> doCustomMap tail (StringUtils.replace replaceWhat replaceWith input)
        | [] -> input
 
    let private mapCharToCharType (separator: char) (input: char) =
        match input with
        | s when s = separator -> Separator separator
        | l when LowercaseCharSet.Contains l -> LowercaseChar l
        | u when UppercaseCharSet.Contains u -> UppercaseChar u
        | _ -> Separator separator

    let rec private mapCharArrayToCharTypeArray (map: char -> CharType) (input: char array) =
        [|
            for charInput in input do
                match charInput with
                | specialChar when InternalCharMap.ContainsKey specialChar ->
                    let mappedSpecialChar = InternalCharMap.Item specialChar
                    let charTypeArray = Array.map map (StringUtils.toCharArray mappedSpecialChar)
                    for charType in charTypeArray do yield charType
                | _ -> yield map charInput
            if input.Length % 2 <> 0 then yield EndOfLine
        |]

    let private mapCharTypeArrayToStringArray (separator: char) (input: CharType array) =
        let maxEvenIndex = input.Length - 2
        [|
            for i in 0..maxEvenIndex do
                match input.[i], input.[i+1] with
                | Separator _, Separator _ -> yield StringUtils.empty
                | LowercaseChar l, UppercaseChar _ -> yield sprintf "%c%c" l separator
                | charType, _ -> yield sprintf "%c" (charTypeToChar separator charType)
            yield sprintf "%c" (charTypeToChar separator input.[maxEvenIndex+1])
        |]

    let slugify (opts: SlugGeneratorOptions) (toSlugify: string) =
        if StringUtils.isNullOrEmpty toSlugify then StringUtils.empty
        else
            toSlugify
            |> doCustomMap opts.CustomMap
            |> StringUtils.toCharArray
            |> mapCharArrayToCharTypeArray (mapCharToCharType opts.Separator)
            |> mapCharTypeArrayToStringArray opts.Separator
            |> String.concat StringUtils.empty
            |> StringUtils.trim opts.Separator
            |> (if opts.Lowercase then StringUtils.toLower else id)