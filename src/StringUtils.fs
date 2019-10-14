namespace FSharp.Slugify

open System.Text

[<RequireQualifiedAccess>]
module StringUtils =
    
    let empty = ""

    let trim (char: char) (input: string) =
        input.Trim(char) 

    let replace (replaceWhat: string) (replaceWith: string) (input: string) =
        input.Replace(replaceWhat, replaceWith)

    let normalize (input: string) =
        input.Normalize(NormalizationForm.FormKD)

    let toCharArray (input: string) =
        input.ToCharArray()

    let toLower (input: string) =
        input.ToLowerInvariant()
    
    let toCharSequence (charArray: char array) = 
        let maxIndex = charArray.Length - 1
        [|
            for i in 0..maxIndex do 
                if i <> maxIndex then
                    yield (charArray.[i], Some charArray.[i+1])
                else
                    yield (charArray.[i], None)
        |]

    let mapCharSequence (map: (char * char option) -> string) (input: (char * char option) array) =
        [| for el in input do yield map el |]
        |> String.concat empty