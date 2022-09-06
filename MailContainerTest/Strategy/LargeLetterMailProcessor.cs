using MailContainerTest.Types;

namespace MailContainerTest.Strategy
{
    public class LargeLetterMailProcessor: IMailProcessor
    {
        public bool IsSuccessfull(MailContainer mailContainer, int numberOfMailItems)
        {
            if (mailContainer == null)
            {
                return false;
            }
            else if (!mailContainer.AllowedMailType.HasFlag(AllowedMailType.LargeLetter))
            {
                return false;
            }
            else if (mailContainer.Capacity < numberOfMailItems)
            {
                return false;
            }
            return true;
        }
    }
}
