namespace HashRates.Models
{
    public class F2PoolResponse
    {
        public string mining_user_name { get; set; }
        public List<ReadOnlyPage> pages { get; set; }
        public string description { get; set; }
    }
}
