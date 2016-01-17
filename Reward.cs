using System;

namespace NUV_PublicAPIClient
{
    public class Reward
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long StartTime { get; set; }

        public long EndTime { get; set; }

        public int Points { get; set; }

        public string RewardCode { get; set; }
    }
}
