using MailContainerTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailContainerTest.Strategy
{
    public interface IMailProcessorStrategy
    {
        IMailProcessor GetMailProcessor(MailType type);
    }
    public class MailProcessorStrategy : IMailProcessorStrategy
    {
        /// <summary>
        /// Based on the mail type, startegy decided which Processor to be used. So that the service can cal the respective Process Method
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public IMailProcessor GetMailProcessor(MailType type)
        {
            return type switch
            {
                MailType.StandardLetter => new StandardLetterMailProcessor(),
                MailType.LargeLetter => new LargeLetterMailProcessor(),
                MailType.SmallParcel => new SmallParcelMailProcessor(),
                _ => throw new ArgumentException("Invalid type"),
            };
        }
    }
}
