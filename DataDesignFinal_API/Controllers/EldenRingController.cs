using DataDesignFinal_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataDesignFinal_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EldenRingController : ControllerBase
    {
        //services that are called on by controller
        Services service = new Services();

        //Get Chart One endpoint
        // GET api/<EldenRingController>/5
        [HttpGet("get-chart-one")]
        public IEnumerable<ChartModel> GetChartOne()
        {
            //prepare the connection
            service.PrepareDBConnection();

            //return records from chart one
            return service.GetChartOne();
        }

        //Get chart two endpoint
        // GET api/<EldenRingController>/5
        [HttpGet("get-chart-two")]
        public IEnumerable<ChartModel> GetChartTwo()
        {
            //prepare the connection
            service.PrepareDBConnection();

            //return records from chart two
            return service.GetChartTwo();
        }

        //Get full report endpoint
        // GET: api/<EldenRingController>
        [HttpGet("get-full-report")]
        public IEnumerable<BossModel> GetFullReport()
        {
            //prepare the connection
            service.PrepareDBConnection();

            //return records from full report
            return service.GetFullReport();
        }

        //Get location data endpoint
        // GET api/<EldenRingController>/5
        [HttpGet("get-location-info")]
        public IEnumerable<LocationModel> GetLocationInfo()
        {
            //prepare the connection
            service.PrepareDBConnection();

            //return records from location table
            return service.GetLocationInfo();
        }

        //get damage data endpoint
        // GET api/<EldenRingController>/5
        [HttpGet("get-damage-info")]
        public IEnumerable<DamageModel> GetDamageInfo()
        {
            //prepare the connection
            service.PrepareDBConnection();

            //return records from damage table
            return service.GetDamageInfo();
        }
    }
}
