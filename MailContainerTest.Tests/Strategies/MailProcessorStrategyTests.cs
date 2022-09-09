using MailContainerTest;
using MailContainerTest.Data;
using MailContainerTest.Strategy;
using MailContainerTest.Types;

namespace MailContainerTest.Tests.Strategies
{
    public class MailProcessorStrategyTests
    {
        private IMailProcessorStrategy subject;

        [SetUp]
        public void Setup()
        {
            subject = new MailProcessorStrategy();
        }

        [Test]
        public void GivenStandardLetterRequested_WhenGetMailProcessor_ThenMustReturnStandardLetterProcessor()
        {
            // Given
            var mailType = MailType.StandardLetter;

            // When
            var result = subject.GetMailProcessor(mailType);

            // Then
            Assert.NotNull(result);
            Assert.That(result.GetType(), Is.EqualTo(typeof(StandardLetterMailProcessor)));
        }

        [Test]
        public void GivenLargeLetterRequested_WhenGetMailProcessor_ThenMustReturnSLargeLetterProcessor()
        {
            // Given
            var mailType = MailType.LargeLetter;

            // When
            var result = subject.GetMailProcessor(mailType);

            // Then
            Assert.NotNull(result);
            Assert.That(result.GetType(), Is.EqualTo(typeof(LargeLetterMailProcessor)));
        }

        [Test]
        public void GivenSmallParcelRequested_WhenGetMailProcessor_ThenMustReturnSmallParcelProcessor()
        {
            // Given
            var mailType = MailType.SmallParcel;

            // When
            var result = subject.GetMailProcessor(mailType);

            // Then
            Assert.NotNull(result);
            Assert.That(result.GetType(), Is.EqualTo(typeof(SmallParcelMailProcessor)));
        }

    }
}