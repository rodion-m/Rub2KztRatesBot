using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html;
using AngleSharp.XPath;

namespace Rub2KztRatesBot.Services;

public class HttpValueParser
{
    private readonly ILogger<HttpValueParser> _logger;

    public HttpValueParser(ILogger<HttpValueParser> logger)
    {
        _logger = logger;
    }
    
    public async Task<ParseResult> ParseString(string uri, string selector)
    {
        var config = Configuration.Default
            .WithDefaultLoader()
            .WithXPath();
        var context = BrowsingContext.New(config);
        var document = await context.OpenAsync(uri);
        //var element = document.QuerySelector(selector);
        var element = document.Body!.SelectSingleNode(selector);
        if (element is null)
        {
            _logger.LogError("Node not found. Selector: {Selector}, HTML: {HTML}", 
                selector, document.ToHtml(new HtmlMarkupFormatter()));
        }
        return new ParseResult(element?.TextContent, element, document);
    }
}

public record ParseResult(string? TextContent, INode? Node, IDocument Document)
{
    public string DocHtml => Document.ToHtml(new HtmlMarkupFormatter());

    public void ThrowIfFailed()
    {
        if (Node is null)
        {
            throw new NodeNotFoundException("");
        }
    }
}

public class NodeNotFoundException : Exception
{
    public NodeNotFoundException(string message) : base(message)
    {
    }
}