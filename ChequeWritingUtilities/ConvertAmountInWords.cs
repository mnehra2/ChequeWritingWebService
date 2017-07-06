using System;

namespace ChequeWritingUtilities
{
    public class ConvertAmountInWords : IConvertAmountInWords
    {
        public string GetWordsFromAmount(decimal amount)
        {
            var valueBeforeDecimalPoint = (long)Math.Floor(amount);

            var valueBeforeDecimalWord = $"{ConvertNumberToWords(valueBeforeDecimalPoint)} DOLLARS";

            //var valueAfterFloatingPointWord =
            //    $"{ConvertCentToWord((long)((amount - valueBeforeDecimalPoint) * 100), "")} CENTS";

            var valueAfterFloatingPointWord =
              ConvertCentToWord((long)((amount - valueBeforeDecimalPoint) * 100), "");

            string cents = !string.IsNullOrWhiteSpace(valueAfterFloatingPointWord) ? "CENTS" : "ZERO CENTS";
            valueAfterFloatingPointWord = $"{ valueAfterFloatingPointWord} {cents}";

            return $"{valueBeforeDecimalWord} AND {valueAfterFloatingPointWord}";
        }

        private string ConvertNumberToWords(long numberBeforeDecimalPoint)
        {
            if (numberBeforeDecimalPoint == 0)
                return "ZERO";

            if (numberBeforeDecimalPoint < 0)
                return "MINUS " + ConvertNumberToWords(Math.Abs(numberBeforeDecimalPoint));

            var words = "";

            if (numberBeforeDecimalPoint / 1000000000 > 0)
            {
                words += ConvertNumberToWords(numberBeforeDecimalPoint / 1000000000) + " BILLION ";
                numberBeforeDecimalPoint %= 1000000000;
            }

            if (numberBeforeDecimalPoint / 1000000 > 0)
            {
                words += ConvertNumberToWords(numberBeforeDecimalPoint / 1000000) + " MILLION ";
                numberBeforeDecimalPoint %= 1000000;
            }

            if (numberBeforeDecimalPoint / 1000 > 0)
            {
                words += ConvertNumberToWords(numberBeforeDecimalPoint / 1000) + " THOUSAND ";
                numberBeforeDecimalPoint %= 1000;
            }

            if (numberBeforeDecimalPoint / 100 > 0)
            {
                words += ConvertNumberToWords(numberBeforeDecimalPoint / 100) + " HUNDRED ";
                numberBeforeDecimalPoint %= 100;
            }

            words = ConvertCentToWord(numberBeforeDecimalPoint, words);

            return words;
        }

        private string ConvertCentToWord(long number, string words)
        {
            if (number <= 0) return words;
            if (!string.IsNullOrWhiteSpace(words))
            {
                words += " ";
            }

            var unitsMappingArray = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
            var tensMappingArray = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

            if (number < 20)
                words += unitsMappingArray[number];
            else
            {
                words += tensMappingArray[number / 10];
                if ((number % 10) > 0)
                    words += "-" + unitsMappingArray[number % 10];
            }
            return words;
        }
    }
}
