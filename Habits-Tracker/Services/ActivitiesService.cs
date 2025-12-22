using AutoMapper;
using Habits_Tracker.Data;
using Habits_Tracker.DTO;
using Habits_Tracker.Entities;
using Habits_Tracker.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Habits_Tracker.Services
{
    public class ActivitiesService : IActivitiesService
    {
        #region Fields

        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor
        public ActivitiesService(ApplicationDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        #endregion

        #region Methods
        public virtual async Task<ResultDto<List<ActivityResponseDto>>> GetAllActivities()
        {
            var allActivities = await _dbContext.Activities.ToListAsync();
            if (!allActivities.Any())
            {
                var response = new ResultDto<List<ActivityResponseDto>>
                {
                    ErrorMessage = StringResources.RecordNotFound,
                    StatusCode = HttpStatusCode.NotFound
                };
                return response;
            }

            var allActivitiesResponse = _mapper.Map<List<ActivityResponseDto>>(allActivities);

            var successResponse = new ResultDto<List<ActivityResponseDto>>
            {
                IsSuccess = true,
                Data = allActivitiesResponse
            };
            return successResponse;
        }

        public virtual async Task<ResultDto<ActivityResponseDto>> GetActivityById(int activityId)
        {
            var activity = await _dbContext.Activities.FirstOrDefaultAsync(x => x.Id == activityId);
            if(activity == null)
            {
                var response = new ResultDto<ActivityResponseDto>
                {
                    ErrorMessage = StringResources.NoResultsFound,
                    StatusCode = HttpStatusCode.NotFound
                };
                return response;
            }

            var activityResponse = _mapper.Map<ActivityResponseDto>(activity);

            var resultResponse = new ResultDto<ActivityResponseDto>()
            {
                IsSuccess = true,
                Data = activityResponse
            };

            return resultResponse;
        }

        public virtual async Task<ResultDto<ActivityResponseDto>> AddActivity(ActivityDto activityDto)
        {
            if(activityDto == null)
            {
                var response = new ResultDto<ActivityResponseDto>
                {
                    ErrorMessage = StringResources.NoResultsFound,
                    StatusCode = HttpStatusCode.NotFound
                };
                return response;
            }

            var item = _dbContext.Activities.Any(i => i.ActivityName == activityDto.ActivityName);

            if (item)
            {
                var errorResponse = new ResultDto<ActivityResponseDto>
                {
                    ErrorMessage = StringResources.RecordExists,
                    StatusCode = HttpStatusCode.Conflict
                };
                return errorResponse;
            }

            var activity = _mapper.Map<Activities>(activityDto);
            
            await _dbContext.AddAsync(activity);
            await _dbContext.SaveChangesAsync();

            var activityResponse = _mapper.Map<ActivityResponseDto>(activity);
            var successResponse = new ResultDto<ActivityResponseDto>
            {
                IsSuccess = true,
                Data = activityResponse
            };

            return successResponse;
        }

        public virtual async Task<ResultDto<ActivityResponseDto>> UpdateActivity(int activityId, ActivityDto activityDto)
        {
            if(activityDto == null)
            {
                var response = new ResultDto<ActivityResponseDto>
                {
                    ErrorMessage = StringResources.NoResultsFound,
                    StatusCode = HttpStatusCode.NotFound
                };
                return response;
            }

            var result = await _dbContext.Activities.FirstOrDefaultAsync(x => x.Id == activityId);

            if (result == null)
            {
                var response = new ResultDto<ActivityResponseDto>
                {
                    ErrorMessage = StringResources.NoResultsFound,
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            var activityItem = _dbContext.Activities.Any(i => i.ActivityName == activityDto.ActivityName && i.Id == activityId);

            if (activityItem)
            {
                var errorResponse = new ResultDto<ActivityResponseDto>
                {
                    ErrorMessage = StringResources.RecordExists,
                    StatusCode = HttpStatusCode.Conflict
                };
                return errorResponse;
            }

            _mapper.Map(activityDto, result);
            await _dbContext.SaveChangesAsync();

            var activityResponse = _mapper.Map<ActivityResponseDto>(result);
            var successResponse = new ResultDto<ActivityResponseDto>
            {
                IsSuccess = true,
                Data = activityResponse
            };

            return successResponse;
        }

        public virtual async Task<ResultDto<bool>> DeleteActivity(int activityId)
        {
            var activity = await _dbContext.Activities.FirstOrDefaultAsync(x => x.Id == activityId);
            if(activity == null)
            {
                var response = new ResultDto<bool>
                {
                    ErrorMessage = StringResources.RecordNotFound,
                    StatusCode = HttpStatusCode.NotFound
                };
                return response;
            }

            _dbContext.Activities.Remove(activity);
            await _dbContext.SaveChangesAsync();

            var successResponse = new ResultDto<bool>
            {
                IsSuccess = true,
                Data = true
            };

            return successResponse;
        }

        #endregion
    }
}
