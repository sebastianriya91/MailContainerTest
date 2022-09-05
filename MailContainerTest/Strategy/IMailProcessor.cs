﻿using MailContainerTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailContainerTest.Strategy
{
    public interface IMailProcessor
    {
        bool IsSuccessfull(MailContainer mailContainer, int numberOfMailItems);
    }
}
