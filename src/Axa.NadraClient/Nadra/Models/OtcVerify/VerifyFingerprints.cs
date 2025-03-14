using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axa.NadraClient.Nadra.Models.OtcVerify
{
    public class OtcVerifyFingerprintsRequest
    {
        public string FranchiseId { get; set; }
        public string RequesterTranId { get; set; }
        public string CustomerCnic { get; set; }
        public string CustomerMsisdn { get; set; }
        public string ReceiverCnic { get; set; }
        public string ReceiverMsisdn { get; set; }
        public int FingerIndex { get; set; }
        public string FingerTemplate { get; set; }
        public int TemplateType { get; set; }
        public string AccountNumber { get; set; }
        public int RemitAmount { get; set; }
        public int RemitType { get; set; }
        public string AreaName { get; set; }
        public string NadraTranId { get; set; }
        public string SessionId { get; set; }
    }
    public class OtcVerifyFingerprintsResponse
    {
        public bool IsSuccess { get; set; }
        public bool IsFailure { get; set; }
        public OtcVerifyFingerprintsError Error { get; set; }
        public OtcVerifyFingerrintsValue Value { get; set; }

        public class Arguments
        {
            public string additionalProp1 { get; set; }
            public string additionalProp2 { get; set; }
            public string additionalProp3 { get; set; }
        }
        public class OtcVerifyFingerprintsError
        {
            public string Code { get; set; }
            public string Description { get; set; }
            public int Type { get; set; }
            public Arguments Arguments { get; set; }
        }
        public class OtcVerifyFingerrintsValue
        {
            public string TranId { get; set; }
            public string NadraCode { get; set; }
            public string NadraMessage { get; set; }
            public string SessionId { get; set; }
            public string NadraTranId { get; set; }
            public string CustomerCnic { get; set; }
            public string CustomerName { get; set; }
            public string ReceiverCnic { get; set; }
            public string ReceiverName { get; set; }
            public List<int> FingerIndexes { get; set; }
        }
    }

}
