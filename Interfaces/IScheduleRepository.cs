using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityServer.DTOs;
using UniversityServer.Entities;

namespace UniversityServer.Interfaces
{
    public interface IScheduleRepository
    {
        void AddScheduleAsync(Schedule schedule);
        void UpdateSchedule(Schedule schedule);
        void DeleteScheduleAsync(Schedule schedule);
        Task<ScheduleDto> GetScheduleByIdAsync(int scheduleId);
        Task<IEnumerable<ScheduleDto>> GetSchedulesAsync();
        Task<bool> SaveAllAsync();

    }
}
