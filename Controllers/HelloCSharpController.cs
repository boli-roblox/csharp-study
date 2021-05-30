
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpStudyPro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloCSharpController : ControllerBase
    {

        private readonly ILogger<HelloCSharp> _logger;

        public HelloCSharpController(ILogger<HelloCSharp> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/test")]
        public void Get()
        {
            var numbers = new List<int> { 1, 3, 5, 7, 9 };

            var enumertor = numbers.GetEnumerator();
            while (enumertor.MoveNext())
            {
                Console.WriteLine($"{enumertor.Current}");
            }
        }


        [HttpGet]
        [Route("/hh")]
        public string GetResult()
        {
            string res = "res";
            return res;
        }
    }

}