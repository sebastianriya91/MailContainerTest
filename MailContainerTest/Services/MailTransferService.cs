using MailContainerTest.Data;
using MailContainerTest.Strategy;
using MailContainerTest.Types;
using System.Configuration;

namespace MailContainerTest.Services
{
    public class MailTransferService : IMailTransferService
    {
        private readonly IMailStoreFactory _mailStoreFactory;
        private readonly IMailProcessorStrategy _mailProcessorStrategy;
        public MailTransferService(IMailStoreFactory mailStoreFactory, IMailProcessorStrategy mailProcessorStrategy)
        {
            _mailStoreFactory = mailStoreFactory;
            _mailProcessorStrategy = mailProcessorStrategy;
        }
        public MakeMailTransferResult MakeMailTransfer(MakeMailTransferRequest request)
        {
            StoreType dataStoreType = Enum.Parse<StoreType>(ConfigurationManager.AppSettings["DataStoreType"]);

            var mailContainerStore = _mailStoreFactory.CreateMailDataStore(dataStoreType);
            var container = mailContainerStore.GetMailContainer(request.SourceMailContainerNumber);
            var result = new MakeMailTransferResult
            {
                Success = _mailProcessorStrategy.GetMailProcessor(request.MailType).IsSuccessfull(container, request.NumberOfMailItems)
            };

            if (result.Success)
            {
                container.Capacity -= request.NumberOfMailItems;
                mailContainerStore.UpdateMailContainer(container);
            }

            return result;
        }
    }
}
