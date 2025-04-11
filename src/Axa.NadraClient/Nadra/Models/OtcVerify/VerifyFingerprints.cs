using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axa.NadraClient.Nadra.Models.OtcVerify
{
    //public class OtcVerifyFingerprintsRequest
    //{
    //    public OtcVerifyFingerprintsRequest(string? requesterTranId, string customerCnic, string customerMsisdn, string receiverCnic, string receiverMsisdn, int fingerIndex, string fingerTemplate, TemplateTypes templateType, string? accountNumber, int remitAmount, RemittanceTypes remitType, string areaName, string? nadraTranId, string? sessionId)
    //    {
    //        RequesterTranId = requesterTranId;
    //        CustomerCnic = customerCnic;
    //        CustomerMsisdn = customerMsisdn;
    //        ReceiverCnic = receiverCnic;
    //        ReceiverMsisdn = receiverMsisdn;
    //        FingerIndex = fingerIndex;
    //        FingerTemplate = fingerTemplate;
    //        TemplateType = (int)templateType;
    //        AccountNumber = accountNumber;
    //        RemitAmount = remitAmount;
    //        RemitType = (int)remitType;
    //        AreaName = areaName;
    //        NadraTranId = nadraTranId;
    //        SessionId = sessionId;
    //    }

    //    public string? RequesterTranId { get; private set; }
    //    public string CustomerCnic { get; private set; }
    //    public string CustomerMsisdn { get; private set; }
    //    public string ReceiverCnic { get; private set; }
    //    public string ReceiverMsisdn { get; private set; }
    //    public int FingerIndex { get; private set; }
    //    public string FingerTemplate { get; private set; }
    //    public int TemplateType { get; private set; }
    //    public string? AccountNumber { get; private set; }
    //    public int RemitAmount { get; private set; }
    //    public int RemitType { get; private set; }
    //    public string AreaName { get; private set; }
    //    public string? NadraTranId { get; private set; }
    //    public string? SessionId { get; private set; }
    //}
    public record OtcVerifyFingerprintsRequest(
    string clientId,
    string? RequesterTranId,
    string CustomerCnic,
    string CustomerMsisdn,
    string ReceiverCnic,
    string ReceiverMsisdn,
    int FingerIndex,
    string FingerTemplate,
    TemplateTypes TemplateType,
    string? AccountNumber,
    int RemitAmount,
    RemittanceTypes RemitType,
    string AreaName,
    string? NadraTranId,
    string? SessionId
    );


    public class OtcVerifyFingerprintsResponse
    {
        public bool IsSuccess { get; set; }
        public bool IsFailure { get; set; }
        public Error Error { get; set; }
        public Value Value { get; set; }        
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
        //public Arguments Arguments { get; set; }
        public Dictionary<string,string>? Arguments { get; set; }
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
        public string ReceiverCnic { get; set; }
        public string ReceiverName { get; set; }
        public List<int> FingerIndexes { get; set; }
    }

}
