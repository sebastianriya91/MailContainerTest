using MailContainerTest;
using MailContainerTest.Data;
using MailContainerTest.Strategy;
using MailContainerTest.Types;

namespace MailContainer.Tests.Strategies
{
    public class LargeLetterMailProcessorTests
    {
        private LargeLetterMailProcessor subject;

        [SetUp]
        public void Setup()
        {
            subject = new LargeLetterMailProcessor();
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
        public void GivenLargeLetterMail_WhenIsSuccessull_ThenMustReturnTrue()
        {
            // Given
            MailContainerTest.Types.MailContainer mailContainer = new MailContainerTest.Types.MailContainer();
            mailContainer.AllowedMailType = AllowedMailType.LargeLetter;

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
            mailContainer.AllowedMailType = AllowedMailType.LargeLetter;
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
            mailContainer.AllowedMailType = AllowedMailType.LargeLetter;
            mailContainer.Capacity = 4;

            // When
            var result = subject.IsSuccessfull(mailContainer, 2);

            // Then
            Assert.That(result, Is.True);
        }

    }
}