using static FSlugify.SlugGenerator;

namespace FSlugify.Adapter
{
    public class SlugGeneratorObj : ISlugGenerator
    {
        private readonly SlugGeneratorOptions _options;

        public SlugGeneratorObj(SlugGeneratorOptions options)
        {
            _options = options;
        }

        public string Slugify(string toSlugify)
            => slugify(_options, toSlugify);

        public string Slugify(string toSlugify, SlugGeneratorOptions options)
            => slugify(options, toSlugify);
    }
}
