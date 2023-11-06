using DI_MiddleWare_Configuration.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DI_MiddleWare_Configuration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private ITransientUniqueKeyProvider _transientUniquekeyProvider;
        private IScopedUniqueKeyProvider _scopedUniquekeyProvider;
        private ISingletonUniqueKeyProvider _singletonUniquekeyProvider;
        private ITestService _someserviceProvider;
        public TestController(ITransientUniqueKeyProvider transientprovider,
            IScopedUniqueKeyProvider scopedprovider,
            ISingletonUniqueKeyProvider singletonprovider, ITestService someserviceprovider)
        {
            _transientUniquekeyProvider = transientprovider;
            _scopedUniquekeyProvider = scopedprovider;
            _singletonUniquekeyProvider = singletonprovider;
            _someserviceProvider = someserviceprovider;
        }

        // GET: api/<TestController>
        [HttpGet]
        public string Get()
        {
            var transientID = _transientUniquekeyProvider.UniqueKey;
            var scopedID = _scopedUniquekeyProvider.UniqueKey;
            var singletonID = _singletonUniquekeyProvider.UniqueKey;
            var someServiceProvider = _someserviceProvider;

            return (
                $"transientID: {transientID}\n," +
                $"scopedID: {scopedID} \n," +
                $"singletonID: {singletonID} \n,"+
                $"service transientID: {someServiceProvider.TransientUniquekeyProvider.UniqueKey}\n," +
                $"service scopedID: {someServiceProvider.ScopedUniquekeyProvider.UniqueKey} \n," +
                $"service singletonID: {someServiceProvider.SingletonUniquekeyProvider.UniqueKey}"
                );
        }
    }
}
