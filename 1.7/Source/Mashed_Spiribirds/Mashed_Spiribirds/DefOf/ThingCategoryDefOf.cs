using Verse;
using RimWorld;

namespace Mashed_Spiribirds
{
    [DefOf]
    public static class ThingCategoryDefOf
    {
        static ThingCategoryDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(ThingCategoryDefOf));
        }
        public static ThingCategoryDef Mashed_Spiribird_ApparelPetalace;
    }
}
