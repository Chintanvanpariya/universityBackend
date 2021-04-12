using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityServer.DTOs;
using UniversityServer.Entities;
using UniversityServer.Interfaces;

namespace UniversityServer.Data
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public ScheduleRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddScheduleAsync(Schedule schedule)
        {
            context.Schedules.Add(schedule);
        }

        public void DeleteScheduleAsync(Schedule schedule)
        {
            context.Schedules.Remove(schedule);
        }

        public async Task<ScheduleDto> GetScheduleByIdAsync(int scheduleId)
        {
            return await context.Schedules
                .Where(x => x.Id == scheduleId)
                .ProjectTo<ScheduleDto>(mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<ScheduleDto>> GetSchedulesAsync()
        {
            return await context.Schedules
               .ProjectTo<ScheduleDto>(mapper.ConfigurationProvider)
               .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void UpdateSchedule(Schedule schedule)
        {
            context.Entry(schedule).State = EntityState.Modified;
        }
    }
}
