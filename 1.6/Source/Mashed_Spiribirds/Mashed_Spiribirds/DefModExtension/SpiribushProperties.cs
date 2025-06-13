using Verse;
using System.Collections.Generic;

namespace Mashed_Spiribirds
{
    public class SpiribushProperties : DefModExtension
    {
        public List<SpiribushSpawner> spirbushSpawns;
        public float chanceWild = 0.15f;
        public float chanceSown = 0.05f;

        public static SpiribushProperties Get(Def def)
        {
            return def.GetModExtension<SpiribushProperties>();
        }
    }

    public class SpiribushSpawner
    {
        public PawnKindDef kindDef;
        public float weight = 0.1f;
    }
}
