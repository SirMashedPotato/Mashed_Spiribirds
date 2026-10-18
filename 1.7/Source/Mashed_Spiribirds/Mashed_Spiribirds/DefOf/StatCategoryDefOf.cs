using RimWorld;

namespace Mashed_Spiribirds
{
    [DefOf]
    public static class StatCategoryDefOf
    {
        static StatCategoryDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(StatCategoryDefOf));
        }

        public static StatCategoryDef Mashed_Spiribird_PetalaceStats;
    }
}
