using Verse;
using Verse.AI;

namespace Mashed_Spiribirds
{
    class ThinkNode_ConditionalSpiritbird : ThinkNode_Conditional
    {

        protected override bool Satisfied(Pawn pawn)
        {
            return pawn.def.tradeTags.Contains("Mashed_Spiribird_Spiribird") && pawn.ageTracker.CurLifeStageIndex > 0;
        }
    }
}
