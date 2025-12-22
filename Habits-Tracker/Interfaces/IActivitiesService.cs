using Habits_Tracker.DTO;

namespace Habits_Tracker.Interfaces
{
    public interface IActivitiesService
    {
        Task<ResultDto<List<ActivityResponseDto>>> GetAllActivities();
        Task<ResultDto<ActivityResponseDto>> GetActivityById(int activityId);
        Task<ResultDto<ActivityResponseDto>> AddActivity(ActivityDto activityDto);
        Task<ResultDto<ActivityResponseDto>> UpdateActivity(int activityId, ActivityDto activityDto);
        Task<ResultDto<bool>> DeleteActivity(int activityId);
    }
}
