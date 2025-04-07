using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axa.NadraClient.Nadra.Models.MbaVerify
{
    public class MbaVerifyFingerprintsRequest
    {
        public MbaVerifyFingerprintsRequest(string? requesterTranId, string customerCnic, string customerMsisdn, int fingerIndex, string fingerTemplate, TemplateTypes templateType, string areaName, string? nadraTranId, string? sessionId)
        {
            CustomerCnic = customerCnic;
            CustomerMsisdn = customerMsisdn;
            FingerIndex = fingerIndex;
            FingerTemplate = fingerTemplate;
            TemplateType = (int)templateType;
            AreaName = areaName;
            NadraTranId = nadraTranId;
            SessionId = sessionId;
            RequesterTranId = requesterTranId;
        }

        public string? RequesterTranId { get; private set; }
        public string CustomerCnic { get; private set; }
        public string CustomerMsisdn { get; private set; }
        public int FingerIndex { get; private set; }
        public string FingerTemplate { get; private set; }
        public int TemplateType { get; private set; }
        public string AreaName { get; private set; }
        public string? NadraTranId { get; private set; }
        public string? SessionId { get; private set; }
    }
    public class Arguments
    {
        public string additionalProp1 { get; set; }
        public string additionalProp2 { get; set; }
        public string additionalProp3 { get; set; }
    }

    public class Error
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public Dictionary<string, string>? Arguments { get; set; }
    }

    public class MbaVerifyFingerprintsResponse
    {
        public bool IsSuccess { get; set; }
        public bool IsFailure { get; set; }
        public Error Error { get; set; }
        public Value Value { get; set; }
    }

    public class Value
    {
        public string TranId { get; set; }
        public string NadraCode { get; set; }
        public string NadraMessage { get; set; }
        public string SessionId { get; set; }
        public string NadraTranId { get; set; }
        public string CustomerCnic { get; set; }
        public string CustomerName { get; set; }
        public string PresentAddress { get; set; }
        public string BirthPlace { get; set; }
        public string ExpiryDate { get; set; }
        public string MotherName { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public List<int> FingerIndexes { get; set; }
    }

}
