using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_1.MyLogging;

namespace WebAPI_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        // strongly coupled / tightly coupled
        private readonly IMyLogger _myLogger;

        public DemoController(IMyLogger myLogger)
        {
            _myLogger = myLogger;
            //this all are example of tightly coupled
            //_myLogger = new LogToFile();
            //_myLogger = new LogToDb();
            //_myLogger = new LogToServerMemory();
        }


        // GET METHOD

        [HttpGet]
        public ActionResult Index()
        {
            _myLogger.Log("Index method start");
            return Ok();
        }
    }
}
