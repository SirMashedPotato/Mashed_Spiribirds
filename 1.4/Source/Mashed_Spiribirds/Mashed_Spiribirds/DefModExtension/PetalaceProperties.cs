﻿using Verse;
using System.Collections.Generic;

namespace Mashed_Spiribirds
{
    public class PetalaceProperties : DefModExtension
    {
        public List<PollenAffinity> pollenAffinity;
        public ThingDef spiribugKind;
        public int extraMoltGain = 1;

        public static PetalaceProperties Get(Def def)
        {
            return def.GetModExtension<PetalaceProperties>();
        }
    }

    public class PollenAffinity
    {
        public HediffDef pollenHediff;
        public float severityGain = 0.1f;
        public float limit = 1f;
    }
}
