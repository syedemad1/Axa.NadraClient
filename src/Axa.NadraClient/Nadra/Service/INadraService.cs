using Axa.NadraClient.Nadra.Models.OtcVerify;
using AxaFramework.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axa.NadraClient.Nadra.Service
{
    public interface INadraService
    {
        Task<AxaResult<OtcVerifyFingerprintsResponse>> OtcVerifyFingerprints(OtcVerifyFingerprintsRequest request, CancellationToken cancellationToken);
    }
}
