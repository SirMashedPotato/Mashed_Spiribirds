using Verse;
using System.Collections.Generic;

namespace Mashed_Spiribirds
{
    class PetalaceProperties : DefModExtension
    {
        public List<PollenAffinity> pollenAffinity;

        public static PetalaceProperties Get(Def def)
        {
            return def.GetModExtension<PetalaceProperties>();
        }
    }

    public class PollenAffinity
    {
        public HediffDef pollenHediff;
        public float severityGain = 0.1f;
    }
}
