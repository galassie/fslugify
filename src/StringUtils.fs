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