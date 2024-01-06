namespace IoT.Data.Models
{
    public class DeviceInfo
    {
        public int Id { get; set; }
        public bool Light { get; set; }
        public bool Pump {  get; set; }
        public string Status { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Time { get; set; }

    }
}
