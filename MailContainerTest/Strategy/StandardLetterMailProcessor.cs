using MailContainerTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailContainerTest.Strategy
{
    public class StandardLetterMailProcessor: IMailProcessor
    {
        /// <summary>
        /// Processes Standard Letter mail and returns IsSuccess Result
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
            else if (!mailContainer.AllowedMailType.HasFlag(AllowedMailType.StandardLetter))
            {
                return false;
            }
            return true;
        }
    }
}
