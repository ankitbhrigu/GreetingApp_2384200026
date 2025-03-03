using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelLayer.Model;
using System.Collections.Generic;

namespace HelloGreetingApplication.Controllers
{
    /// <summary>
    /// Class Providing API for HelloGreeting
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HelloGreetingController : ControllerBase
    {
        private static Dictionary<string, string> _greetings = new Dictionary<string, string>();
        private readonly ILogger<HelloGreetingController> _logger;

        public HelloGreetingController(ILogger<HelloGreetingController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get method to get the Greeting Message
        /// </summary>
        /// <returns>"Hello World"</returns>
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("GET request received.");

            var responseModel = new ResponseModel<string>
            {
                Success = true,
                Message = "API Endpoint Hit",
                Data = "Hello World"
            };

            _logger.LogInformation("GET response sent successfully.");
            return Ok(responseModel);
        }

        /// <summary>
        /// Post method to accept a custom greeting message
        /// </summary>
        [HttpPost]
        public IActionResult Post(RequestModel requestModel)
        {
            _logger.LogInformation($"POST request received with Key: {requestModel.key}, Value: {requestModel.value}");

            if (_greetings.ContainsKey(requestModel.key))
            {
                _logger.LogWarning($"Key {requestModel.key} already exists.");
                return BadRequest(new ResponseModel<string>
                {
                    Success = false,
                    Message = "Key already exists.",
                    Data = null
                });
            }

            _greetings[requestModel.key] = requestModel.value;
            _logger.LogInformation($"New greeting added: Key = {requestModel.key}, Value = {requestModel.value}");

            return Ok(new ResponseModel<string>
            {
                Success = true,
                Message = "Greeting message received successfully.",
                Data = $"Key: {requestModel.key}, Value: {requestModel.value}"
            });
        }

        /// <summary>
        /// Put method for updating a greeting message
        /// </summary>
        [HttpPut]
        public IActionResult Put(RequestModel requestModel)
        {
            _logger.LogInformation($"PUT request received for Key: {requestModel.key} with new Value: {requestModel.value}");

            if (!_greetings.ContainsKey(requestModel.key))
            {
                _logger.LogWarning($"PUT failed: Key {requestModel.key} not found.");
                return NotFound(new ResponseModel<string>
                {
                    Success = false,
                    Message = "Key not found.",
                    Data = null
                });
            }

            _greetings[requestModel.key] = requestModel.value;
            _logger.LogInformation($"Greeting updated: Key = {requestModel.key}, New Value = {requestModel.value}");

            return Ok(new ResponseModel<string>
            {
                Success = true,
                Message = "Greeting message updated successfully.",
                Data = $"Key: {requestModel.key}, Updated Value: {requestModel.value}"
            });
        }

        /// <summary>
        /// Patch method for modifying a greeting message
        /// </summary>
        [HttpPatch]
        public IActionResult Patch(string key, string modifiedMessage)
        {
            _logger.LogInformation($"PATCH request received for Key: {key} with Modified Value: {modifiedMessage}");

            if (!_greetings.ContainsKey(key))
            {
                _logger.LogWarning($"PATCH failed: Key {key} not found.");
                return NotFound(new ResponseModel<string>
                {
                    Success = false,
                    Message = "Key not found.",
                    Data = null
                });
            }

            _greetings[key] = modifiedMessage;
            _logger.LogInformation($"Greeting modified: Key = {key}, New Value = {modifiedMessage}");

            return Ok(new ResponseModel<string>
            {
                Success = true,
                Message = "Greeting message modified successfully.",
                Data = $"Key: {key}, Modified Value: {modifiedMessage}"
            });
        }

        /// <summary>
        /// Delete method to remove a greeting message
        /// </summary>
        [HttpDelete("{key}")]
        public IActionResult Delete(string key)
        {
            _logger.LogInformation($"DELETE request received for Key: {key}");

            if (!_greetings.ContainsKey(key))
            {
                _logger.LogWarning($"DELETE failed: Key {key} not found.");
                return NotFound(new ResponseModel<string>
                {
                    Success = false,
                    Message = "Key not found.",
                    Data = null
                });
            }

            _greetings.Remove(key);
            _logger.LogInformation($"Greeting deleted: Key = {key}");

            return Ok(new ResponseModel<string>
            {
                Success = true,
                Message = "Greeting message deleted successfully.",
                Data = $"Deleted Key: {key}"
            });
        }
    }
}
