using Habits_Tracker.DTO;

namespace Habits_Tracker.Interfaces
{
    public interface IMetricDefinitionService
    {
        Task<ResultDto<List<MetricDefinitionResponseDto>>> GetAllMetricDefinitions();
        Task<ResultDto<MetricDefinitionResponseDto>> GetMetricDefinitionById(int metricDefinitionId);
        Task<ResultDto<MetricDefinitionResponseDto>> AddMetricDefinition(MetricDefinitionDto metricDefinitionDto);
        Task<ResultDto<MetricDefinitionResponseDto>> UpdateMetricDefinition(int metricDefinitionId, MetricDefinitionDto metricDefinitionDto);
        Task<ResultDto<bool>> DeleteMetricDefinition(int metricDefinitionId);
    }
}
