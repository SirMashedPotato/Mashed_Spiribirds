using RimWorld;

namespace Mashed_Spiribirds
{
    [DefOf]
    public static class ThoughtDefOf
    {
        static ThoughtDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(ThoughtDefOf));
        }

        public static ThoughtDef Mashed_Spiribird_SpiribirdThought;
    }
}
