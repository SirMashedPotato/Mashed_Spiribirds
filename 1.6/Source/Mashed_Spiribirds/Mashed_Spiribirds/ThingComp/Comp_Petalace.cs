using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Mashed_Spiribirds
{
    class Comp_Petalace : ThingComp
    {
        public override void Notify_Unequipped(Pawn pawn)
        {
            base.Notify_Unequipped(pawn);
            PetalaceProperties props = PetalaceProperties.Get(parent.def);
            if (props.pollenAffinity != null)
            {
                foreach (PollenAffinity pa in props.pollenAffinity)
                {
                    Hediff h = pawn.health.hediffSet.GetFirstHediffOfDef(pa.pollenHediff);
                    if (h != null)
                    {
                        pawn.health.RemoveHediff(h);
                    }
                }
            }
        }

        public override IEnumerable<StatDrawEntry> SpecialDisplayStats()
        {
            PetalaceProperties props = PetalaceProperties.Get(parent.def);
            if (props != null)
            {
                parent.TryGetQuality(out QualityCategory qc);
                float q = ((float)qc + 1) / 3;

                ///Spiribird pollen affinity
                foreach (PollenAffinity pa in props.pollenAffinity)
                {
                    float actualSeverity = pa.severityGain * q;
                    yield return new StatDrawEntry(StatCategoryDefOf.Mashed_Spiribird_PetalaceStats, pa.pollenHediff.label, actualSeverity.ToStringPercent(), 
                        "Mashed_Spiribird_PollenAffinity".Translate(pa.pollenHediff.label, pa.limit.ToStringPercent(), pa.severityGain.ToStringPercent(), actualSeverity.ToStringPercent()), 
                        0, null, null, false);
                }

                ///Spiribug molt
                if (props.spiribugKind != null)
                {
                    float bugQ = ((float)qc + 1) / 3;
                    float actualSeverity = 0.1f * bugQ;
                    yield return new StatDrawEntry(StatCategoryDefOf.Mashed_Spiribird_PetalaceStats, "Mashed_Spiribird_MoltLabel".Translate(), actualSeverity.ToStringPercent(),
                        "Mashed_Spiribird_MoltAffinity".Translate(actualSeverity.ToStringPercent()),
                        0, null, null, false);

                    ///Spiribug molt affinity
                    CompProperties_SpiribugMolt moltComp = props.spiribugKind.GetCompProperties<CompProperties_SpiribugMolt>();
                    bugQ = ((float)qc + 1 + props.extraMoltGain) / 3;
                    actualSeverity = moltComp.baseIncrease * bugQ;
                    yield return new StatDrawEntry(StatCategoryDefOf.Mashed_Spiribird_PetalaceStats, props.spiribugKind.label, actualSeverity.ToStringPercent(),
                        "Mashed_Spiribird_MoltAffinityBoosted".Translate(props.spiribugKind.label, props.extraMoltGain, actualSeverity.ToStringPercent()),
                        0, null, null, false);
                }
            }
        }
    }
}
