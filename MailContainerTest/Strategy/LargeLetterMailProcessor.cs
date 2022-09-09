using MailContainerTest.Types;

namespace MailContainerTest.Strategy
{
    public class LargeLetterMailProcessor: IMailProcessor
    {
        /// <summary>
        /// Processes LargeLetterMails
        /// </summary>
        /// <param name="mailContainer"></param>
        /// <param name="numberOfMailItems"></param>
        /// <returns></returns>
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
