namespace IoT.Data.Models
{
    public class WeatherData
    {
        public long Id { get; set; }
        public int RainDrop { get; set; }
        public int WaterLevel { get; set; }
        public int Temperature { get; set; }
        public int AirHumidity { get; set; }
        public int SoilMoisture { get; set; }
        public int LightIntensity { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Time {  get; set; }

    }
}
