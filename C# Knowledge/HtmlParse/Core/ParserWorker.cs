using AngleSharp.Html.Parser;
using System;

namespace TestParse.Core
{
    class ParserWorker<T> where T : class
    {
        IParser<T> parser;
        IParserSettings parserSettings;
        HtmlLoader loader;
        bool isActive;

        public event Action<object, T> OnNewData;
        public event Action<object> OnCompleted;

        public IParser<T> Parser
        {
            get => parser;
            set { parser = value; }
        }

        public IParserSettings Settings
        {
            get => parserSettings;
            set 
            { 
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }

        public bool IsActive
        {
            get => isActive;
        }

        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser; 
        }

        public ParserWorker(IParser<T> parser, IParserSettings settings) : this(parser)
        {
            this.parserSettings = settings;
        }

        public void Start()
        {
            isActive = true;
            Worker();
        }

        public void Abort()
        {
            isActive = false;
        }

        private async void Worker()
        {
            if (!isActive)
            {
                OnCompleted?.Invoke(this);
                return;
            }

            var source = await loader.GetSourcePage();
            var domParser = new HtmlParser();

            var document = await domParser.ParseDocumentAsync(source);
            var parseResult = parser.Parse(document);
            OnNewData?.Invoke(this, parseResult);

            OnCompleted?.Invoke(this);
            isActive = false;
        }
    }
}
