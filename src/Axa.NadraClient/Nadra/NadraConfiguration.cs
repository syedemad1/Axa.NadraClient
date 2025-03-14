using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axa.NadraClient.Nadra
{
    public sealed class NadraConfiguration
    {
        public const string SectionName = "NadraConfiguration";
        public string BaseUrl { get; set; }
        public int Timeout { get; set; }
    }
}
