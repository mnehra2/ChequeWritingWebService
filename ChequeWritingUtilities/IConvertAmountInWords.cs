using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequeWritingUtilities
{
    public interface IConvertAmountInWords
    {
        string GetWordsFromAmount(decimal amount);
    }
}
