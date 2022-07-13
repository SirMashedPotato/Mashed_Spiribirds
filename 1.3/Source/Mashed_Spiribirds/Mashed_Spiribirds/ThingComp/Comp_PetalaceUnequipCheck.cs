using Verse;

namespace Mashed_Spiribirds
{
    class Comp_PetalaceUnequipCheck : ThingComp
    {
        public override void Notify_Unequipped(Pawn pawn)
        {
            base.Notify_Unequipped(pawn);
            var props = PetalaceProperties.Get(this.parent.def);
            if (props.pollenAffinity != null)
            {
                foreach(PollenAffinity pa in props.pollenAffinity)
                {
                    Hediff h = pawn.health.hediffSet.GetFirstHediffOfDef(pa.pollenHediff);
                    if(h != null)
                    {
                        pawn.health.RemoveHediff(h);
                    }
                }
            }
        }
    }
}
