using Newtonsoft.Json;
using System.Runtime.Serialization;
using static restbe.Enums;

namespace restbe.Models
{
    [DataContract]
    public class GiftCard
    {
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        [DataMember]
        [JsonProperty("beneficiary_name")]
        public string BeneficiaryName { get; set; }

        [DataMember]
        [JsonProperty("amount")]
        public int Amount { get; set; }

        [DataMember]
        [JsonProperty("currency")]
        public CurrencyType Currency { get; set; }
    }
}
