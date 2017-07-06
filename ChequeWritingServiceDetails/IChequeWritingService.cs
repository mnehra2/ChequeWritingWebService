using System.ServiceModel;

namespace ChequeWritingServiceDetails
{
    [ServiceContract]
    public interface IChequeWritingService
    {
        [OperationContract]
        string GetAmountInWords(decimal amount);
    }
}
