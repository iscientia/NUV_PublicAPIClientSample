using System;

namespace NUV_PublicAPIClient
{
    public class Offer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public long StartTime { get; set; }
        public long EndTime { get; set; }
        public string OfferCode { get; set; }
        public int MinPoints { get; set; }
        public OfferType OfferType { get; set; }
    }
}
