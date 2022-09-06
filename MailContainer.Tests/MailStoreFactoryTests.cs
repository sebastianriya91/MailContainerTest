using MailContainerTest;
using MailContainerTest.Data;
using MailContainerTest.Types;

namespace MailContainer.Tests
{
    public class MailProcessorStrategyTests
    {
        private MailStoreFactory subject;

        [SetUp]
        public void Setup()
        {
            subject = new MailStoreFactory();
        }

        [Test]
        public void GivenBackUpRequested_WhenCreateMailDataStore_ThenMustReturnBackUpDataStore()
        {
            // Given
            var storeType = StoreType.Backup;

            // When
            var result = subject.CreateMailDataStore(storeType);

            // Then
            Assert.NotNull(result);
            Assert.That(result.GetType(), Is.EqualTo(typeof(BackupMailContainerDataStore)));
        }

        [Test]
        public void GivenMailStoreRequested_WhenCreateMailDataStore_ThenMustReturnMailDataStore()
        {
            // Given
            var storeType = StoreType.Main;

            // When
            var result = subject.CreateMailDataStore(storeType);

            // Then
            Assert.NotNull(result);
            Assert.That(result.GetType(), Is.EqualTo(typeof(MailContainerDataStore)));
        }
    }
}