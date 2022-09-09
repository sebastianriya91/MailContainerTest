using MailContainerTest;
using MailContainerTest.Data;
using MailContainerTest.Strategy;
using MailContainerTest.Types;

namespace MailContainerTest.Tests.Strategies
{
    public class StandardLetterMailProcessorTests
    {
        private StandardLetterMailProcessor subject;

        [SetUp]
        public void Setup()
        {
            subject = new StandardLetterMailProcessor();
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
        public void GivenNotStandardLetterMail_WhenIsSuccessull_ThenMustReturnFalse()
        {
            // Given
            MailContainerTest.Types.MailContainer mailContainer = new MailContainerTest.Types.MailContainer();
            mailContainer.AllowedMailType = AllowedMailType.LargeLetter;

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
            mailContainer.AllowedMailType = AllowedMailType.StandardLetter;

            // When
            var result = subject.IsSuccessfull(mailContainer, 0);

            // Then
            Assert.That(result, Is.True);
        }




    }
}