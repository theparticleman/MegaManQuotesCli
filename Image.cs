using System.Reflection;
using Spectre.Console;

public static class Image
{
    static Random rand = new Random();

    public static CanvasImage GetRandom() => 
        new CanvasImage(Assembly.GetExecutingAssembly().GetManifestResourceStream(GetRandomImageName())!);

    private static string GetRandomImageName() =>
        "MegaManQuotesCli." + rand.Next(4) switch
        {
            0 => "mega man nes 1.png",
            1 => "mega man nes 2.png",
            2 => "mega man nes 3.png",
            3 => "mega man nes 4.png",
            _ => throw new NotSupportedException("Unsupported image index")
        };
}