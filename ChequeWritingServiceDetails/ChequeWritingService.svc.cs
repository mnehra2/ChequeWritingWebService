using ChequeWritingUtilities;
using System;

namespace ChequeWritingServiceDetails
{
    public class ChequeWritingService : IChequeWritingService
    {
        public string GetAmountInWords(decimal amount)
        {
            try
            {
                // we can use structure map or any other Ioc way to inject the object
                ConvertAmountInWords convertAmountInWords = new ConvertAmountInWords();
                return convertAmountInWords.GetWordsFromAmount(amount);
            }
            catch (Exception ex)
            {
                //log the error using log4net
                return string.Empty;
            }
        }
    }
}
