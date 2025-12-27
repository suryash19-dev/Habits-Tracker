using AutoMapper;
using Habits_Tracker.Data;
using Habits_Tracker.DTO;
using Habits_Tracker.Entities;
using Habits_Tracker.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;

namespace Habits_Tracker.Services
{
    public class MetricDefinitionService : IMetricDefinitionService
    {
        #region Fields

        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public MetricDefinitionService(ApplicationDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public virtual async Task<ResultDto<List<MetricDefinitionResponseDto>>> GetAllMetricDefinitions()
        {
            var allMetrics = await _dbContext.MetricDefinitions.ToListAsync();
            if (!allMetrics.Any())
            {
                var response = new ResultDto<List<MetricDefinitionResponseDto>>
                {
                    ErrorMessage = StringResources.RecordNotFound,
                    StatusCode = HttpStatusCode.NotFound
                };
                return response;
            }

            var allMetricsResponse = _mapper.Map<List<MetricDefinitionResponseDto>>(allMetrics);

            var successResponse = new ResultDto<List<MetricDefinitionResponseDto>>
            {
                IsSuccess = true,
                Data = allMetricsResponse
            };

            return successResponse;
        }

        public virtual async Task<ResultDto<MetricDefinitionResponseDto>> GetMetricDefinitionById(int metricDefinitionId)
        {
            var metricDefinition = await _dbContext.MetricDefinitions.FirstOrDefaultAsync(x => x.Id == metricDefinitionId);
            if (metricDefinition == null)
            {
                var response = new ResultDto<MetricDefinitionResponseDto>
                {
                    ErrorMessage = StringResources.NoResultsFound,
                    StatusCode = HttpStatusCode.NotFound
                };
                return response;
            }

            var metricDefinitionResponse = _mapper.Map<MetricDefinitionResponseDto>(metricDefinition);

            var resultResponse = new ResultDto<MetricDefinitionResponseDto>()
            {
                IsSuccess = true,
                Data = metricDefinitionResponse
            };

            return resultResponse;
        }

        public virtual async Task<ResultDto<MetricDefinitionResponseDto>> AddMetricDefinition(MetricDefinitionDto metricDefinitionDto)
        {
            if (metricDefinitionDto == null)
            {
                var response = new ResultDto<MetricDefinitionResponseDto>
                {
                    ErrorMessage = StringResources.NoResultsFound,
                    StatusCode = HttpStatusCode.NotFound
                };
                return response;
            }

            var item = _dbContext.MetricDefinitions.Any(i => i.MetricName == metricDefinitionDto.MetricName);

            if (item)
            {
                var errorResponse = new ResultDto<MetricDefinitionResponseDto>
                {
                    ErrorMessage = StringResources.RecordExists,
                    StatusCode = HttpStatusCode.Conflict
                };
                return errorResponse;
            }

            var metricDefinition = _mapper.Map<MetricDefinition>(metricDefinitionDto);

            await _dbContext.AddAsync(metricDefinition);
            await _dbContext.SaveChangesAsync();

            var metricDefinitionResponse = _mapper.Map<MetricDefinitionResponseDto>(metricDefinition);
            var successResponse = new ResultDto<MetricDefinitionResponseDto>
            {
                IsSuccess = true,
                Data = metricDefinitionResponse
            };

            return successResponse;
        }

        public virtual async Task<ResultDto<MetricDefinitionResponseDto>> UpdateMetricDefinition(int metricDefinitionId, MetricDefinitionDto metricDefinitionDto)
        {
            if (metricDefinitionDto == null)
            {
                var response = new ResultDto<MetricDefinitionResponseDto>
                {
                    ErrorMessage = StringResources.NoResultsFound,
                    StatusCode = HttpStatusCode.NotFound
                };
                return response;
            }

            var result = await _dbContext.MetricDefinitions.FirstOrDefaultAsync(x => x.Id == metricDefinitionId);

            if (result == null)
            {
                var response = new ResultDto<MetricDefinitionResponseDto>
                {
                    ErrorMessage = StringResources.NoResultsFound,
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            var metricDefinitionItem = _dbContext.MetricDefinitions.Any(i => i.MetricName == metricDefinitionDto.MetricName && i.Id == metricDefinitionId);

            if (metricDefinitionItem)
            {
                var errorResponse = new ResultDto<MetricDefinitionResponseDto>
                {
                    ErrorMessage = StringResources.RecordExists,
                    StatusCode = HttpStatusCode.Conflict
                };
                return errorResponse;
            }

            _mapper.Map(metricDefinitionDto, result);
            await _dbContext.SaveChangesAsync();

            var metricDefinitionResponse = _mapper.Map<MetricDefinitionResponseDto>(result);
            var successResponse = new ResultDto<MetricDefinitionResponseDto>
            {
                IsSuccess = true,
                Data = metricDefinitionResponse
            };

            return successResponse;
        }

        public virtual async Task<ResultDto<bool>> DeleteMetricDefinition(int metricDefinitionId)
        {
            var metricDefinition = await _dbContext.MetricDefinitions.FirstOrDefaultAsync(x => x.Id == metricDefinitionId);
            if (metricDefinition == null)
            {
                var response = new ResultDto<bool>
                {
                    ErrorMessage = StringResources.RecordNotFound,
                    StatusCode = HttpStatusCode.NotFound
                };
                return response;
            }

            _dbContext.MetricDefinitions.Remove(metricDefinition);
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
