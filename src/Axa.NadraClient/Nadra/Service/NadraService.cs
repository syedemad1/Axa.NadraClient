using Axa.NadraClient.Nadra.Models.MbaVerify;
using Axa.NadraClient.Nadra.Models.MbdVerify;
using Axa.NadraClient.Nadra.Models.OtcVerify;
using AxaFramework.SharedKernel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axa.NadraClient.Nadra.Service
{
    public class NadraService : INadraService
    {
        private readonly NadraHttpClient nadraClient;
        private readonly ILogger<NadraService> _logger;

        public NadraService(NadraHttpClient httpClient, ILogger<NadraService> logger)
        {
            nadraClient = httpClient;
            _logger = logger;
        }

        public async Task<OtcVerifyFingerprintsResponse> OtcVerifyFingerprints(OtcVerifyFingerprintsRequest request, CancellationToken cancellationToken)
        {
            var postRes = await nadraClient.PostAsync<OtcVerifyFingerprintsRequest, OtcVerifyFingerprintsResponse>("api/nadra/otc/verifyfingerprint", request, cancellationToken);

            return postRes;
        }        

        public async Task<MbaVerifyFingerprintsResponse> MbaVerifyFingerprints(MbaVerifyFingerprintsRequest request, CancellationToken cancellationToken)
        {
            var postRes = await nadraClient.PostAsync<MbaVerifyFingerprintsRequest, MbaVerifyFingerprintsResponse>("api/nadra/mobileaccount/verifyfingerprint", request, cancellationToken);

            return postRes;
        }
        public async Task<MbdVerifyFingerprintsResponse> MbdVerifyFingerprints(MbdVerifyFingerprintsRequest request, CancellationToken cancellationToken)
        {
            var postRes = await nadraClient.PostAsync<MbdVerifyFingerprintsRequest, MbdVerifyFingerprintsResponse>("api/nadra/mobiledevice/verifyfingerprint", request, cancellationToken);

            return postRes;
        }
    }
}
