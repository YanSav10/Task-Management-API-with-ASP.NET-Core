﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderProcessingSystemDotnet.Interfaces;
using OrderProcessingSystemDotnet.Models;
using OrderProcessingSystemDotnet.Models.DTOs;
using OrderProcessingSystemDotnet.Models.Tables;

namespace OrderProcessingSystemDotnet.Controllers
{
    /// <summary>
    /// Controller for managing user tasks through API endpoints.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserTasksController : ControllerBase
    {
        private readonly IUserTaskService _userTaskService;

        /// <summary>
        /// Constructor to initialize the controller with a user task service.
        /// </summary>
        /// <param name="userTaskService">The service for managing user tasks.</param>
        public UserTasksController(IUserTaskService userTaskService)
        {
            _userTaskService = userTaskService;
        }

        /// <summary>
        /// Endpoint to get all tasks.
        /// </summary>
        [HttpGet("get-all-task")]
        public async Task<IActionResult> GetTasks()
        {
            // Call the service to get all tasks.
            var response = await _userTaskService.GetTasks();

            // Return the response with the appropriate status code.
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Endpoint to get a task by its ID.
        /// </summary>
        /// <param name="input">DTO containing the task ID.</param>
        [HttpPost("get-task-by-id")]
        public async Task<IActionResult> GetTask([FromBody] GetTaskDto input)
        {
            // Call the service to get a task by ID.
            var response = await _userTaskService.GetTaskById(input.Id);

            // Return the response with the appropriate status code.
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Endpoint to update a task.
        /// </summary>
        /// <param name="task">The updated UserTask object.</param>
        [HttpPatch("update-task")]
        public async Task<IActionResult> UpdateTask([FromBody] UserTask task)
        {
            // Call the service to update the task.
            var response = await _userTaskService.UpdateTask(task);

            // Return the response with the appropriate status code.
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Endpoint to create a new task.
        /// </summary>
        /// <param name="task">The UserTask object representing the new task.</param>
        [HttpPost("create-task")]
        public async Task<IActionResult> CreateTask([FromBody] UserTask task)
        {
            // Call the service to create a new task.
            var response = await _userTaskService.CreateTask(task);

            // Return the response with the appropriate status code.
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Endpoint to delete a task by its ID.
        /// </summary>
        /// <param name="input">DTO containing the task ID to be deleted.</param>
        [HttpDelete("delete-task-by-id")]
        public async Task<IActionResult> DeleteTask([FromBody] DeleteTaskRequestDto input)
        {
            // Call the service to delete the task by ID.
            var response = await _userTaskService.DeleteTask(input.Id);

            // Return the response with the appropriate status code.
            return StatusCode(response.StatusCode, response);
        }
    }
}
