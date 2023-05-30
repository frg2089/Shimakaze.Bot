namespace Shimakaze.Kernel.Messages.Spans;

public enum ImageType
{
    Invalid = 1,
    Face = 4,
    Jpg = 1000,
    Png = 1001,
    Webp = 1002,
    Pjpeg = 1003,
    Sharpp = 1004,
    Bmp = 1005,
    Gif = 2000,
    Apng = 2001
}

public abstract record ImageSpan : MessageSpan
{
    protected ImageSpan()
    {
        Mode = MessageSpanMode.Multiple;
    }

    /// <summary>
    /// Image Url
    /// </summary>
    public string Url { get; protected init; } = string.Empty;

    /// <summary>
    /// File name
    /// </summary>
    public string Name { get; protected init; } = string.Empty;

    /// <summary>
    /// MD5 byte[]
    /// </summary>
    public byte[] Hash { get; protected init; } = Array.Empty<byte>();

    /// <summary>
    /// Image data
    /// </summary>
    public byte[] Data { get; protected init; } = Array.Empty<byte>();

    /// <summary>
    /// Image data length
    /// </summary>
    public uint Length { get; protected init; }

    /// <summary>
    /// Image width
    /// </summary>
    public uint Width { get; protected init; }

    /// <summary>
    /// Image height
    /// </summary>
    public uint Height { get; protected init; }

    /// <summary>
    /// Image type
    /// </summary>
    public ImageType Type { get; protected init; }
}
