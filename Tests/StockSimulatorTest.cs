using System;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NSubstitute;
using NMock;
using Rhino.Mocks;
using MockFactory = NMock.MockFactory;

namespace Tests
{
    [TestClass]
    public class StockSimulatorTest
    {
        private Stock stock;

        [TestInitialize]
        public void InitializeBetweenTest()
        {
            this.stock = new Stock { Symbol = "MSFT" };
        }

        [TestMethod]
        public void WhenStockPriceAtZero_ExpectNotBuy()
        {
            //Arrange
            #region moq
            //var mock = new Mock<IStockPriceManager>();
            //mock.Setup(foo => foo.GetCurrentPrice(stock)).Returns(0);
            //var stockSimulator = new StockSimulator(mock.Object);
            #endregion
            #region NSubstitute
            //var mock = Substitute.For<IStockPriceManager>();
            //mock.GetCurrentPrice(stock).Returns(0);
            //var stockSimulator = new StockSimulator(mock);
            #endregion
            #region nMock3
            //var mockFactory = new MockFactory();
            //var mock = mockFactory.CreateMock<IStockPriceManager>();
            //mock.Expects.One.Method(d => d.GetCurrentPrice(stock)).With(stock).WillReturn(0);
            //var stockSimulator = new StockSimulator(mock.MockObject);
            #endregion
            #region RhinoMock
            var mock = Rhino.Mocks.MockRepository.GenerateMock<IStockPriceManager>();
            mock.Expect(d => d.GetCurrentPrice(stock)).Return(0);
            var stockSimulator = new StockSimulator(mock);
            #endregion
            //Act
            var answer = stockSimulator.IsStockGood(stock);

            //Assert
            Assert.IsFalse(answer);
        }

        [TestMethod]
        public void WhenStockPriceOverZero_ExpectBuy()
        {
            //Arrange
            #region moq
            //var mock = new Mock<IStockPriceManager>();
            //mock.Setup(foo => foo.GetCurrentPrice(stock)).Returns(1);
            //var stockSimulator = new StockSimulator(mock.Object);
            #endregion
            #region NSubstitute
            //var mock = Substitute.For<IStockPriceManager>();
            //mock.GetCurrentPrice(stock).Returns(1);
            //var stockSimulator = new StockSimulator(mock);
            #endregion
            #region nMock3
            //var mockFactory = new MockFactory();
            //var mock = mockFactory.CreateMock<IStockPriceManager>();
            //mock.Expects.One.Method(d => d.GetCurrentPrice(stock)).With(stock).WillReturn(1);
            //var stockSimulator = new StockSimulator(mock.MockObject);
            #endregion
            #region RhinoMock
            var mock = Rhino.Mocks.MockRepository.GenerateMock<IStockPriceManager>();
            mock.Expect(d => d.GetCurrentPrice(stock)).Return(1);
            var stockSimulator = new StockSimulator(mock);
            #endregion
            //Act
            var answer = stockSimulator.IsStockGood(stock);

            //Assert
            Assert.IsTrue(answer);
        }


        [TestMethod]
        public void WhenStockPriceUnderZero_ExpectBuy()
        {
            //Arrange
            #region moq
            //var mock = new Mock<IStockPriceManager>();
            //mock.Setup(foo => foo.GetCurrentPrice(stock)).Returns(-1);
            //var stockSimulator = new StockSimulator(mock.Object);
            #endregion
            #region NSubstitute
            //var mock = Substitute.For<IStockPriceManager>();
            //mock.GetCurrentPrice(stock).Returns(-1);
            //var stockSimulator = new StockSimulator(mock);
            #endregion
            #region nMock3
            //var mockFactory = new MockFactory();
            //var mock = mockFactory.CreateMock<IStockPriceManager>();
            //mock.Expects.One.Method(d => d.GetCurrentPrice(stock)).With(stock).WillReturn(-1);
            //var stockSimulator = new StockSimulator(mock.MockObject);
            #endregion
            #region RhinoMock
            var mock = Rhino.Mocks.MockRepository.GenerateMock<IStockPriceManager>();
            mock.Expect(d => d.GetCurrentPrice(stock)).Return(-1);
            var stockSimulator = new StockSimulator(mock);
            #endregion
            //Act
            var answer = stockSimulator.IsStockGood(stock);

            //Assert
            Assert.IsFalse(answer);
        }


        [TestMethod]
        public void WhenStockNotFound_ExpectException()
        {
            //Arrange
            #region moq
            //var mock = new Mock<IStockPriceManager>();
            //mock.Setup(foo => foo.GetCurrentPrice(stock)).Throws<ExceptionStockNotFound>();
            //var stockSimulator = new StockSimulator(mock.Object);
            #endregion
            #region NSubstitute
            //var mock = Substitute.For<IStockPriceManager>();
            //mock.GetCurrentPrice(stock).Returns(x => { throw new ExceptionStockNotFound(); });
            //var stockSimulator = new StockSimulator(mock);
            #endregion
            #region nMock3
            //var mockFactory = new MockFactory();
            //var mock = mockFactory.CreateMock<IStockPriceManager>();
            //mock.Expects.One.Method(d => d.GetCurrentPrice(stock)).With(stock).Will(Throw.Exception(new ExceptionStockNotFound()));
            //var stockSimulator = new StockSimulator(mock.MockObject);
            #endregion
            #region RhinoMock
            var mock = Rhino.Mocks.MockRepository.GenerateMock<IStockPriceManager>();
            mock.Expect(d => d.GetCurrentPrice(stock)).Throw(new ExceptionStockNotFound());
            var stockSimulator = new StockSimulator(mock);
            #endregion
            //Act & Assert
            try
            {
                stockSimulator.IsStockGood(stock);
                Assert.Fail("Should never go here");
            }
            catch (ExceptionStockNotFound e)
            {
                //This is what we want
            }
           
        }
    }
}
