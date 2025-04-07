using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadraClient.Shared
{
    public enum TemplateTypes
    {
        ANSI = 1,
        ISO_19794_2 = 2,
        SAGEM_PKMAT = 3,
        SAGEM_PKCOMPV2 = 4,
        SAGEM_CFV = 5,
        RAW_IMAGE = 6,
        WSQ = 7
    }
    public enum RemittanceTypes
    {
        MONENY_TRANSFER_SEND = 1,
        MONENY_TRANSFER_RECEIVE = 2,
        IBFT = 3
    }
}
