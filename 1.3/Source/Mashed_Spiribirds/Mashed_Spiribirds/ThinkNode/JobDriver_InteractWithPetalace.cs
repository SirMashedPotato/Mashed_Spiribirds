using System;
using System.Collections.Generic;
using Verse;
using Verse.AI;
using RimWorld;

namespace Mashed_Spiribirds
{
    class JobDriver_InteractWithPetalace : JobDriver
    {
        private Pawn Target
        {
            get
            {
                return (Pawn)this.job.GetTarget(TargetIndex.A).Thing;
            }
        }

        public override bool TryMakePreToilReservations(bool errorOnFailed)
        {
            return this.pawn.CanReach(Target, PathEndMode.Touch, Danger.None);
        }

        protected override IEnumerable<Toil> MakeNewToils()
        {
            yield return Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.OnCell).FailOnDespawnedOrNull(TargetIndex.A);
            Toil toil = Toils_General.Wait(DurationTicks, TargetIndex.None);
            toil.WithProgressBarToilDelay(TargetIndex.A, false, -0.5f);
            toil.FailOnDespawnedOrNull(TargetIndex.A);
            toil.FailOnCannotTouch(TargetIndex.A, PathEndMode.Touch);
            yield return toil;
            yield return Toils_General.Do(new Action(ReadyPollen));
            yield break;
        }

        public void ReadyPollen()
        {
            Pawn spiribird = this.pawn;
            Pawn target = Target;
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
                        AddThought(target);
                        target.records.Increment(RecordDefOf.Mashed_Spiribird_SpiribirdInteractions);
                    }
                }
            }
        }
        public void AddPollen(Pawn target, HediffDef hediff, float severity, float quality)
        {
            float actualSeverity = severity * quality;
            Hediff pollen = HediffMaker.MakeHediff(hediff, target, null);
            pollen.Severity = actualSeverity;
            target.health.AddHediff(pollen);
        }

        private void AddThought(Pawn recipient)
        {
            Thought_Memory newThought = (Thought_Memory)ThoughtMaker.MakeThought(ThoughtDefOf.Mashed_Spiribird_SpiribirdThought);
            if (recipient.needs.mood != null)
            {
                recipient.needs.mood.thoughts.memories.TryGainMemory(newThought, null);
            }
        }

        private const int DurationTicks = 10;
    }
}
