using Verse;
using Verse.AI;

namespace Mashed_Spiribirds
{
    class JobGiver_FeedFromSpiribush : ThinkNode_JobGiver
	{
		protected override Job TryGiveJob(Pawn pawn)
		{
			if (pawn.Downed)
			{
				return null;
			}
			Thing plant = GenClosest.ClosestThingReachable(pawn.Position, pawn.Map, ThingRequest.ForDef(ThingDefOf.Mashed_Spiribird_Spiribush), PathEndMode.OnCell, 
				TraverseParms.For(pawn, Danger.Deadly, TraverseMode.ByPawn, false), radius, null, null, 0, -1, false, RegionType.Set_Passable, false);
			return plant == null ? null : JobMaker.MakeJob(JobDefOf.Mashed_Spiribirds_FeedFromSpiribush, plant);
		}

		public float radius = 20f;
	}
}
