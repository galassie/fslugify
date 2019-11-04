using System;
using System.Collections.Generic;
using Microsoft.FSharp.Collections;
using static FSlugify.SlugGenerator;

namespace FSlugify.Adapter
{
    public class SlugGeneratorOptionsBuilder : ISlugGeneratorOptionsBuilder
    {
        private char _customSeparator;
        private bool _isLowercaseOn;
        private IList<Tuple<string, string>> _customMaps;

        public ISlugGeneratorOptionsBuilder Init()
        {
            _customSeparator = DefaultSlugGeneratorOptions.Separator;
            _isLowercaseOn = DefaultSlugGeneratorOptions.Lowercase;
            _customMaps = new List<Tuple<string, string>>();
            return this;
        }

        public ISlugGeneratorOptionsBuilder WithCustomSeparator(char customSeparator)
        {
            _customSeparator = customSeparator;
            return this;
        }

        public ISlugGeneratorOptionsBuilder WithLowercaseOn(bool isLowercaseOn)
        {
            _isLowercaseOn = isLowercaseOn;
            return this;
        }
        
        public ISlugGeneratorOptionsBuilder AddCustomMap(string from, string to)
        {
            _customMaps.Add(Tuple.Create(from, to));
            return this;
        }
        
        public SlugGeneratorOptions Build()
        {
            return new SlugGeneratorOptions(
                _customSeparator,
                _isLowercaseOn,
                ListModule.OfSeq(_customMaps)
            );
        }
    }
}