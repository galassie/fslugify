namespace FSharp.Slugify

open System.Text

[<RequireQualifiedAccess>]
module StringUtils =
    
    let empty = ""

    let trim (input: string) =
        input.Trim() 

    let normalize (input: string) =
        input.Normalize(NormalizationForm.FormKD)

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

    let mapCharSequence (map: (char * char option) -> string) (input: (char * char option) array) =
        [| for el in input do yield map el |]
        |> String.concat empty