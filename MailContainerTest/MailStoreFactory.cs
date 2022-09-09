using MailContainerTest.Data;
using MailContainerTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailContainerTest
{
    public interface IMailStoreFactory
    {
        IContainerDataStore CreateMailDataStore(StoreType dataStoreType);
    }
    public class MailStoreFactory: IMailStoreFactory
    {
        /// <summary>
        /// Based on the store type passed by the service, factory decides the type of container store. Input in [Backup, Main]
        /// </summary>
        /// <param name="dataStoreType"></param>
        /// <returns>IContainerDataStore</returns>
        public IContainerDataStore CreateMailDataStore(StoreType dataStoreType)
        {
            if (dataStoreType == StoreType.Backup)
            {
                return new BackupMailContainerDataStore();
            }

            return new MailContainerDataStore();

        }
    }
}
