using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HtmlAgilityPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lotto.core;
using Moq;

namespace lotto.test
{
    [TestClass]
    public class DieLottozahlenNetDrawLoaderTests
    {
        [TestMethod]
        public void TestExtractionFromHtml()
        {
            var html = File.ReadAllText("Sample.html");
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var htmlWeb = new Mock<IHtmlWeb>();
            htmlWeb.Setup(h => h.Load(@"https://www.dielottozahlende.net")).Returns(htmlDoc);

            var loader = new DieLottozahlenNetDrawLoader(htmlWeb.Object);

            var draws = loader.LoadDraws().ToList();

            Assert.AreEqual("LOTTO 6 AUS 49", draws[0].Name);
            Assert.AreEqual(new DateTime(2020, 1, 15), draws[0].CurrentDate);
            CollectionAssert.AreEqual(new List<int> {2, 24, 8, 46, 31, 43}, draws[0].Numbers.ToList());
            CollectionAssert.AreEqual(new List<int> { 4 }, draws[0].SpecialNumbers.ToList());
            Assert.AreEqual(new DateTime(2020, 1, 18, 19, 25, 0), draws[0].NextDate);

            Assert.AreEqual("EURO MILLIONS", draws[1].Name);
            Assert.AreEqual(new DateTime(2020, 1, 14), draws[1].CurrentDate);
            CollectionAssert.AreEqual(new List<int> { 21, 25, 29, 39, 44}, draws[1].Numbers.ToList());
            CollectionAssert.AreEqual(new List<int> { 8,9 }, draws[1].SpecialNumbers.ToList());
            Assert.AreEqual(new DateTime(2020, 1, 17, 22, 30, 0), draws[1].NextDate);

            Assert.AreEqual("EUROJACKPOT", draws[2].Name);
            Assert.AreEqual(new DateTime(2020, 1, 10), draws[2].CurrentDate);
            CollectionAssert.AreEqual(new List<int> { 4, 14, 25, 34, 49 }, draws[2].Numbers.ToList());
            CollectionAssert.AreEqual(new List<int> { 4, 9 }, draws[2].SpecialNumbers.ToList());
            Assert.AreEqual(new DateTime(2020, 1, 17, 19, 0, 0), draws[2].NextDate);

            Assert.AreEqual("CASH 4 LIFE", draws[3].Name);
            Assert.AreEqual(new DateTime(2020, 1, 14), draws[3].CurrentDate);
            CollectionAssert.AreEqual(new List<int> { 7, 8, 16, 20, 35 }, draws[3].Numbers.ToList());
            CollectionAssert.AreEqual(new List<int> { 2 }, draws[3].SpecialNumbers.ToList());
            Assert.AreEqual(new DateTime(2020, 1, 15, 4, 0, 0), draws[3].NextDate);

            Assert.AreEqual("POWERBALL", draws[4].Name);
            Assert.AreEqual(new DateTime(2020, 1, 16), draws[4].CurrentDate);
            CollectionAssert.AreEqual(new List<int> { 39, 41, 53, 55, 68 }, draws[4].Numbers.ToList());
            CollectionAssert.AreEqual(new List<int> { 19 }, draws[4].SpecialNumbers.ToList());
            Assert.AreEqual(new DateTime(2020, 1, 19, 6, 0, 0), draws[4].NextDate);

            Assert.AreEqual("MEGA MILLIONS", draws[5].Name);
            Assert.AreEqual(new DateTime(2020, 1, 15), draws[5].CurrentDate);
            CollectionAssert.AreEqual(new List<int> { 9, 11, 13, 31, 47 }, draws[5].Numbers.ToList());
            CollectionAssert.AreEqual(new List<int> { 11 }, draws[5].SpecialNumbers.ToList());
            Assert.AreEqual(new DateTime(2020, 1, 18, 6, 0, 0), draws[5].NextDate);
        }
    }
}
