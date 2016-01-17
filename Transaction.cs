using System;

namespace NUV_PublicAPIClient
{
    public class Transaction
    {
        public Guid SchemeId { get; set; }

        public UserIdType UserIdType { get; set; }

        public string Id { get; set; }

        public double Amount { get; set; }

        public double Discount { get; set; }

        public int Point { get; set; }

        public Guid OfferId { get; set; }

        public string Location { get; set; }

        public string Reason { get; set; }

        public string DetailData { get; set; }

        public string DetailDataType { get; set; }
    }
}
