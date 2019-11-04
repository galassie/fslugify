using System;
using System.Collections.Generic;
using Microsoft.FSharp.Collections;
using NUnit.Framework;
using FSlugify.Adapter;
using static FSlugify.SlugGenerator;

namespace FSlugify.Adapter.Tests
{
    public class SlugGeneratorOptionsBuilderTests
    {
        [Test]
        public void WithCustomSeparator_WhenBuild_ShouldReturnSlugGeneratorOptionsWithCustomSeparator()
        {
            var option = new SlugGeneratorOptionsBuilder()
                            .Init()
                            .WithCustomSeparator('@')
                            .Build();

            Assert.AreEqual('@', option.Separator);
            Assert.AreEqual(DefaultSlugGeneratorOptions.Lowercase, option.Lowercase);
            Assert.AreEqual(DefaultSlugGeneratorOptions.CustomMap, option.CustomMap);
        }

        [Test]
        public void WithLowercaseOn_WhenBuild_ShouldReturnSlugGeneratorOptionsWithLowercaseOnOrOf()
        {
            var option = new SlugGeneratorOptionsBuilder()
                            .Init()
                            .WithLowercaseOn(false)
                            .Build();

            Assert.AreEqual(DefaultSlugGeneratorOptions.Separator, option.Separator);
            Assert.AreEqual(false, option.Lowercase);
            Assert.AreEqual(DefaultSlugGeneratorOptions.CustomMap, option.CustomMap);
        }

        [Test]
        public void WithCustomMaps_WhenBuild_ShouldReturnSlugGeneratorOptionsWithCustomMaps()
        {
            var option = new SlugGeneratorOptionsBuilder()
                            .Init()
                            .AddCustomMap("🐱", " cat ")
                            .AddCustomMap("🦇", " bat ")
                            .Build();

            Assert.AreEqual(DefaultSlugGeneratorOptions.Separator, option.Separator);
            Assert.AreEqual(DefaultSlugGeneratorOptions.Lowercase, option.Lowercase);
            
            var expectedCustomMaps = new List<Tuple<string, string>>
            {
                Tuple.Create("🐱", " cat "),
                Tuple.Create("🦇", " bat ")
            };
            Assert.AreEqual(ListModule.OfSeq(expectedCustomMaps), option.CustomMap);
        }


        [Test]
        public void BuildWithCustomSettings_ShouldReturnCustomOptions()
        {
            var option = new SlugGeneratorOptionsBuilder()
                            .Init()
                            .WithCustomSeparator('#')
                            .WithLowercaseOn(false)
                            .AddCustomMap("🐷", " pig ")
                            .AddCustomMap("🐢", " tortoise ")
                            .Build();

            Assert.AreEqual('#', option.Separator);
            Assert.AreEqual(false, option.Lowercase);
            
            var expectedCustomMaps = new List<Tuple<string, string>>
            {
                Tuple.Create("🐷", " pig "),
                Tuple.Create("🐢", " tortoise ")
            };
            Assert.AreEqual(ListModule.OfSeq(expectedCustomMaps), option.CustomMap);
        }
    }
}