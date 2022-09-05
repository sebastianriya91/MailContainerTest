using MailContainerTest.Data;
using MailContainerTest.Types;
using System.Configuration;

namespace MailContainerTest.Services
{
    public class MailTransferService : IMailTransferService
    {
        IMailStoreFactory _mailStoreFactory;
        public MailTransferService(IMailStoreFactory mailStoreFactory)
        {
            _mailStoreFactory = mailStoreFactory;
        }
        public MakeMailTransferResult MakeMailTransfer(MakeMailTransferRequest request)
        {
            StoreType dataStoreType = Enum.Parse<StoreType>(ConfigurationManager.AppSettings["DataStoreType"]);

            var mailContainerStore = _mailStoreFactory.CreateMailDataStore(dataStoreType);
            var container = mailContainerStore.GetMailContainer(request.SourceMailContainerNumber);

            var result = new MakeMailTransferResult();

            switch (request.MailType)
            {
                case MailType.StandardLetter:
                    if (container == null)
                    {
                        result.Success = false;
                    }
                    else if (!container.AllowedMailType.HasFlag(AllowedMailType.StandardLetter))
                    {
                        result.Success = false;
                    }
                    break;

                case MailType.LargeLetter:
                    if (container == null)
                    {
                        result.Success = false;
                    }
                    else if (!container.AllowedMailType.HasFlag(AllowedMailType.LargeLetter))
                    {
                        result.Success = false;
                    }
                    else if (container.Capacity < request.NumberOfMailItems)
                    {
                        result.Success = false;
                    }
                    break;

                case MailType.SmallParcel:
                    if (container == null)
                    {
                        result.Success = false;
                    }
                    else if (!container.AllowedMailType.HasFlag(AllowedMailType.SmallParcel))
                    {
                        result.Success = false;

                    }
                    else if (container.Status != MailContainerStatus.Operational)
                    {
                        result.Success = false;
                    }
                    break;
            }

            if (result.Success)
            {
                container.Capacity -= request.NumberOfMailItems;

                if (dataStoreType == StoreType.Backup)
                {
                    var mailContainerDataStore = new BackupMailContainerDataStore();
                    mailContainerDataStore.UpdateMailContainer(container);

                }
                else
                {
                    var mailContainerDataStore = new MailContainerDataStore();
                    mailContainerDataStore.UpdateMailContainer(container);
                }
            }

            return result;
        }
    }
}
