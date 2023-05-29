using Konata.Core.Message;

namespace Shimakaze.System;

internal static class ChainExtensions
{
    public static IEnumerable<TChain> Get<TChain>(this MessageChain chain)
        where TChain : BaseChain
    {
        return chain.Where(i => i is TChain).Cast<TChain>();
    }
}
