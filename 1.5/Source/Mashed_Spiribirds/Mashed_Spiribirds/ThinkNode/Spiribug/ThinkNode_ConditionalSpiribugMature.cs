using Verse;

namespace Mashed_Spiribirds
{
    class ThinkNode_ConditionalSpiribugMature : ThinkNode_ConditionalSpiribug
    {

        protected override bool Satisfied(Pawn pawn)
        {
            return base.Satisfied(pawn) && pawn.ageTracker.CurLifeStageIndex > 0;
        }
    }
}
