using System.Text.RegularExpressions;

using Shimakaze.Kernel.Events;
using Shimakaze.Kernel.Messages.Spans;

namespace Shimakaze.Kernel;

public static class MessageSpanListExtensions
{
    public static bool Has(this IEnumerable<MessageSpan> message, string value) => message.Has(value, StringComparison.OrdinalIgnoreCase);
    public static bool Has(this IEnumerable<MessageSpan> message, string value, StringComparison comparisonType = StringComparison.OrdinalIgnoreCase) => message.Where(i => i is TextSpan).Cast<TextSpan>().Any(i => i.Content.Contains(value, comparisonType));
    public static bool Has(this IEnumerable<MessageSpan> message, string pattern, RegexOptions options = RegexOptions.None) => message.Where(i => i is TextSpan).Cast<TextSpan>().Any(i => Regex.IsMatch(i.Content, pattern, options));
    public static bool Has<TSpan>(this IEnumerable<MessageSpan> message) where TSpan : MessageSpan => message.Any(i => i is TSpan);
    public static bool Has<TSpan>(this IEnumerable<MessageSpan> message, Func<TSpan, bool> matcher) where TSpan : MessageSpan => message.Any(i => i is TSpan t && matcher(t));

    public static TSpan? Get<TSpan>(this IEnumerable<MessageSpan> message) where TSpan : MessageSpan => message.FirstOrDefault(i => i is TSpan) as TSpan;
    public static TSpan? Get<TSpan>(this IEnumerable<MessageSpan> message, Func<TSpan, bool> matcher) where TSpan : MessageSpan => message.FirstOrDefault(i => i is TSpan t && matcher(t)) as TSpan;
}
public static class MessageEventArgsExtensions
{
    public static IEnumerable<MessageSpan>? GetSpans(this IMessageEventArgs message) => message.Message?.Content;

    public static bool IsAtMe(this IMessageEventArgs message, IBot bot) => message.GetSpans()?.Has<AtSpan>(i => i.Id == bot.Id) ?? false;
}
