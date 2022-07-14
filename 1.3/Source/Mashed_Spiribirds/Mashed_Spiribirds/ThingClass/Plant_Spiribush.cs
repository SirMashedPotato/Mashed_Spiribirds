﻿using RimWorld;
using Verse;
using System.Collections.Generic;

namespace Mashed_Spiribirds
{
    [StaticConstructorOnStartup]
    public static class SpiribirdList
    {
        private static Dictionary<PawnKindDef, float> spiribirds = new Dictionary<PawnKindDef, float>();

        static SpiribirdList()
        {
            spiribirds.Add(PawnKindDefOf.Mashed_Spiribird_SpiribirdGreen, 5f);
            spiribirds.Add(PawnKindDefOf.Mashed_Spiribird_SpiribirdOrange, 5f);
            spiribirds.Add(PawnKindDefOf.Mashed_Spiribird_SpiribirdPink, 5f);
            spiribirds.Add(PawnKindDefOf.Mashed_Spiribird_SpiribirdRed, 5f);
            spiribirds.Add(PawnKindDefOf.Mashed_Spiribird_SpiribirdYellow, 5f);
            spiribirds.Add(PawnKindDefOf.Mashed_Spiribird_SpiribirdPrism, 1f);
        }

        public static PawnKindDef RandomKind()
        {
            return spiribirds.RandomElementByWeight(x=>x.Value).Key;
        }
    }

    public class Plant_Spiribush : Plant
    {
        public override void PlantCollected(Pawn by)
        {
            if (this.HarvestableNow)
            {
                float chance = this.sown ? chanceSown : chanceWild;
                if (Rand.Chance(chance))
                {
                    Pawn newP = PawnGenerator.GeneratePawn(SpiribirdList.RandomKind(), null);
                    GenSpawn.Spawn(newP, this.Position, this.Map);
                }
            }

            base.PlantCollected(by);
        }

        public static float chanceWild = 0.15f;
        public static float chanceSown = 0.05f;
    }
}
