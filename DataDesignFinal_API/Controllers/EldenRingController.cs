using DataDesignFinal_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataDesignFinal_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EldenRingController : ControllerBase
    {
        Services service = new Services();

        // GET api/<EldenRingController>/5
        [HttpGet("get-chart-one")]
        public IEnumerable<ChartModel> GetChartOne()
        {
            service.PrepareDBConnection();

            return service.GetChartOne();
        }

        // GET api/<EldenRingController>/5
        [HttpGet("get-chart-two")]
        public IEnumerable<ChartModel> GetChartTwo()
        {
            service.PrepareDBConnection();

            return service.GetChartTwo();
        }

        // GET: api/<EldenRingController>
        [HttpGet("get-full-report")]
        public IEnumerable<BossModel> GetFullReport()
        {
            service.PrepareDBConnection();

            return service.GetFullReport();
        }

        // GET api/<EldenRingController>/5
        [HttpGet("get-location-info")]
        public IEnumerable<LocationModel> GetLocationInfo()
        {
            service.PrepareDBConnection();

            return service.GetLocationInfo();
        }

        // GET api/<EldenRingController>/5
        [HttpGet("get-damage-info")]
        public IEnumerable<DamageModel> GetDamageInfo()
        {
            service.PrepareDBConnection();

            return service.GetDamageInfo();
        }
    }
}
