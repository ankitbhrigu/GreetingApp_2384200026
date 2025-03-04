using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelLayer.Model;
using NLog;

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


    }
}