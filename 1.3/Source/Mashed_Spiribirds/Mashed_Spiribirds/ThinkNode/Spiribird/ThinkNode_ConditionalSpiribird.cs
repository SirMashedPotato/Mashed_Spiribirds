using Verse;
using Verse.AI;

namespace Mashed_Spiribirds
{
    public class ThinkNode_ConditionalSpiribird : ThinkNode_Conditional
    {

        protected override bool Satisfied(Pawn pawn)
        {
            return !pawn.def.tradeTags.NullOrEmpty() && pawn.def.tradeTags.Contains("Mashed_Spiribird_Spiribird");
        }
    }
}
