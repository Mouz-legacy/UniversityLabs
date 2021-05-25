using AngleSharp.Html.Dom;

namespace TestParse.Core
{
    interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
