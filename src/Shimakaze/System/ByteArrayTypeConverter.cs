using System.ComponentModel;
using System.Globalization;

namespace Shimakaze.System;

public sealed class ByteArrayTypeConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType) => sourceType == typeof(string);

    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value) => Convert.FromBase64String((string)value);
}