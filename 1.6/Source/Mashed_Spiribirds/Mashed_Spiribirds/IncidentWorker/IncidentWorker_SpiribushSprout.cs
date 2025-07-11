﻿using System;
using System.Collections.Generic;
using Verse;
using RimWorld;

namespace Mashed_Spiribirds
{
	public class IncidentWorker_SpiribushSprout : IncidentWorker
    {
		protected override bool CanFireNowSub(IncidentParms parms)
		{
			if (!base.CanFireNowSub(parms))
			{
				return false;
			}
			Map map = (Map)parms.target;
            if (!PlantUtility.GrowthSeasonNow(map, ThingDefOf.Mashed_Spiribird_Spiribush))
            {
                return false;
            }
            return TryFindRootCell(map, out _);
        }

		protected override bool TryExecuteWorker(IncidentParms parms)
		{
			Map map = (Map)parms.target;
            if (!TryFindRootCell(map, out IntVec3 intVec))
            {
                return false;
            }
            Thing thing = null;
			int randomInRange = CountRange.RandomInRange;
			for (int i = 0; i < randomInRange; i++)
			{
				IntVec3 root = intVec;
				Map map2 = map;
				int radius = SpawnRadius;
                if (!CellFinder.TryRandomClosewalkCellNear(root, map2, radius, out IntVec3 intVec2, (IntVec3 x) => CanSpawnAt(x, map)))
                {
                    break;
                }
                Plant plant = intVec2.GetPlant(map);
				plant?.Destroy(DestroyMode.Vanish);
				Thing thing2 = GenSpawn.Spawn(ThingDefOf.Mashed_Spiribird_Spiribush, intVec2, map, WipeMode.Vanish);
				if (thing == null)
				{
					thing = thing2;
				}
			}
			if (thing == null)
			{
				return false;
			}
			SendStandardLetter(parms, thing, Array.Empty<NamedArgument>());
			return true;
		}

		private bool TryFindRootCell(Map map, out IntVec3 cell)
		{
			return CellFinderLoose.TryFindRandomNotEdgeCellWith(10, (IntVec3 x) => this.CanSpawnAt(x, map) && x.GetRoom(map).CellCount >= MinRoomCells, map, out cell);
		}

		private bool CanSpawnAt(IntVec3 c, Map map)
		{
			if (!c.Standable(map) || c.Fogged(map) || map.fertilityGrid.FertilityAt(c) < ThingDefOf.Mashed_Spiribird_Spiribush.plant.fertilityMin || !c.GetRoom(map).PsychologicallyOutdoors || c.GetEdifice(map) != null || !PlantUtility.GrowthSeasonNow(map, ThingDefOf.Mashed_Spiribird_Spiribush))
			{
				return false;
			}
			Plant plant = c.GetPlant(map);
			if (plant != null && plant.def.plant.growDays > 10f)
			{
				return false;
			}
			List<Thing> thingList = c.GetThingList(map);
			for (int i = 0; i < thingList.Count; i++)
			{
				if (thingList[i].def == ThingDefOf.Mashed_Spiribird_Spiribush)
				{
					return false;
				}
			}
			return true;
		}

		private static readonly IntRange CountRange = new IntRange(10, 20);
		private const int MinRoomCells = 64;
		private const int SpawnRadius = 6;
	}
}
