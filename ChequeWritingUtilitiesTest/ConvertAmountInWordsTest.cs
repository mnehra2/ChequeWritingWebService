using ChequeWritingUtilities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChequeWritingUtilitiesTest
{
    [TestClass]
    public class ConvertAmountInWordsTest
    {
        [TestMethod]
        public void GetWordsFromAmount_ReturnsStringInWords()
        {
            // Arrange         
            decimal amount = 142.20M;

            //Act
            var model = new ConvertAmountInWords();
            var stringInWords = model.GetWordsFromAmount(amount);

            // Assert
            stringInWords.Should().Be("ONE HUNDRED  FORTY-FOUR DOLLARS AND TWENTY CENTS");
           
        }

    }
}
