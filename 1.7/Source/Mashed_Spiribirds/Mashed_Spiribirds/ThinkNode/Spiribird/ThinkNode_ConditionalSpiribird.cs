using System.Collections.Generic;
using Verse;
using Verse.AI;

namespace Mashed_Spiribirds
{
    public class ThinkNode_ConditionalSpiribird : ThinkNode_Conditional
    {

        protected override bool Satisfied(Pawn pawn)
        {
            return animalDefs.Contains(pawn.def);
        }

        public List<ThingDef> animalDefs;
    }
}
