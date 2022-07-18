using System.Collections.Generic;
using Verse.AI;
using RimWorld;

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
            Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.Touch);
            Toils_General.WaitWith(TargetIndex.A, DurationTicks, false, true);
            yield return Toils_General.Do(delegate
            {
                this.pawn.needs.TryGetNeed(NeedDefOf.Food).CurLevel = this.pawn.needs.TryGetNeed(NeedDefOf.Food).MaxLevel;
            });
            yield break;
        }

        private const int DurationTicks = 100;
    }
}
