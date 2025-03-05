using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelLayer.Model;
using NLog;
using RepositoryLayer.Entity;
using RepositoryLayer.Service;

namespace HelloGreetingApplication.Controllers
{

    /// <summary>
    /// Class Providing API for HelloGreeting
    /// </summary>
    [ApiController]
    [Route("[controller]")]


    public class HelloGreetingController : ControllerBase
    {

        private IGreetingBL _greetingBL;

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public HelloGreetingController(IGreetingBL _greetingBL)
        {
            this._greetingBL = _greetingBL;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpPost("GreetByName")]
        public IActionResult GetGreeting(UserNameRequestModel request)
        {
            ResponseModel<String> responseModel = new ResponseModel<string>();
            responseModel.Success = true;
            responseModel.Message = "Greet message ";
            responseModel.Data = _greetingBL.GetGreeting(request);
            _logger.Info("Post Method Executed");
            return Ok(responseModel);
        }


        /// <summary>
        /// Get Greet message from service Layer
        /// </summary>
        /// <returns></returns>
        /// 


        [HttpGet("Greet")]
        public IActionResult GetGreet()
        {
            String data = _greetingBL.GetGreet();
            ResponseModel<String> responseModel = new ResponseModel<string>();
            responseModel.Success = true;
            responseModel.Message = "Greet message ";
            responseModel.Data = data;
            _logger.Info("Get Method Executed");
            return Ok(responseModel);

        }
        /// <summary>
        /// Get method to get the Greeting Message
        /// </summary>
        /// <returns>"Hello World"</returns>
        [HttpGet]
        public IActionResult Get()
        {
            ResponseModel<String> responseModel = new ResponseModel<string>();

            responseModel.Success = true;
            responseModel.Message = "API Endpoint Hit";
            responseModel.Data = "Hello World";
            _logger.Info("Get Method Executed");
            return Ok(responseModel);
        }

        /// <summary>
        /// Post method to accept a custom greeting message
        /// </summary>
        /// <param name="requestModel">Greeting message from user</param>
        /// <returns>Confirmation response</returns>
        [HttpPost]
        public IActionResult Post(RequestModel requestModel)
        {
            ResponseModel<String> responseModel = new ResponseModel<string>();

            responseModel.Success = true;
            responseModel.Message = "API Endpoint Hit";
            responseModel.Data = $"Key: {requestModel.key} , Value : {requestModel.value} ";
            _logger.Info("Post Method Executed");
            return Ok(responseModel);


        }

        /// <summary>
        /// Put method to accept a custom greeting message
        /// </summary>
        /// <param name="requestModel">Greeting message from user</param>
        /// <returns>Confirmation response</returns>
        [HttpPut]
        public IActionResult Put(RequestModel requestModel)
        {
            ResponseModel<String> responseModel = new ResponseModel<string>();

            responseModel.Success = true;
            responseModel.Message = "API Endpoint Hit in Put Method";
            responseModel.Data = $"Key: {requestModel.key} , Value : {requestModel.value} ";
            _logger.Info("Put Method Executed");
            return Ok(responseModel);

        }

        /// <summary>
        /// Patch method to accept a custom greeting message
        /// </summary>
        /// <param name="requestModel">Greeting message from user</param>
        /// <returns>Confirmation response</returns>
        [HttpPatch]
        public IActionResult Patch(RequestModel requestModel)
        {
            ResponseModel<String> responseModel = new ResponseModel<string>();

            responseModel.Success = true;
            responseModel.Message = "API Endpoint Hit";
            responseModel.Data = $"Key: {requestModel.key} , Value : {requestModel.value} ";
            _logger.Info("Patch Method Executed");
            return Ok(responseModel);
        }

        /// <summary>
        /// Delete method to remove a greeting message
        /// </summary>
        [HttpDelete]
        public IActionResult Delete()
        {

            ResponseModel<String> responseModel = new ResponseModel<string>();

            responseModel.Success = true;
            responseModel.Message = "API Endpoint Hit";
            responseModel.Data = null;
            _logger.Info("Detele Method Executed");
            return Ok(responseModel);
        }

        /// <summary>
        /// Handles the creation of a new greeting message.
        /// </summary>
        /// <param name="requestModel">The request containing the greeting message.</param>
        /// <returns>Returns a success response if the greeting is saved, or an error response if the input is invalid.</returns>
        [HttpPost("UC4")]
        public IActionResult SendGreeting(RequestModel requestModel)
        {
            ResponseModel<String> responseModel = new ResponseModel<string>();

            if (requestModel == null || string.IsNullOrWhiteSpace(requestModel.value))
            {
                return BadRequest(new { Success = false, Message = "Invalid input. Message cannot be empty." });
            }

            var greeting = new GreetingEntity { Message = requestModel.value };
            var savedGreeting = _greetingBL.AddGreeting(greeting);


            responseModel.Success = true;
            responseModel.Message = "Greeting saved successfully.";
            responseModel.Data = savedGreeting.Message;
            _logger.Info("SendGreeting Method Executed Successfully");
            return Ok(responseModel);
        }

        /// <summary>
        /// Retrieves a greeting message by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the greeting message.</param>
        /// <returns>
        /// Returns an HTTP 200 response with the greeting message if found.
        /// Returns an HTTP 404 response if no greeting message is found.
        /// </returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ResponseModel<String> responseModel = new ResponseModel<string>();

            var greeting = _greetingBL.GetGreetingById(id);
            if (greeting == null)
            {

                responseModel.Success = false;
                responseModel.Message = "Not Found";
                responseModel.Data = null;
                _logger.Info("Find Greeting by Id is Faileds");
                return NotFound(responseModel);
            }

            responseModel.Success = true;
            responseModel.Message = "Greeting saved successfully.";
            responseModel.Data = greeting.Message;
            _logger.Info("Find Greeting by Id is Faileds");
            return Ok(responseModel);

        }

        /// <summary>
        /// Retrieves a list of all greeting messages.
        /// </summary>
        /// <returns>A list of all stored greetings.</returns>
        [HttpGet("all")]
        public IActionResult GetAllGreetings()
        {
            var greetings = _greetingBL.GetAllGreetings();
            if (greetings == null || greetings.Count == 0)
            {
                _logger.Info("No greetings found.");
                return NotFound(new { Success = false, Message = "No greetings found." });
            }

            _logger.Info("All greetings retrieved successfully.");
            return Ok(new { Success = true, Data = greetings });
        }

        /// <summary>
        /// Updates an existing greeting message.
        /// </summary>
        /// <param name="id">The ID of the greeting to update.</param>
        /// <param name="requestModel">The updated greeting message.</param>
        /// <returns>The updated greeting message.</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateGreeting(int id, [FromBody] RequestModel requestModel)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();

            if (requestModel == null || string.IsNullOrWhiteSpace(requestModel.value))
            {
                return BadRequest(new { Success = false, Message = "Invalid input. Message cannot be empty." });
            }

            var existingGreeting = _greetingBL.GetGreetingById(id);
            if (existingGreeting == null)
            {
                responseModel.Success = false;
                responseModel.Message = "Greeting not found.";
                _logger.Info("Update Greeting failed. Greeting not found.");
                return NotFound(responseModel);
            }

            existingGreeting.Message = requestModel.value;
            var updatedGreeting = _greetingBL.UpdateGreeting(existingGreeting);

            responseModel.Success = true;
            responseModel.Message = "Greeting updated successfully.";
            responseModel.Data = updatedGreeting.Message;
            _logger.Info("Greeting updated successfully.");

            return Ok(responseModel);
        }



    }
}