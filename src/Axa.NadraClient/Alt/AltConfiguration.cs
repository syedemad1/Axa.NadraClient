using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axa.NadraClient.Alt
{
    public sealed class AltConfiguration
    {
        public const string SectionName = "AltConfiguration";
        public string BaseUrl { get; set; }
        public int Timeout { get; set; }
    }
}
