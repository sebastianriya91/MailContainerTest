using MailContainerTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailContainerTest.Data
{
    /// <summary>
    /// Container Data Store Contract definition
    /// </summary>
    public interface IContainerDataStore
    {
        MailContainer GetMailContainer(string mailContainerNumber);
        void UpdateMailContainer(MailContainer mailContainer);
    }
}
