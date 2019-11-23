namespace FSlugify

open System.Text

[<RequireQualifiedAccess>]
module StringUtils =
    
    let empty = ""

    let isNullOrEmpty (input: string) =
        isNull input || input = empty

    let trim (char: char) (input: string) =
        input.Trim char 

    let replace (replaceWhat: string) (replaceWith: string) (input: string) =
        input.Replace(replaceWhat, replaceWith)

    let toCharArray (input: string) =
        input.ToCharArray()

    let toLower (input: string) =
        input.ToLowerInvariant()