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
            var result = slugify(options, "Déjà Vu!");
            Console.WriteLine($"Slug generated from \"Déjà Vu!\" with default options: \"{result}\"\n");

            var optionsWithCustomSeparator = new SlugGeneratorOptions('#', true, ListModule.OfSeq(new List<Tuple<string, string>>()));
            var resultWithCustomSeparator = slugify(optionsWithCustomSeparator, "Déjà Vu!");
            Console.WriteLine($"Slug generated from \"Déjà Vu!\" with custom separator: \"{resultWithCustomSeparator}\"\n");

            var optionsWithoutLowercase = new SlugGeneratorOptions('_', false, ListModule.OfSeq(new List<Tuple<string, string>>()));
            var resultWithoutLowercase = slugify(optionsWithoutLowercase, "Déjà Vu!");
            Console.WriteLine($"Slug generated from \"Déjà Vu!\" without lowercase: \"{resultWithoutLowercase}\"\n");

            var customMap = new List<Tuple<string, string>>
            {
                Tuple.Create("|", " or "),
                Tuple.Create("🤡", " clown ")
            };
            var optionsWithCustomMap = new SlugGeneratorOptions('_', true, ListModule.OfSeq(customMap));
            var resultWithCustomMap = slugify(optionsWithCustomMap, "Test | 🤡");
            Console.WriteLine($"Slug generated from \"Test | 🤡\" with custom map: \"{resultWithCustomMap}\"\n");
        }
    }
}
