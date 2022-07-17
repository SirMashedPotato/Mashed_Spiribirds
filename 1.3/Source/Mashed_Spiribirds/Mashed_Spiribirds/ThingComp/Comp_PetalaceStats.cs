using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Spiribirds
{
    class Comp_PetalaceStats : ThingComp
    {
        public override IEnumerable<StatDrawEntry> SpecialDisplayStats()
        {

            var props = PetalaceProperties.Get(this.parent.def);
            if (props != null)
            {
                foreach(PollenAffinity pa in props.pollenAffinity)
                {
                    this.parent.TryGetQuality(out QualityCategory qc);
                    float q = ((float)qc + 1) / 3;
                    float actualSeverity = pa.severityGain * q;
                    yield return new StatDrawEntry(StatCategoryDefOf.Mashed_Spiribird_PetalaceStats, pa.pollenHediff.label, "", 
                        "Mashed_Spiribird_PollenAffinity".Translate(pa.pollenHediff.label, pa.limit.ToStringPercent(), pa.severityGain.ToStringPercent(), actualSeverity.ToStringPercent()), 
                        0, null, null, false);
                }
            }
        }
    }
}
