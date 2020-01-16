using HtmlAgilityPack;

namespace lotto.core
{
    /// <summary>
    /// Interface for making <see cref="HtmlAgilityPack.HtmlWeb"/> testable.
    /// </summary>
    public interface IHtmlWeb
    {
        HtmlDocument Load(string url);
    }
}
