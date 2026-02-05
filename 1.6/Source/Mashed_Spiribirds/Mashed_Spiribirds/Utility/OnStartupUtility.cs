using System.Collections.Generic;
using System.Linq;
using Verse;

namespace Mashed_Spiribirds
{
    [StaticConstructorOnStartup]
    public static class OnStartupUtility
    {
        public static HashSet<PawnKindDef> spiribirdKinds = new HashSet<PawnKindDef> { };
        public static HashSet<PawnKindDef> spiribugKinds = new HashSet<PawnKindDef> { };

        static OnStartupUtility()
        {
            foreach (PawnKindDef pawnDef in DefDatabase<PawnKindDef>.AllDefsListForReading.Where(x => x.race != null).ToList())
            {
                if (!pawnDef.race.tradeTags.NullOrEmpty())
                {
                    if (pawnDef.race.tradeTags.Contains("Mashed_Spiribird_Spiribird"))
                    {
                        spiribirdKinds.Add(pawnDef);
                    }

                    if (pawnDef.race.tradeTags.Contains("Mashed_Spiribird_Spiribug"))
                    {
                        spiribugKinds.Add(pawnDef);
                    }
                }
            }
        }
    }
}
