using RimWorld;
using System.Collections.Generic;
using Verse;
using System.Linq;

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
                ///Spiribug molt
                if (LoadedModManager.RunningModsListForReading.Any(x => x.Name == "Mashed's Spiribugs" || x.PackageId == "SirMashedPotato.Spiribugs"))
                {
                    float bugQ = ((float)qc + 1) / 3;
                    float actualSeverity = 0.1f * bugQ;
                    yield return new StatDrawEntry(StatCategoryDefOf.Mashed_Spiribird_PetalaceStats, "Mashed_Spiribird_MoltLabel".Translate(), "",
                        "Mashed_Spiribird_MoltAffinity".Translate(actualSeverity.ToStringPercent()),
                        0, null, null, false); 
                    ///Spiribug molt affinity
                    if (props.spiribugKind != null)
                    {
                        CompProperties_SpiribugMolt moltComp = props.spiribugKind.GetCompProperties<CompProperties_SpiribugMolt>();
                        bugQ = ((float)qc + 1 + props.extraMoltGain) / 3;
                        actualSeverity = moltComp.baseIncrease * bugQ;
                        yield return new StatDrawEntry(StatCategoryDefOf.Mashed_Spiribird_PetalaceStats, props.spiribugKind.label, "",
                            "Mashed_Spiribird_MoltAffinityBoosted".Translate(props.spiribugKind.label, props.extraMoltGain, actualSeverity.ToStringPercent()),
                            0, null, null, false);
                    }
                }
               
            }
        }
    }
}
