using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lotto.core
{
    public class DieLottozahlenNetDrawLoader
    {
        private readonly IHtmlWeb htmlWeb;
        private readonly string url = @"https://www.dielottozahlende.net";

        public DieLottozahlenNetDrawLoader(IHtmlWeb htmlWeb)
        {
            this.htmlWeb = htmlWeb;
        }

        public IEnumerable<Draw> LoadDraws()
        {
            var htmlDoc = htmlWeb.Load(url);

            yield return ExtractDraw(htmlDoc, "sixaus49");
            yield return ExtractDraw(htmlDoc, "euro-millions");
            yield return ExtractDraw(htmlDoc, "euro-jackpot");
            yield return ExtractDraw(htmlDoc, "cash-4-life");
            yield return ExtractDraw(htmlDoc, "power-ball");
            yield return ExtractDraw(htmlDoc, "mega-millions");
        }

        private Draw ExtractDraw(HtmlDocument htmlDoc, string htmlDrawName)
        {
            var xPathCard = $"//div[@class='card bg-{htmlDrawName} number-card']//*";

            var name = htmlDoc.DocumentNode
                .SelectSingleNode(
                    $"{xPathCard}//h5[contains(@class, 'card-title') and contains(@class, '{htmlDrawName}')]")
                .InnerText;

            var numbers = htmlDoc.DocumentNode
                .SelectNodes(
                    $"{xPathCard}//span[contains(@class, 'numbers') and contains(@class, '{htmlDrawName}') and not(contains(@class, 'highlight'))]")
                .Select(s => int.Parse(s.InnerText));

            var specialNumbers = htmlDoc.DocumentNode
                .SelectNodes($"{xPathCard}//span[contains(@class, 'numbers') and contains(@class, '{htmlDrawName}-highlight')]")
                .Select(s => int.Parse(s.InnerText));

            var dateStr = htmlDoc.DocumentNode
                .SelectSingleNode($"{xPathCard}//h6[contains(@class, 'card-subtitle') and contains(@class, '{htmlDrawName}')]")
                .InnerText
                .Replace("vom ", String.Empty);

            var date = DateTime.Parse(dateStr);

            var nextDateStr = htmlDoc.DocumentNode
                .SelectSingleNode($"{xPathCard}//strong")
                .InnerText
                .Remove(0, 4)
                .Replace(" Uhr", String.Empty);

            var nextDate = DateTime.Parse(nextDateStr);

            return new Draw(name, numbers, specialNumbers, date, nextDate);
        }
    }
}
