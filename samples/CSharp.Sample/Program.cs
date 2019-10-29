using System;
using System.Collections.Generic;
using Microsoft.FSharp.Collections;
using static FSlugify.SlugGenerator;

namespace CSharp.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is a series of examples on how to use the SlugGenerator!\n");

            var options = DefaultSlugGeneratorOptions;
            var slug = slugify(options, "Déjà Vu!");
            Console.WriteLine($"Slug generated from \"Déjà Vu!\" with default options: \"{slug}\"\n");

            var optionsWithCustomSeparator = new SlugGeneratorOptions('#', true, ListModule.OfSeq(new List<Tuple<string, string>>()));
            var slugWithCustomSeparator = slugify(optionsWithCustomSeparator, "Déjà Vu!");
            Console.WriteLine($"Slug generated from \"Déjà Vu!\" with custom separator: \"{slugWithCustomSeparator}\"\n");

            var optionsWithoutLowercase = new SlugGeneratorOptions('_', false, ListModule.OfSeq(new List<Tuple<string, string>>()));
            var slugWithoutLowercase = slugify(optionsWithoutLowercase, "Déjà Vu!");
            Console.WriteLine($"Slug generated from \"Déjà Vu!\" without lowercase: \"{slugWithoutLowercase}\"\n");

            var customMap = new List<Tuple<string, string>>
            {
                Tuple.Create("|", " or "),
                Tuple.Create("🤡", " clown ")
            };
            var optionsWithCustomMap = new SlugGeneratorOptions('_', true, ListModule.OfSeq(customMap));
            var slugWithCustomMap = slugify(optionsWithCustomMap, "Test | 🤡");
            Console.WriteLine($"Slug generated from \"Test | 🤡\" with custom map: \"{slugWithCustomMap}\"\n");
        }
    }
}
