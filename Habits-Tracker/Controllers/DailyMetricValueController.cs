using Habits_Tracker.DTO;
using Habits_Tracker.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Habits_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyMetricValueController : BaseController
    {
        #region Fields

        private readonly IDailyMetricValueService _dailyMetricValueService;

        #endregion

        #region Ctor

        public DailyMetricValueController(IDailyMetricValueService dailyMetricValueService)
        {
            _dailyMetricValueService = dailyMetricValueService;
        }

        #endregion

        #region Methods

        [HttpPut]
        public async Task<IActionResult> UpsertDailyMetricValue([FromBody] DailyMetricValueDto dailyMetricValueDto)
        {
            return this.Result(await _dailyMetricValueService.UpsertDailyMetricsAsync(dailyMetricValueDto));
        }

        #endregion
    }
}
