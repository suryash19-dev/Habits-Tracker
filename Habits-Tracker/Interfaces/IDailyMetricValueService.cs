using Habits_Tracker.DTO;

namespace Habits_Tracker.Interfaces
{
    public interface IDailyMetricValueService
    {
        Task<ResultDto<DailyMetricValueResponseDto>> UpsertDailyMetricsAsync(DailyMetricValueDto dailyMetricValueDto);
    }
}
