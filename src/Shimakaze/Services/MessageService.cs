using Konata.Core;
using Konata.Core.Message;
using Konata.Core.Message.Model;

using Shimakaze.System;

namespace Shimakaze.Services;

[Service]
public sealed class MessageService
{
    private readonly Bot _bot;

    public MessageService(Bot bot)
    {
        _bot = bot;
    }

    public ConditionBuilder Condition(MessageChain chain) => new(_bot, chain);

    public sealed class ConditionBuilder
    {
        private readonly Bot _bot;
        private readonly MessageChain _chain;
        private readonly List<Func<bool>> _chains = new();

        internal ConditionBuilder(Bot bot, MessageChain chain)
        {
            _bot = bot;
            _chain = chain;
        }

        public bool Invoke() => _chains.All(func => func());

        public ConditionBuilder AtMe()
        {
            _chains.Add(() => _chain.Get<AtChain>().Any(i => i.AtUin == _bot.Uin));
            return this;
        }

        public ConditionBuilder Contains(string match, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            _chains.Add(() => _chain.Get<TextChain>().Any(i => i.Content.Contains(match, comparison)));
            return this;
        }
    }


}