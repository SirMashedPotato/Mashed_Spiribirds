using Verse;
using RimWorld;

namespace Mashed_Spiribirds
{
    [DefOf]
    public static class PawnKindDefOf
    {
        static PawnKindDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(PawnKindDefOf));
        }

        public static PawnKindDef Mashed_Spiribird_SpiribirdGreen;
        public static PawnKindDef Mashed_Spiribird_SpiribirdOrange;
        public static PawnKindDef Mashed_Spiribird_SpiribirdRed;
        public static PawnKindDef Mashed_Spiribird_SpiribirdYellow;
        public static PawnKindDef Mashed_Spiribird_SpiribirdPrism;
    }
}
