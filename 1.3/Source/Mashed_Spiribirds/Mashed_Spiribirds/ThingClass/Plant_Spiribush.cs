using RimWorld;
using Verse;

namespace Mashed_Spiribirds
{
    public class Plant_Spiribush : Plant
    {
        public override void PlantCollected(Pawn by)
        {
            if (this.HarvestableNow)
            {
                var props = SpiribushProperties.Get(this.def);
                float chance = this.sown ? props.chanceSown : props.chanceWild;
                if (Rand.Chance(chance))
                {
                    if (props != null && !props.spirbushSpawns.NullOrEmpty())
                    {
                        PawnKindDef kindDef = props.spirbushSpawns.RandomElementByWeight(x => x.weight).kindDef;
                        Pawn newP = PawnGenerator.GeneratePawn(kindDef, null);
                        GenSpawn.Spawn(newP, this.Position, this.Map);
                    }
                }
            }
            base.PlantCollected(by);
        }
    }
}
