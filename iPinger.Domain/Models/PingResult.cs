namespace iPinger.Domain.Models
{
    public class PingResult
    {
        public HostModel Host { get; set; }

        public bool Available { get; set; }

        /// <summary>
        /// Milliseconds responseTime
        /// </summary>
        public long ResponseTime { get; set; }

        public PingResult(HostModel host, bool result, int responseTime)
        {
            Host = host;
            Available = result;
            ResponseTime = responseTime;
        }
    }
}
