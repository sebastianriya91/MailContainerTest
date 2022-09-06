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
        // decides the mail Processor
        public IMailProcessor GetMailProcessor(MailType type)
        {
            switch (type)
            {
                case MailType.StandardLetter: return new StandardLetterMailProcessor();
                case MailType.LargeLetter: return new LargeLetterMailProcessor();
                case MailType.SmallParcel: return new SmallParcelMailProcessor();
                default:
                    throw new ArgumentException("Invalid type");
            }
        }
    }
}
