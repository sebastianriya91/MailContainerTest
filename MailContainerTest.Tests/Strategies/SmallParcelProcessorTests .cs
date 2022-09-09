using MailContainerTest;
using MailContainerTest.Data;
using MailContainerTest.Strategy;
using MailContainerTest.Types;

namespace MailContainerTest.Tests.Strategies
{
    public class SmallParcelProcessorTests
    {
        private SmallParcelMailProcessor subject;

        [SetUp]
        public void Setup()
        {
            subject = new SmallParcelMailProcessor();
        }

        [Test]
        public void GivenContainerNull_WhenIsSuccessull_ThenMustReturnFalse()
        {
            // Given
            MailContainerTest.Types.MailContainer mailContainer = null;

            // When
            var result = subject.IsSuccessfull(mailContainer,4);

            // Then
            Assert.That(result, Is.False);
        }

        [Test]
        public void GivenNotSmallParcelMail_WhenIsSuccessull_ThenMustReturnFalse()
        {
            // Given
            MailContainerTest.Types.MailContainer mailContainer = new MailContainerTest.Types.MailContainer();
            mailContainer.AllowedMailType = AllowedMailType.StandardLetter;

            // When
            var result = subject.IsSuccessfull(mailContainer, 4);

            // Then
            Assert.That(result, Is.False);
        }

        [Test]
        public void GivenMailContainerStatusNotOperational_WhenIsSuccessull_ThenMustReturnFalse()
        {
            // Given
            MailContainerTest.Types.MailContainer mailContainer = new MailContainerTest.Types.MailContainer();
            mailContainer.AllowedMailType = AllowedMailType.SmallParcel;
            mailContainer.Status = MailContainerStatus.OutOfService;

            // When
            var result = subject.IsSuccessfull(mailContainer, 4);

            // Then
            Assert.That(result, Is.False);
        }

        [Test]
        public void GivenSmallParcelMail_WhenIsSuccessull_ThenMustReturnTrue()
        {
            // Given
            MailContainerTest.Types.MailContainer mailContainer = new MailContainerTest.Types.MailContainer();
            mailContainer.AllowedMailType = AllowedMailType.SmallParcel;
            mailContainer.Status = MailContainerStatus.Operational;

            // When
            var result = subject.IsSuccessfull(mailContainer, 0);

            // Then
            Assert.That(result, Is.True);
        }

        [Test]
        public void GivenMailContainerCapacityEqualToNumberOfMailItems_WhenIsSuccessull_ThenMustReturnTrue()
        {
            // Given
            MailContainerTest.Types.MailContainer mailContainer = new MailContainerTest.Types.MailContainer();
            mailContainer.AllowedMailType = AllowedMailType.SmallParcel;
            mailContainer.Capacity = 2;

            // When
            var result = subject.IsSuccessfull(mailContainer, 2);

            // Then
            Assert.That(result, Is.True);
        }

        [Test]
        public void GivenMailContainerCapacityGreaterThanNumberOfMailItems_WhenIsSuccessull_ThenMustReturnTrue()
        {
            // Given
            MailContainerTest.Types.MailContainer mailContainer = new MailContainerTest.Types.MailContainer();
            mailContainer.AllowedMailType = AllowedMailType.SmallParcel;
            mailContainer.Capacity = 4;

            // When
            var result = subject.IsSuccessfull(mailContainer, 2);

            // Then
            Assert.That(result, Is.True);
        }

    }
}