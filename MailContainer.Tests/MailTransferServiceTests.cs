using MailContainerTest;
using MailContainerTest.Data;
using MailContainerTest.Services;
using MailContainerTest.Types;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailContainer.Tests
{
    public class MailTransferServiceTests
    {
        private MailTransferService subject;
        private MakeMailTransferRequest request;
        // To-Do convert to use MOQ
        private IMailStoreFactory _mailStoreFactory;

        [SetUp]
        public void Setup()
        {
            // Use MOQ set up
            _mailStoreFactory = new MailStoreFactory();
            subject = new MailTransferService(_mailStoreFactory);
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
