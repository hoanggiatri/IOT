using IoT.Data.Contexts;
using IoT.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IoT.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherController : ControllerBase
    {
        private readonly DataContext _context;

        public WeatherController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetWeatherData()
        {
            var weatherData = await _context.WeatherDatas.ToListAsync();
            return Ok(weatherData);
        }
        [HttpPost]
        public async Task<IActionResult> PostWeatherData(WeatherData weatherData)
        {
            weatherData.Time = DateTime.Now.ToString("dd-MM HH:mm");
            // Add weather data to the database
            _context.WeatherDatas.Add(weatherData);

            DeviceInfo deviceInfo = new DeviceInfo();

            // Do do am dat
            if (weatherData.SoilMoisture < 50)
            {
                deviceInfo.Pump = true;
            }
            else
            {
                deviceInfo.Pump = false;
            }

            // Do cuong do anh sang
            if(weatherData.LightIntensity == 0)
            {
                deviceInfo.Light = true;
            }
            else
            {
                deviceInfo.Light = false;
            }
            deviceInfo.DateTime = DateTime.Now;
            deviceInfo.Time = DateTime.Now.ToString("dd-MM HH:mm");
            _context.DeviceInfos.Add(deviceInfo);

            await _context.SaveChangesAsync();

            return Ok("Weather data saved successfully.");
        }

        // Lay yeu cau thiet bi
        [HttpGet]
        public async Task<IActionResult> GetDeviceInfo(){
            var deviceInfo = await _context.DeviceInfos
                       .OrderByDescending(p => p.DateTime)
                       .FirstOrDefaultAsync();
            var data = await _context.WeatherDatas.OrderByDescending(p => p.DateTime).FirstOrDefaultAsync();

            if (data.DateTime != null && DateTime.UtcNow.Subtract(data.DateTime.Value).TotalMinutes <= 5)
            {
                deviceInfo.Status = "Online";
            }
            else
            {
                deviceInfo.Status = "Offline";
            }
            return Ok(deviceInfo);
        }

        [HttpPost]
        public async Task<IActionResult> SendData(DeviceInfo deviceInfo)
        {
            deviceInfo.DateTime = DateTime.Now;
            deviceInfo.Time = DateTime.Now.ToString("dd-MM HH:mm");
            // Add weather data to the database
            _context.DeviceInfos.Add(deviceInfo);
            await _context.SaveChangesAsync();
            return Ok("Send data ok");
        }
    }
}