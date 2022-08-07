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
                this.parent.TryGetQuality(out QualityCategory qc);
                float q = ((float)qc + 1) / 3;
                ///Spiribird pollen affinity
                foreach (PollenAffinity pa in props.pollenAffinity)
                {
                    float actualSeverity = pa.severityGain * q;
                    yield return new StatDrawEntry(StatCategoryDefOf.Mashed_Spiribird_PetalaceStats, pa.pollenHediff.label, "", 
                        "Mashed_Spiribird_PollenAffinity".Translate(pa.pollenHediff.label, pa.limit.ToStringPercent(), pa.severityGain.ToStringPercent(), actualSeverity.ToStringPercent()), 
                        0, null, null, false);
                }
                ///Spiribug molt affinity
                if (props.spiribugKind != null)
                {
                    CompProperties_SpiribugMolt moltComp = props.spiribugKind.GetCompProperties<CompProperties_SpiribugMolt>();
                    float bugQ = ((float)qc + 1 + props.extraMoltGain) / 3;
                    float actualSeverity = moltComp.baseIncrease * bugQ;
                    yield return new StatDrawEntry(StatCategoryDefOf.Mashed_Spiribird_PetalaceStats, props.spiribugKind.label, "",
                        "Mashed_Spiribird_MoltAffinity".Translate(props.spiribugKind.label, actualSeverity.ToStringPercent()),
                        0, null, null, false);
                }
            }
        }
    }
}
