using Verse;
using UnityEngine;

namespace Mashed_Spiribirds
{
    public class Comp_SpiribugMolt : ThingComp
    {
		public CompProperties_SpiribugMolt Props => (CompProperties_SpiribugMolt)props;

		private float _currentProgress = 0f;

        public float CurrentProgress => _currentProgress;

        public void IncrementProgress(float q)
        {
            _currentProgress = Mathf.Clamp(_currentProgress + (Props.baseIncrease * q), 0f, 1f);
            if (_currentProgress < 1f) return;
            _currentProgress = 0f;
            SpawnItem();
        }

        private void SpawnItem()
        {
            Thing thing = ThingMaker.MakeThing(Props.thingDef);
            GenPlace.TryPlaceThing(thing, parent.Position, parent.Map, ThingPlaceMode.Direct);
        }

        public override string CompInspectStringExtra()
        {
            return "Mashed_Spiribird_MoltProgress".Translate(Props.thingDef.label, _currentProgress.ToStringPercent());
        }

        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Values.Look(ref _currentProgress, "currentProgress", 0f);
        }
    }
}
