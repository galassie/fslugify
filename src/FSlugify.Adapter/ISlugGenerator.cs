using static FSlugify.SlugGenerator;

namespace FSlugify.Adapter
{
    public interface ISlugGenerator
    {
        string Slugify(string toSlugify);
        string Slugify(string toSlugify, SlugGeneratorOptions options); 
    }
}