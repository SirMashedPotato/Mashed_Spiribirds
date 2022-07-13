using Verse;

namespace Mashed_Spiribirds
{
    class SpiribirdProperties : DefModExtension
    {
        public HediffDef pollenHediff;
        public bool isPrismatic = false;

        public static SpiribirdProperties Get(Def def)
        {
            return def.GetModExtension<SpiribirdProperties>();
        }
    }
}
