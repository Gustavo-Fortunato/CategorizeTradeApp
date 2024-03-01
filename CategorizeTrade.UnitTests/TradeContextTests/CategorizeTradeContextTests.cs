using CategorizeTrade.Client;
using CategorizeTrade.Interface;
using CategorizeTrade.Model;
using CategorizeTrade.Strategy;
using NUnit.Framework.Legacy;
using System.Diagnostics;

namespace CategorizeTrade.UnitTests.TradeContextTests
{
    [TestFixture]
    public class CategorizeTradeContextTests
    {
        [Test]
        public void CategorizeTrade_ShouldReturnCorrectCategory()
        {
            // Arrange
            LowRiskStrategy lowRiskStrategy = new LowRiskStrategy();
            MediumRiskStrategy mediumRiskStrategy = new MediumRiskStrategy();
            HighRiskStrategy highRiskStrategy = new HighRiskStrategy();

            CategorizeTradeContext lowRiskCategorizer = new CategorizeTradeContext(lowRiskStrategy);
            CategorizeTradeContext mediumRiskCategorizer = new CategorizeTradeContext(mediumRiskStrategy);
            CategorizeTradeContext highRiskCategorizer = new CategorizeTradeContext(highRiskStrategy);

            ITrade publicLowValueTrade = new Trade { Value = 500000, ClientSector = "Public" };
            ITrade publicHighValueTrade = new Trade { Value = 1500000, ClientSector = "Public" };
            ITrade privateHighValueTrade = new Trade { Value = 1500000, ClientSector = "Private" };

            // Act
            string lowRiskCategory = lowRiskCategorizer.GetCategory(publicLowValueTrade);
            string mediumRiskCategory = mediumRiskCategorizer.GetCategory(publicHighValueTrade);
            string highRiskCategory = highRiskCategorizer.GetCategory(privateHighValueTrade);

            // Assert
            StringAssert.AreEqualIgnoringCase("LOWRISK", lowRiskCategory);
            StringAssert.AreEqualIgnoringCase("MEDIUMRISK", mediumRiskCategory);
            StringAssert.AreEqualIgnoringCase("HIGHRISK", highRiskCategory);
        }

        [Test]
        public void CategorizeTrades_WithLowRisk_ReturnsCorrectCategories()
        {
            // Arrange
            List<ITrade> portfolio = new List<ITrade>
        {
            new Trade { Value = 500000, ClientSector = "Public" },
            new Trade { Value = 800000, ClientSector = "Public" },
            new Trade { Value = 900000, ClientSector = "Public" }
        };

            CategorizeTradeContext lowRiskContext = new CategorizeTradeContext(new LowRiskStrategy());

            List<string> tradeCategories = new List<string>();

            // Act
            foreach (var trade in portfolio)
            {
                string category = lowRiskContext.GetCategory(trade);
                tradeCategories.Add(category);
            }

            //Assert
            CollectionAssert.AreEqual(new[] { "LOWRISK", "LOWRISK", "LOWRISK" }, tradeCategories);
        }

        [Test]
        public void CategorizeTrades_WithMediumRisk_ReturnsCorrectCategories()
        {
            // Arrange
            List<ITrade> portfolio = new List<ITrade>
        {
            new Trade { Value = 1200000, ClientSector = "Public" },
            new Trade { Value = 1500000, ClientSector = "Public" },
            new Trade { Value = 2000000, ClientSector = "Public" }
        };

            CategorizeTradeContext mediumRiskContext = new CategorizeTradeContext(new MediumRiskStrategy());

            List<string> tradeCategories = new List<string>();

            // Act
            foreach (var trade in portfolio)
            {
                string category = mediumRiskContext.GetCategory(trade);
                tradeCategories.Add(category);
            }

            //Assert
            CollectionAssert.AreEqual(new[] { "MEDIUMRISK", "MEDIUMRISK", "MEDIUMRISK" }, tradeCategories);
        }

        [Test]
        public void CategorizeTrades_WithHighRisk_ReturnsCorrectCategories()
        {
            // Arrange
            List<ITrade> portfolio = new List<ITrade>
        {
            new Trade { Value = 1500000, ClientSector = "Private" },
            new Trade { Value = 2000000, ClientSector = "Private" },
            new Trade { Value = 3000000, ClientSector = "Private" }
        };

            CategorizeTradeContext highRiskContext = new CategorizeTradeContext(new HighRiskStrategy());

            List<string> tradeCategories = new List<string>();

            // Act
            foreach (var trade in portfolio)
            {
                string category = highRiskContext.GetCategory(trade);
                tradeCategories.Add(category);
            }

            //Assert
            CollectionAssert.AreEqual(new[] { "HIGHRISK", "HIGHRISK", "HIGHRISK" }, tradeCategories);
        }

        [Test]
        public void CategorizeTrades_WithUndefinedRisk_ReturnsCorrectCategories()
        {
            // Arrange
            List<ITrade> portfolio = new List<ITrade>
        {
            new Trade { Value = 800000, ClientSector = "Unknown" },
            new Trade { Value = 1200000, ClientSector = "Public" },
            new Trade { Value = 900000, ClientSector = "Private" }
        };

            CategorizeTradeContext highRiskContext = new CategorizeTradeContext(new HighRiskStrategy());

            List<string> tradeCategories = new List<string>();
            List<string> emptyTradeCategories = new List<string>();

            //Act
            foreach (var trade in portfolio)
            {
                string category = highRiskContext.GetCategory(trade);
                tradeCategories.Add(category);
                emptyTradeCategories.Add(null);
            }

            //Assert
            CollectionAssert.AreEqual(emptyTradeCategories, tradeCategories);
        }
    }
}