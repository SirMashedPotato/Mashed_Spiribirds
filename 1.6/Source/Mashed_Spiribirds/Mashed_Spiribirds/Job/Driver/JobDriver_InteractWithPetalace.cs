using System;
using System.Collections.Generic;
using Verse;
using Verse.AI;
using RimWorld;

namespace Mashed_Spiribirds
{
    public class JobDriver_InteractWithPetalace : JobDriver
    {

        /// <summary>
        /// Almost exact copy of nuzzle, because that does exactly what I want
        /// </summary>
        public override bool TryMakePreToilReservations(bool errorOnFailed)
        {
            return true;
        }

        protected override IEnumerable<Toil> MakeNewToils()
        {
            this.FailOnDespawnedNullOrForbidden(TargetIndex.A);
            this.FailOnNotCasualInterruptible(TargetIndex.A);
            yield return Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.Touch);
            yield return Toils_Interpersonal.WaitToBeAbleToInteract(this.pawn);
            Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.Touch).socialMode = RandomSocialMode.Off;
            Toils_General.WaitWith(TargetIndex.A, DurationTicks, false, true).socialMode = RandomSocialMode.Off;
            yield return Toils_General.Do(delegate
            {
                Pawn recipient = (Pawn)this.pawn.CurJob.targetA.Thing;
                if (PawnIsSpiribug(this.pawn))
                {
                    InteractionDef def = DefDatabase<InteractionDef>.GetNamed("Mashed_Spiribug_SpiribugInteraction");
                    this.pawn.interactions.TryInteractWith(recipient, def);
                }
                else
                {
                    this.pawn.interactions.TryInteractWith(recipient, InteractionDefOf.Mashed_Spiribird_SpiribirdInteraction);
                }
            });
            yield break;
        }

        private bool PawnIsSpiribug(Pawn p)
        {
            return !p.def.tradeTags.NullOrEmpty() && p.def.tradeTags.Contains("Mashed_Spiribug_Spiribug");
        }

        private const int DurationTicks = 100;
    }
}
