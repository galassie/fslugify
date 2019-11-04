using static FSlugify.SlugGenerator;

namespace FSlugify.Adapter
{
    public interface ISlugGeneratorOptionsBuilder
    {
        ISlugGeneratorOptionsBuilder Init();
        ISlugGeneratorOptionsBuilder WithCustomSeparator(char customSeparator);
        ISlugGeneratorOptionsBuilder WithLowercaseOn(bool isLowercaseOn);
        ISlugGeneratorOptionsBuilder AddCustomMap(string from, string to);
        SlugGeneratorOptions Build();
    }
}