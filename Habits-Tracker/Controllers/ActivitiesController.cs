using Habits_Tracker.DTO;
using Habits_Tracker.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Habits_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : BaseController
    {
        #region Fields

        private readonly IActivitiesService _activitiesService;

        #endregion

        #region Ctor
        public ActivitiesController(IActivitiesService activitiesService)
        {
            _activitiesService = activitiesService;
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetAllActivities")]
        public async Task<IActionResult> GetAllActivities()
        {
            return this.Result(await _activitiesService.GetAllActivities());
        }

        [HttpGet]
        [Route("{activityId}")]
        public async Task<IActionResult> GetActivity(int activityId)
        {
            return this.Result(await _activitiesService.GetActivityById(activityId));
        }

        [HttpPost]
        public async Task<IActionResult> AddActivity([FromBody] ActivityDto activityDto)
        {
            return this.Result(await _activitiesService.AddActivity(activityDto));
        }

        [HttpPut]
        [Route("{activityId}")]
        public async Task<IActionResult> UpdateActivity(int activityId, [FromBody] ActivityDto activityDto)
        {
            return this.Result(await _activitiesService.UpdateActivity(activityId, activityDto));
        }

        [HttpDelete]
        [Route("{activityId}")]
        public async Task<IActionResult> DeleteActivity(int activityId)
        {
            return this.Result(await _activitiesService.DeleteActivity(activityId));
        }

        #endregion
    }
}
