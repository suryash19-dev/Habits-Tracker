using AutoMapper;
using Habits_Tracker.Data;
using Habits_Tracker.DTO;
using Habits_Tracker.Entities;
using Habits_Tracker.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Habits_Tracker.Services
{
    public class DailyMetricValueService : IDailyMetricValueService
    {
        #region Fields

        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public DailyMetricValueService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #endregion

        #region Methods
        public virtual async Task<ResultDto<DailyMetricValueResponseDto>> UpsertDailyMetricsAsync(DailyMetricValueDto dailyMetricValueDto)
        {

            if(dailyMetricValueDto.MetricValue < 0)
            {
                return new ResultDto<DailyMetricValueResponseDto>
                {
                    ErrorMessage = StringResources.NegativeValue,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            var metricValue = await _dbContext.DailyMetricValues
                .FirstOrDefaultAsync(m => m.MetricDefinitionId == dailyMetricValueDto.MetricDefinitionId
                && m.Date == dailyMetricValueDto.Date);

            if(metricValue == null)
            {
                metricValue = new DailyMetricValue
                {
                    MetricDefinitionId = dailyMetricValueDto.MetricDefinitionId,
                    Date = dailyMetricValueDto.Date,
                    MetricValue = dailyMetricValueDto.MetricValue
                };

                _dbContext.DailyMetricValues.Add(metricValue);
            }

            else
            {
                metricValue.MetricValue = dailyMetricValueDto.MetricValue;
            }

            await _dbContext.SaveChangesAsync();

            var metricDefinition = await _dbContext.MetricDefinitions
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == metricValue.MetricDefinitionId);

            var successResponse = new ResultDto<DailyMetricValueResponseDto>
            {
                IsSuccess = true,
                Data = new DailyMetricValueResponseDto
                {
                    MetricDefinitionId = metricValue.MetricDefinitionId,
                    Date = metricValue.Date,
                    MetricValue = metricValue.MetricValue,
                    MetricName = metricDefinition?.MetricName,
                    Unit = metricDefinition?.Unit
                }
            };

            return successResponse;
        }

        #endregion
    }
}
