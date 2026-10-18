using Verse;
using System.Collections.Generic;
using RimWorld;

namespace Mashed_Spiribirds
{
    public class SpiribushProperties : DefModExtension
    {
        public List<BiomeAnimalRecord> spirbushSpawns;
        public float chanceWild = 0.15f;
        public float chanceSown = 0.05f;

        public static SpiribushProperties Get(Def def)
        {
            return def.GetModExtension<SpiribushProperties>();
        }
    }
}
