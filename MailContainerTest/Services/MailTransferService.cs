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

        /// <summary>
        /// 1. Decides the container store based on store type [Main,Backup]
        /// 2. Based on store, mail container is created
        /// 3. Using strategy, Mail Processor object is retreived (based on Mail type) and IsSuccessful method is called on the processor object.
        /// 4. Is successful, capacity of the given container is reduced
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
