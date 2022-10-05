using System.Collections.Generic;
using Verse;
using RimWorld;

namespace Mashed_Spiribirds
{
    public class InteractionWorker_SpiribugInteraction : InteractionWorker
    {
		public override void Interacted(Pawn initiator, Pawn recipient, List<RulePackDef> extraSentencePacks, out string letterText, out string letterLabel, out LetterDef letterDef, out LookTargets lookTargets)
		{
			this.ProgressMolt(initiator, recipient);
			letterText = null;
			letterLabel = null;
			letterDef = null;
			lookTargets = null;
		}

        public void ProgressMolt(Pawn spiribug, Pawn target)
        {
            if (spiribug != null && target != null)
            {
                Comp_SpiribugMolt moltComp = spiribug.TryGetComp<Comp_SpiribugMolt>();
                if (moltComp != null && !target.apparel.WornApparel.NullOrEmpty())
                {
                    Apparel petalace = target.apparel.WornApparel.Find(x => x.def.thingCategories.Contains(ThingCategoryDefOf.Mashed_Spiribird_ApparelPetalace));
                    var petalaceProps = PetalaceProperties.Get(petalace.def);
                    if (petalaceProps != null)
                    {
                        petalace.TryGetQuality(out QualityCategory qc);
                        float q = ((float)qc + 1);  //Lower than normal quality < 1, higher than normal quality > 1, normal quality == 1
                        if (petalaceProps.spiribugKind != null && spiribug.def == petalaceProps.spiribugKind)
                        {
                            q += petalaceProps.extraMoltGain;
                        }
                        q /= 3;
                        ///potential increase from specific petalaces
                        moltComp.IncrementProgress(q);
                        target.records.Increment(moltComp.Props.recordDef);
                    }
                }
            }
        }
    }
}
