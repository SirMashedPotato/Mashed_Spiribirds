using RimWorld;

namespace Mashed_Spiribirds
{
    [DefOf]
    public static class InteractionDefOf
    {
        static InteractionDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(InteractionDefOf));
        }

        public static InteractionDef Mashed_Spiribird_SpiribirdInteraction;
    }
}
