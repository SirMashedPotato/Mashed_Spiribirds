using System;
using System.Collections.Generic;
using Verse;
using RimWorld;

namespace Mashed_Spiribirds
{
    public static class Utility
    {
        public static void ReadyPollen(Pawn target, Pawn spiribird)
        {
            if (spiribird != null && target != null)
            {
                var spiribirdProps = SpiribirdProperties.Get(spiribird.def);
                if (spiribirdProps != null && !target.apparel.WornApparel.NullOrEmpty())
                {
                    Apparel petalace = target.apparel.WornApparel.Find(x => x.def.thingCategories.Contains(ThingCategoryDefOf.Mashed_Spiribird_ApparelPetalace));
                    var petalaceProps = PetalaceProperties.Get(petalace.def);
                    if(petalaceProps != null)
                    {
                        petalace.TryGetQuality(out QualityCategory qc);
                        float q = ((float)qc + 1) / 3;  //Lower than normal quality < 1, higher than normal quality > 1, normal quality == 1
                        if (spiribirdProps.isPrismatic)
                        {
                            foreach(PollenAffinity pa in petalaceProps.pollenAffinity)
                            {
                                AddPollen(target, pa.pollenHediff, pa.severityGain, q);
                            }
                        }
                        else
                        {
                            if (spiribirdProps.pollenHediff != null)
                            {
                                float severity = petalaceProps.pollenAffinity.Find(x => x.pollenHediff == spiribirdProps.pollenHediff).severityGain;
                                AddPollen(target, spiribirdProps.pollenHediff, severity, q);
                            }
                        }
                        target.records.Increment(RecordDefOf.Mashed_Spiribird_SpiribirdInteractions);
                    }
                }
            }
        }
        public static void AddPollen(Pawn target, HediffDef hediff, float severity, float quality)
        {
            float actualSeverity = severity * quality;
            Hediff pollen = HediffMaker.MakeHediff(hediff, target, null);
            pollen.Severity = actualSeverity;
            target.health.AddHediff(pollen);
        }
    }
}
