
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

        //[HttpGet]
        //public IEnumerable<HelloCSharp> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new HelloCSharp
        //    {
        //        Name = "Name" + index
        //    }).ToArray();
        //}

        [HttpGet]
        public void Get()
        {
            var numbers = new List<int> { 1, 3, 5, 7, 9 };
            //var numbers = new int[] { 1, 3, 5, 7, 9 };

            //foreach (var num in numbers)
            //{
            //    Console.WriteLine(num);
            //}

            //var s = "hello";

            var enumertor = numbers.GetEnumerator();
            while (enumertor.MoveNext())
            {
                Console.WriteLine($"{enumertor.Current}");
            }
        }
    }

}