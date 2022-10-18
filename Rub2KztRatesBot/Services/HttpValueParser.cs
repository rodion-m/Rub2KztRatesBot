using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.XPath;

namespace Rub2KztRatesBot.Services;

public class HttpValueParser
{
    public async Task<string?> Parse(string uri, string selector)
    {
        var config = Configuration.Default
            .WithDefaultLoader()
            .WithXPath();
        var context = BrowsingContext.New(config);
        var document = await context.OpenAsync(uri);
        //var element = document.QuerySelector(selector);
        var element = document.Body!.SelectSingleNode(selector);
        return element?.TextContent;
    }
}