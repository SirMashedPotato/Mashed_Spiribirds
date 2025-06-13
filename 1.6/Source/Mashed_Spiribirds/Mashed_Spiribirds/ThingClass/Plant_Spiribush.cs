using RimWorld;
using Verse;

namespace Mashed_Spiribirds
{
    public class Plant_Spiribush : Plant
    {
        public override void PlantCollected(Pawn by, PlantDestructionMode plantDestructionMode)
        {
            if (HarvestableNow)
            {
                var props = SpiribushProperties.Get(def);
                float chance = sown ? props.chanceSown : props.chanceWild;
                if (Rand.Chance(chance))
                {
                    if (props != null && !props.spirbushSpawns.NullOrEmpty())
                    {
                        PawnKindDef kindDef = props.spirbushSpawns.RandomElementByWeight(x => x.commonality).animal;
                        Pawn newP = PawnGenerator.GeneratePawn(kindDef, null);
                        GenSpawn.Spawn(newP, Position, Map);
                    }
                }
            }
            base.PlantCollected(by, plantDestructionMode);
        }
    }
}
