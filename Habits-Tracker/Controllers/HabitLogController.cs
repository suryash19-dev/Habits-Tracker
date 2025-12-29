using Habits_Tracker.DTO;
using Habits_Tracker.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Habits_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitLogController : BaseController
    {
        #region Fields

        private readonly IHabitLogService _habitLogService;

        #endregion

        #region Ctor

        public HabitLogController(IHabitLogService habitLogService)
        {
            _habitLogService = habitLogService;
        }

        #endregion

        #region Methods

        [HttpPut]
        public async Task<IActionResult> UpsertHabitLogs([FromBody] HabitLogDto habitLogDto)
        {
            return this.Result(await _habitLogService.UpsertHabitLogAsync(habitLogDto));
        }

        #endregion
    }
}
