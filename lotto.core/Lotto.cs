using System.Collections.Generic;

namespace lotto.core
{
    public static class Lotto
    {
        public static IEnumerable<Draw> GetDraws()
        {
            var htmlWeb = new HtmlWeb();
            var loader = new DieLottozahlenNetDrawLoader(htmlWeb);

            var draws = loader.LoadDraws();

            return draws;
        }
    }
}
