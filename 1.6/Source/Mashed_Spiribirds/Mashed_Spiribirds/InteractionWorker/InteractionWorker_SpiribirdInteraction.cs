using System.Collections.Generic;
using Verse;
using RimWorld;
using UnityEngine;

namespace Mashed_Spiribirds
{
    public class InteractionWorker_SpiribirdInteraction : InteractionWorker
    {
		public override void Interacted(Pawn initiator, Pawn recipient, List<RulePackDef> extraSentencePacks, out string letterText, out string letterLabel, out LetterDef letterDef, out LookTargets lookTargets)
		{
			this.ReadyPollen(initiator, recipient);
			letterText = null;
			letterLabel = null;
			letterDef = null;
			lookTargets = null;
		}

        public void ReadyPollen(Pawn spiribird, Pawn target)
        {
            if (spiribird != null && target != null)
            {
                var spiribirdProps = SpiribirdProperties.Get(spiribird.def);
                if (spiribirdProps != null && !target.apparel.WornApparel.NullOrEmpty())
                {
                    Apparel petalace = target.apparel.WornApparel.Find(x => x.def.thingCategories.Contains(ThingCategoryDefOf.Mashed_Spiribird_ApparelPetalace));
                    var petalaceProps = PetalaceProperties.Get(petalace.def);
                    if (petalaceProps != null)
                    {
                        petalace.TryGetQuality(out QualityCategory qc);
                        float q = ((float)qc + 1) / 3;  //Lower than normal quality < 1, higher than normal quality > 1, normal quality == 1
                        if (spiribirdProps.isPrismatic)
                        {
                            foreach (PollenAffinity pa in petalaceProps.pollenAffinity)
                            {
                                AddPollen(target, pa.pollenHediff, pa.severityGain, pa.limit, q);
                            }
                        }
                        else
                        {
                            if (spiribirdProps.pollenHediff != null)
                            {
                                PollenAffinity pa = petalaceProps.pollenAffinity.Find(x => x.pollenHediff == spiribirdProps.pollenHediff);
                                if (pa != null)
                                {
                                    AddPollen(target, pa.pollenHediff, pa.severityGain, pa.limit, q);
                                }
                            
                            }
                        }
                        target.records.Increment(RecordDefOf.Mashed_Spiribird_SpiribirdInteractions);
                    }
                }
            }
        }
        public void AddPollen(Pawn target, HediffDef hediff, float severity, float limit, float quality)
        {
            Hediff h = target.health.hediffSet.GetFirstHediffOfDef(hediff);
            if (h != null && h.Severity >= limit)
            {
                return;
            }
            float actualSeverity = severity * quality;
            Hediff pollen = HediffMaker.MakeHediff(hediff, target, null);
            pollen.Severity = Mathf.Clamp(actualSeverity, 0f, limit);
            target.health.AddHediff(pollen);
        }
    }
}
