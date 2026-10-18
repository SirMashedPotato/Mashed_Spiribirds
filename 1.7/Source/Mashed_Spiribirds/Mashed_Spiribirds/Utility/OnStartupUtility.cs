using System.Collections.Generic;
using System.Linq;
using Verse;

namespace Mashed_Spiribirds
{
    [StaticConstructorOnStartup]
    public static class OnStartupUtility
    {
        public static HashSet<PawnKindDef> spiribirdKinds = [];
        public static HashSet<PawnKindDef> spiribugKinds = [];

        static OnStartupUtility()
        {
            foreach (PawnKindDef pawnDef in DefDatabase<PawnKindDef>.AllDefsListForReading.Where(x => x.race != null).ToList())
            {
                if (pawnDef.race.tradeTags.NullOrEmpty()) continue;
                if (pawnDef.race.tradeTags.Contains("Mashed_Spiribird_Spiribird"))
                {
                    spiribirdKinds.Add(pawnDef);
                }

                if (pawnDef.race.tradeTags.Contains("Mashed_Spiribug_Spiribug"))
                {
                    spiribugKinds.Add(pawnDef);
                }
            }
        }
    }
}
