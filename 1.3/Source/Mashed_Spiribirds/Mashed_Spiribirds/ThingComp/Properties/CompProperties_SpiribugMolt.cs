using Verse;
using RimWorld;

namespace Mashed_Spiribirds
{
    public class CompProperties_SpiribugMolt : CompProperties
    {
        public CompProperties_SpiribugMolt()
        {
            this.compClass = typeof(Comp_SpiribugMolt);
        }

        public ThingDef thingDef;
        public RecordDef recordDef;
        public int amount = 1;
        public float baseIncrease = 0.1f;
    }
}
