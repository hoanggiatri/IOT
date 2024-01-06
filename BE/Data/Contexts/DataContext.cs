using IoT.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IoT.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<WeatherData> WeatherDatas { get; set; }
        public DbSet<DeviceInfo> DeviceInfos { get; set; }
    }
}
