using Verse;
using Verse.AI;
using RimWorld;

namespace Mashed_Spiribirds
{
	public class JobGiver_InteractWithPetalace : ThinkNode_JobGiver
    {
		protected override Job TryGiveJob(Pawn pawn)
		{
			Thing thing = null;
			float radius = pawn.Faction == null ? radiusWild : radiusTame;
			foreach (Thing t in GenRadial.RadialDistinctThingsAround(pawn.Position, pawn.Map, radius, true).InRandomOrder())
			{
				if (t is Pawn target)
				{
					Log.Message("Checking for pawn: " + pawn.NameFullColored + ", target is: " + target.NameFullColored);
					if (target.apparel != null)
                    {
						Log.Message("Checking for pawn: " + pawn.NameFullColored + ", apparel target is: " + target.NameFullColored);
						Apparel petalace = target.apparel.WornApparel.Find(x => x.def.thingCategories.Contains(ThingCategoryDefOf.Mashed_Spiribird_ApparelPetalace));
						if (petalace != null)
						{
							thing = t;
						}
					}
				}
			}
			if (thing != null)
			{
				Job job = JobMaker.MakeJob(JobDefOf.Mashed_Spiribirds_InteractWithPetalace, thing);
				job.checkOverrideOnExpire = true;
				job.expiryInterval = 500;
				job.collideWithPawns = true;
				return job;
			}
			return null;
		}

		public float radiusTame = 8;
		public float radiusWild = 4;
	}
}
