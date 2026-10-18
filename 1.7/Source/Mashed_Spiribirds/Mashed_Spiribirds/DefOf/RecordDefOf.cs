using Verse;
using RimWorld;

namespace Mashed_Spiribirds
{
    [DefOf]
    public static class RecordDefOf
    {
        static RecordDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(RecordDefOf));
        }
        public static RecordDef Mashed_Spiribird_SpiribirdInteractions;
    }
}
