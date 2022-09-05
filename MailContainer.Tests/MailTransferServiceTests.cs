using MailContainerTest;
using MailContainerTest.Services;
using MailContainerTest.Strategy;
using MailContainerTest.Types;
using System.Configuration;

namespace MailContainer.Tests
{
    public class MailTransferServiceTests
    {
        private MailTransferService subject;
        private MakeMailTransferRequest request;
        // To-Do convert to use MOQ
        private IMailStoreFactory _mailStoreFactory;
        private IMailProcessorStrategy _mailProcessorStrategy;

        [SetUp]
        public void Setup()
        {
            // Use MOQ set up
            _mailStoreFactory = new MailStoreFactory();
            _mailProcessorStrategy = new MailProcessorStrategy();
            subject = new MailTransferService(_mailStoreFactory, _mailProcessorStrategy);
            request = new MakeMailTransferRequest
            {
                SourceMailContainerNumber = "TW13",
                DestinationMailContainerNumber = "EC2",
                MailType = MailType.LargeLetter,
                NumberOfMailItems = 1,
                TransferDate = DateTime.Now.AddDays(-10)
            };
            ConfigurationManager.AppSettings["DataStoreType"] = "Backup";
        }

        [Test]
        public void GivenLargeLetter_WhenMakeMailTransfer_ThenMustReturnFailure()
        {
            // When
            var result = subject.MakeMailTransfer(request);

            // Then
            Assert.NotNull(result);
            Assert.That(result.GetType(), Is.EqualTo(typeof(MakeMailTransferResult)));
            Assert.That(result.Success, Is.EqualTo(false));
        }

    }
}
