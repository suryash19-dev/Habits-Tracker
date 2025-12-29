using AutoMapper;
using Habits_Tracker.Data;
using Habits_Tracker.DTO;
using Habits_Tracker.Entities;
using Habits_Tracker.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Habits_Tracker.Services
{
    public class HabitLogService : IHabitLogService
    {
        #region Fields

        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public HabitLogService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public virtual async Task<ResultDto<HabitLogResponseDto>> UpsertHabitLogAsync(HabitLogDto habitLogDto)
        {
            var habitLog = await _dbContext.HabitLogs
                .FirstOrDefaultAsync(h => h.ActivityId == habitLogDto.ActivityId && h.LogDate == habitLogDto.LogDate);

            if(habitLog == null)
            {
                habitLog = new HabitLog
                {
                    ActivityId = habitLogDto.ActivityId,
                    LogDate = habitLogDto.LogDate,
                    IsDone = habitLogDto.IsDone,
                };

                _dbContext.HabitLogs.Add(habitLog);
            }

            else
            {
                habitLog.IsDone = habitLogDto.IsDone;
            }

            await _dbContext.SaveChangesAsync();

            var habitLogResponse = _mapper.Map<HabitLogResponseDto>(habitLog);

            var successResponse = new ResultDto<HabitLogResponseDto>
            {
                IsSuccess = true,
                Data = habitLogResponse
            };

            return successResponse;
        }

        #endregion
    }
}
