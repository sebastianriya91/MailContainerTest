using MailContainerTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailContainerTest.Strategy
{
    public class SmallParcelMailProcessor: IMailProcessor
    {
        /// <summary>
        /// Processes Small Parcel mail and returns IsSuccess Result
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
            else if (!mailContainer.AllowedMailType.HasFlag(AllowedMailType.SmallParcel))
            {
                return false;

            }
            else if (mailContainer.Status != MailContainerStatus.Operational)
            {
                return false;
            }
            return true;
        }
    }
}
