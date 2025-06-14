using System.Collections.Generic;
using Verse.AI;
using RimWorld;
using Verse;

namespace Mashed_Spiribirds
{
    class JobDriver_FeedFromSpiribush : JobDriver
    {
        public override bool TryMakePreToilReservations(bool errorOnFailed)
        {
            return true;
        }

        protected override IEnumerable<Toil> MakeNewToils()
        {
            this.FailOnDespawnedOrNull(TargetIndex.A);
            yield return Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.Touch);
            Toil toilWait = Toils_General.WaitWith(TargetIndex.A, DurationTicks, false, true);
            toilWait.WithProgressBarToilDelay(TargetIndex.A);
            yield return toilWait;
            yield return Toils_General.Do(delegate
            {
                pawn.needs.TryGetNeed(NeedDefOf.Food).CurLevel = pawn.needs.TryGetNeed(NeedDefOf.Food).MaxLevel;
                Comp_SpiribugMolt moltComp = pawn.TryGetComp<Comp_SpiribugMolt>();
                moltComp?.IncrementProgress(0.01f);
            });
            yield break;
        }

        private const int DurationTicks = 100;
    }
}
