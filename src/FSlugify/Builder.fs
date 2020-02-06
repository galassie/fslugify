namespace FSlugify

open FSlugify.SlugGenerator

module Builder =

    type SlugGeneratorBuilder() =
        member __.Yield _ =
            DefaultSlugGeneratorOptions

        member __.Run options =
            slugify options

        [<CustomOperation "separator">]
        member __.Separator(options, s) : SlugGeneratorOptions =
            { options with Separator = s }

        [<CustomOperation "lowercase">]
        member __.Lowercase(options, l) : SlugGeneratorOptions =
            { options with Lowercase = l }

        [<CustomOperation "custom_map">]
        member __.CustomMap(options, cm) : SlugGeneratorOptions =
            { options with CustomMap = cm :: options.CustomMap }

    let slug = SlugGeneratorBuilder()