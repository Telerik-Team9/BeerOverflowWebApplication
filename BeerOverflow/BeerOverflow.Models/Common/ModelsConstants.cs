namespace BeerOverflow.Models.Common
{
    internal static class ModelsConstants
    {
        // Beer Constants
        internal const int NameMaxLength = 40;
        internal const float ABVMinPercent = 0;
        internal const float ABVMaxPercent = 60;
        internal const double PriceMin = 0;
        internal const double PriceMax = double.MaxValue;
        internal const int BeerDescriptionMaxLength = 300;

        // Review Costants
        internal const int ReviewContentMaxLength = 2000;
        internal const float RatingMin = 0;
        internal const float RatingMax = 5;

        //Style constants
        internal const int StyleDescriptionMaxLength = 300;
    }
}
