using Verse;
using UnityEngine;

namespace Mashed_Spiribirds
{
    public class Comp_SpiribugMolt : ThingComp
    {
		public CompProperties_SpiribugMolt Props
		{
			get
			{
				return (CompProperties_SpiribugMolt)this.props;
			}
		}

		private float currentProgress = 0f;

        public float CurrentProgress => currentProgress;

        public void IncrementProgress(float q)
        {
            currentProgress = Mathf.Clamp(currentProgress + (Props.baseIncrease * q), 0f, 1f);
            if(currentProgress == 1f)
            {
                currentProgress = 0f;
                SpawnItem();
            }
        }

        public void SpawnItem()
        {
            Thing thing = ThingMaker.MakeThing(Props.thingDef);
            GenPlace.TryPlaceThing(thing, parent.Position, parent.Map, ThingPlaceMode.Direct);
        }

        public override string CompInspectStringExtra()
        {
            return "Mashed_Spiribird_MoltProgress".Translate(Props.thingDef.label, currentProgress.ToStringPercent());
        }

        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Values.Look(ref currentProgress, "currentProgress", 0f);
        }
    }
}
