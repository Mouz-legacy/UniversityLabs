using AngleSharp.Html.Dom;
using System.Collections.Generic;
using System.Linq;

namespace TestParse.Core.DevBy
{
    class DevbyParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null);//&& item.ClassName.Contains("card__title card__title_text-crop")

            foreach (var item in items)
            {
                list.Add(item.TextContent);
            }

            return list.ToArray();
        }
    }
}
