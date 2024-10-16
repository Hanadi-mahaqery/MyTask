using Microsoft.AspNetCore.Mvc;
using MyTask.Models;
using MyTask.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTask.APIs.doctor
{
    [Route("api/[controller]")]
    [ApiController]
    public class Request_StatuesController : ControllerBase
    {
        private readonly MedicinesContext context;
        private readonly ILogger<Request_StatuesController> _logger;


        public Request_StatuesController(MedicinesContext context, ILogger<Request_StatuesController> logger)
        {
            this.context = context;
            _logger = logger;

        }
      
        // PUT api/<Request_StatuesController>/5
        [HttpPut("UpdatedRequest/{requestId}")]
    public IActionResult Put(int requestId, [FromBody] RequestStatuesViewModel updatedRequest)
    {
        if (requestId != updatedRequest.RequestId)
        {
            return BadRequest("ID mismatch");
        }

        var existingRequests = context.Requests.FirstOrDefault(l => l.RequestId == requestId);
        if (existingRequests == null)
        {
            return NotFound();
        }

        existingRequests.Status = updatedRequest.Status;

        try
        {
            context.Requests.Update(existingRequests);
            context.SaveChanges();
                return Ok("Request Status Updated successfully.");
            }
            catch (Exception ex)
        {
            return StatusCode(500, "An error occurred: " + ex.Message);
        }
    }

    }
}
