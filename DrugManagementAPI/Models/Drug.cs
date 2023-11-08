namespace DrugManagementAPI.Models
{
    public class Drug
    {
        public string Name {  get; set; }

        public int Id {  get; set; }
        public string SerialNumber {  get; set; }
        public DateTime ManufacturedDate { get; set; }
        public DateTime ExpiredDate {  get; set; }
    }
}
