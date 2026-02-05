using RimWorld;
using RimWorld.Planet;
using Verse;

namespace Mashed_Spiribirds
{
    internal class TileMutatorWorker_SpiribugHabitat : TileMutatorWorker
    {
        private const float AnimalCommonalityFactor = 20f;


        public TileMutatorWorker_SpiribugHabitat(TileMutatorDef def) : base(def)
        {
        }
        public override float AnimalCommonalityFactorFor(PawnKindDef animal, PlanetTile tile)
        {
            if (!ModsConfig.OdysseyActive)
            {
                return 1f;
            }
            if (!OnStartupUtility.spiribugKinds.Contains(animal))
            {
                return 1f;
            }
            return AnimalCommonalityFactor;
        }
    }
}
