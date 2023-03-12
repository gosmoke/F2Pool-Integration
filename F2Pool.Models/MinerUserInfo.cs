namespace HashRates.Models
{
    public class MinerUserInfo
    {
        public string mining_user_name { get; set; }
        public List<ReadOnlyPage> pages { get; set; }
        public List<Wallet> wallets { get; set; }
        public string description { get; set; }
    }
}
