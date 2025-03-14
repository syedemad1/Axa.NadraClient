using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadraClient.Shared
{
    public enum TemplateTypes
    {
        ANSI = 3,
        ISO = 4,
        WSQ = 5,
        SAGEM_PKMAT = 6
    }

    public enum RemittanceTypes
    {
        SendMoney = 1,
        ReceiveMoney = 2
    }
}
