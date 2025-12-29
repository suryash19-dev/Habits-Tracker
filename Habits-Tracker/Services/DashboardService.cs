using Habits_Tracker.Data;
using Habits_Tracker.DTO;
using Habits_Tracker.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Habits_Tracker.Services
{
    public class DashboardService : IDashboardService
    {
        #region Fields

        private readonly ApplicationDbContext _dbContext;

        #endregion

        #region Ctor
        public DashboardService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public virtual async Task<ResultDto<DashboardResponseDto>> GetDashboardAsync(DateOnly date)
        {
            var activities = await GetActivitiesForDashboardAsync(date);

            var dailyMetrics = await GetDailyMetricsForDashboardAsync(date);

            var dashboaordResponse = new DashboardResponseDto
            {
                Activities = activities,
                DailyMetrics = dailyMetrics,
            };

            var successResponse = new ResultDto<DashboardResponseDto>
            {
                IsSuccess = true,
                Data = dashboaordResponse
            };

            return successResponse;
        }

        // ---------------------------
        // ACTIVITIES SECTION
        // ---------------------------
        private async Task<List<ActivityDashboardDto>> GetActivitiesForDashboardAsync(DateOnly date)
        {
            var activities = await _dbContext.Activities
                .AsNoTracking()
                .ToListAsync();

            var habitLogs = await _dbContext.HabitLogs
                .AsNoTracking()
                .Where(h => h.LogDate == date)
                .ToListAsync();

            var habitLogLookup = habitLogs
                .ToDictionary(h => h.ActivityId, h => h.IsDone);

            var habitLogActivities = activities.Select(activity =>
            {
                var isDoneVar = habitLogLookup.TryGetValue(activity.Id, out var isDone) && isDone;

                return new ActivityDashboardDto
                {
                    ActivityId = activity.Id,
                    ActivityName = activity.ActivityName,
                    ActivityDetails = activity.ActivityDetails,
                    DatesData = new List<ActivityDateStatusDto>
                    {
                        new ActivityDateStatusDto
                        {
                            Date = date,
                            IsDone = isDoneVar
                        }
                    }
                };
            }).ToList();

            return habitLogActivities;
        }

        // ---------------------------
        // DAILY METRICS SECTION
        // ---------------------------
        private async Task<List<DailyMetricsGroupDto>> GetDailyMetricsForDashboardAsync(DateOnly date)
        {
            var metricDefinitions = await _dbContext.MetricDefinitions
                .AsNoTracking()
                .ToListAsync();

            var metricValues = await _dbContext.DailyMetricValues
                .AsNoTracking()
                .Where(d => d.Date == date)
                .ToListAsync();

            var metricValueLookup = metricValues
                .ToDictionary(m => m.MetricDefinitionId, m => m);

            var metricsForDay = metricDefinitions.Select(definition =>
            {
                metricValueLookup.TryGetValue(definition.Id, out var metricValue);

                return new DailyMetricValueResponseDto
                {
                    MetricDefinitionId = definition.Id,
                    Date = date,
                    MetricValue = metricValue?.MetricValue,
                    MetricName = definition.MetricName,
                    Unit = definition.Unit
                };
            }).ToList();

            var dailyMetricsResponse = new List<DailyMetricsGroupDto>
            {
                new DailyMetricsGroupDto
                {
                    Date = date,
                    Metrics = metricsForDay
                }
            };

            return dailyMetricsResponse;
        }

        #endregion
    }
}
