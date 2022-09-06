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

        // All dpendencis Injected Via constructor
        public MailTransferService(IMailStoreFactory mailStoreFactory, IMailProcessorStrategy mailProcessorStrategy)
        {
            _mailStoreFactory = mailStoreFactory;
            _mailProcessorStrategy = mailProcessorStrategy;
        }
        public MakeMailTransferResult MakeMailTransfer(MakeMailTransferRequest request)
        {
            // Store type converted to enum
            StoreType dataStoreType = Enum.Parse<StoreType>(ConfigurationManager.AppSettings["DataStoreType"]);

            // MailContainer store to be received from Factory
            var mailContainerStore = _mailStoreFactory.CreateMailDataStore(dataStoreType);
            var container = mailContainerStore.GetMailContainer(request.SourceMailContainerNumber);
            var result = new MakeMailTransferResult
            {
                // Strategy pattern where you get the processor & calls the respetive method based on processor
                Success = _mailProcessorStrategy.GetMailProcessor(request.MailType).IsSuccessfull(container, request.NumberOfMailItems)
            };

            if (result.Success)
            {
                container.Capacity -= request.NumberOfMailItems;

                // To-Do :Logic to be written
                mailContainerStore.UpdateMailContainer(container);
            }

            return result;
        }
    }
}
