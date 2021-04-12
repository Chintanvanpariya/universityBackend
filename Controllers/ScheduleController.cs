using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityServer.DTOs;
using UniversityServer.Entities;
using UniversityServer.Interfaces;

namespace UniversityServer.Controllers
{
    [Authorize]

    public class ScheduleController : BaseApiController
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ScheduleController(IUnitOfWork uow, IMapper mapr)
        {
            unitOfWork = uow;
            mapper = mapr;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetSchedules()
        {
            var courses = await unitOfWork.ScheduleRepository.GetSchedulesAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleDto>> GetSchedule(int id)
        {
            var course = await unitOfWork.ScheduleRepository.GetScheduleByIdAsync(id);
            return Ok(course);
        }

        [HttpPost("add")]
        public async Task<ActionResult<bool>> AddSchedule(ScheduleDto scheduleDto)
        {

            String[] fromlist = scheduleDto.Fromtime.Split(":");
            String[] tolist = scheduleDto.ToTime.Split(":");

            var schedule = new Schedule
            {
                Fromtime = new TimeSpan(int.Parse(fromlist[0]), int.Parse(fromlist[1]),0),
                ToTime = new TimeSpan(int.Parse(tolist[0]), int.Parse(tolist[1]), 0),
                Day = scheduleDto.Day,
                CourseId= scheduleDto.CourseId
            };

            unitOfWork.ScheduleRepository.AddScheduleAsync(schedule);

            return await unitOfWork.Complete();
        }

    }
}
