using Habits_Tracker.DTO;
using Habits_Tracker.Interfaces;
using Habits_Tracker.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Habits_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetricDefinitionController : BaseController
    {
        #region Fields

        private readonly IMetricDefinitionService _metricDefinitionService;

        #endregion

        #region Ctor

        public MetricDefinitionController(IMetricDefinitionService metricDefinitionService)
        {
            _metricDefinitionService = metricDefinitionService;
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetAllMetricDefinitions")]
        public async Task<IActionResult> GetAllMetricDefinitions()
        {
            return this.Result(await _metricDefinitionService.GetAllMetricDefinitions());
        }

        [HttpGet]
        [Route("{metricDefinitionId}")]
        public async Task<IActionResult> GetMetricDefinitionById(int metricDefinitionId)
        {
            return this.Result(await _metricDefinitionService.GetMetricDefinitionById(metricDefinitionId));
        }

        [HttpPost]
        public async Task<IActionResult> AddMetricDefinition([FromBody] MetricDefinitionDto metricDefinitionDto)
        {
            return this.Result(await _metricDefinitionService.AddMetricDefinition(metricDefinitionDto));
        }

        [HttpPut]
        [Route("{metricDefinitionId}")]
        public async Task<IActionResult> UpdateMetricDefinition(int metricDefinitionId, [FromBody] MetricDefinitionDto metricDefinitionDto)
        {
            return this.Result(await _metricDefinitionService.UpdateMetricDefinition(metricDefinitionId, metricDefinitionDto));
        }

        [HttpDelete]
        [Route("{metricDefinitionId}")]
        public async Task<IActionResult> DeleteMetricDefinition(int metricDefinitionId)
        {
            return this.Result(await _metricDefinitionService.DeleteMetricDefinition(metricDefinitionId));
        }

        #endregion
    }
}
