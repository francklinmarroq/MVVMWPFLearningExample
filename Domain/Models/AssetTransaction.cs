namespace Domain.Models
{
    public class AssetTransaction : DomainObject
    {
        public Boolean IsPurchase { get; set; }
        public Stock Stock { get; set; }
        public int Shares { get; set; }
        public DateTime DateProcessed { get; set; }
    }
}
