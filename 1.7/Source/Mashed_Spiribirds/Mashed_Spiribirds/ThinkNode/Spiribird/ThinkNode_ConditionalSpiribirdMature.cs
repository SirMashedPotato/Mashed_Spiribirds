using Verse;

namespace Mashed_Spiribirds
{
    class ThinkNode_ConditionalSpiribirdMature : ThinkNode_ConditionalSpiribird
    {

        protected override bool Satisfied(Pawn pawn)
        {
            return base.Satisfied(pawn) && pawn.ageTracker.CurLifeStageIndex > 0;
        }
    }
}
