using Axa.NadraClient.Nadra.Models.MbaVerify;
using Axa.NadraClient.Nadra.Models.MbdVerify;
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
        Task<OtcVerifyFingerprintsResponse> OtcVerifyFingerprints(OtcVerifyFingerprintsRequest request, CancellationToken cancellationToken);
        Task<MbaVerifyFingerprintsResponse> MbaVerifyFingerprints(MbaVerifyFingerprintsRequest request, CancellationToken cancellationToken);
        Task<MbdVerifyFingerprintsResponse> MbdVerifyFingerprints(MbdVerifyFingerprintsRequest request, CancellationToken cancellationToken);
    }
}
