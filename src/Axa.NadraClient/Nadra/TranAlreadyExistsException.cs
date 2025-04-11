using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axa.NadraClient.Nadra
{
    public class TranAlreadyExistsException :Exception
    {
        public TranAlreadyExistsException(string message) : base(message)
        {
        }
        public TranAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
        public TranAlreadyExistsException(string message, string tranId) : base($"{message} - TranId: {tranId}")
        {
        }
        public TranAlreadyExistsException(string message, string tranId, Exception innerException) : base($"{message} - TranId: {tranId}", innerException)
        {
        }
    }
}
