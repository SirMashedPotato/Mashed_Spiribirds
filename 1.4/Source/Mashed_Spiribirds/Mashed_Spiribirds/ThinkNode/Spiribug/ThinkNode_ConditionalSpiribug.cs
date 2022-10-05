using Verse;
using Verse.AI;

namespace Mashed_Spiribirds
{
    class ThinkNode_ConditionalSpiribug : ThinkNode_Conditional
    {

        protected override bool Satisfied(Pawn pawn)
        {
            return !pawn.def.tradeTags.NullOrEmpty() && pawn.def.tradeTags.Contains("Mashed_Spiribug_Spiribug");
        }
    }
}
