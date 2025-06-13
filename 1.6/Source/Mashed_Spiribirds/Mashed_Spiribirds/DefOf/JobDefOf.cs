using Verse;
using RimWorld;

namespace Mashed_Spiribirds
{
    [DefOf]
    public static class JobDefOf
    {
        static JobDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(JobDefOf));
        }

        public static JobDef Mashed_Spiribirds_InteractWithPetalace;
        public static JobDef Mashed_Spiribirds_FeedFromSpiribush;
    }
}
