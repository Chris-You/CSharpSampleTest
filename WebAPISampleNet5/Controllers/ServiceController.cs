using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPISampleNet5.Services;
using WebAPISampleNet5.Factory;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace WebAPISampleNet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {

        private IServiceSingleton _singleton;
        private IServiceScoped _scoped1;
        private IServiceScoped _scoped2;
        private IServiceTransient _transient1;
        private IServiceTransient _transient2;
        private IDatabaseService _dbService;

        public ServiceController(IConfiguration config, IServiceSingleton single, 
                                 IServiceScoped scoped1, IServiceScoped scoped2,
                                 IServiceTransient tran1, IServiceTransient tran2,
                                 IDatabaseService dbService)
        {
            _singleton = single;
            _scoped1 = scoped1;
            _scoped2 = scoped2;
            _transient1 = tran1;
            _transient2 = tran2;
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = new
            {
                single = _singleton.GetHashCode(),
                scoped1 = _scoped1.GetHashCode(),
                scoped2 = _scoped2.GetHashCode(),
                transient1 = _transient1.GetHashCode(),
                transient2 = _transient2.GetHashCode(),
            };

            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post([FromBody] string body)
        {
            var file = Request.Form.Files;
            var bodystream = Request.Body;

            // json, csv 파일 형태로 전달이 된다.
            var readFile = new ReadFile();
            //var factory = readFile.Init(file);
            //factory.ReadFile();


            return Ok();
        }

        [HttpGet]
        [Route("Log")]
        public IActionResult GetLog()
        {

            var list = _dbService.GetLogAll();

            return Ok(list);
        }


    }
}