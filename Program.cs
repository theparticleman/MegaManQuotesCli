using System.Text.Json;
using Spectre.Console;

var image = Image.GetRandom();
var leftPadding = Math.Max(0, (Console.WindowWidth / 2) - ((image.Width / 2) * image.PixelWidth));
var paddedImage = new Padder(image, new Padding(leftPadding, 0, 0, 0));

var client = new HttpClient();
var quoteString = await client.GetStringAsync("https://api.megamanquotes.com/random-quote");
var quote = JsonSerializer.Deserialize<Quote>(quoteString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

var authorString = $"\t- {quote.Author}";
if (!string.IsNullOrEmpty(quote.Source)) authorString += $" ({quote.Source})";

var permalink = $"\t  {quote.Permalink}";

AnsiConsole.WriteLine();
AnsiConsole.Write(new FigletText("Mega Man Quotes").Centered());
AnsiConsole.WriteLine();

AnsiConsole.Write(paddedImage);

AnsiConsole.WriteLine();
AnsiConsole.WriteLine(quote.Text);
AnsiConsole.WriteLine();
AnsiConsole.WriteLine(authorString);
AnsiConsole.WriteLine();
AnsiConsole.WriteLine(permalink);
AnsiConsole.WriteLine();
AnsiConsole.WriteLine();
