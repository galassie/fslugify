namespace FSharp.Slugify

module SlugGenerator =
    
    type SlugGeneratorOptions = string array

    let slugify (options: string array) (toSlugify: string) =
        toSlugify