using Verse;
using RimWorld;

namespace Mashed_Spiribirds
{
    [DefOf]
    public static class ThingDefOf
    {
        static ThingDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(ThingDefOf));
        }

        public static ThingDef Mashed_Spiribird_Spiribush;
    }
}
