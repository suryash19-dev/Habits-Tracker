using Habits_Tracker.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Habits_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : BaseController
    {
        #region Fields

        private readonly IDashboardService _dashboardService;

        #endregion

        #region Ctor
        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns dashboard data (activities + daily metrics) for a given date
        /// </summary>
        [HttpGet]
        [Route("GetDashboard")]
        public async Task<IActionResult> GetDashboard([FromQuery] DateOnly date)
        {
            return this.Result(await _dashboardService.GetDashboardAsync(date));
        }

        #endregion
    }
}
