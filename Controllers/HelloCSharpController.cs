
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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
        [Route("/parse_json")]
        public IEnumerable<string> GetResult()
        {
            string path = "C:/Users/singlesword/Desktop/tt-1.json";
            StreamReader streamReader = new StreamReader(path);
            string jsonStr = streamReader.ReadToEnd();

            //dynamic jsonObj = JsonConvert.DeserializeObject<dynamic>(jsonStr);
            //jsonObj["userInfo"]["customerName"] = "123456";

            JArray jsonArr = (JArray)JsonConvert.DeserializeObject(jsonStr);
            var res = new List<string>();
            foreach ( var line in jsonArr)
            {
                var message = ((JObject)line)["Message"];
                res.Add(message.ToString());
            }
            streamReader.Close();
            return res;
        }

        [HttpGet]
        [Route("/parse_json_1")]
        public IEnumerable<long> GetResult1()
        {
            string path = "C:/Users/singlesword/Desktop/tt-2.json";
            StreamReader streamReader = new StreamReader(path);
            string jsonStr = streamReader.ReadToEnd();

            JArray jsonArr = (JArray)JsonConvert.DeserializeObject(jsonStr);
            var res = new List<long>();
            foreach (var line in jsonArr)
            {
                var message = ((JObject)line)["universeId"];
                long universeId = long.Parse(message.ToString());
                if (!res.Contains(universeId))
                {
                    res.Add(universeId);
                }
            }
            streamReader.Close();
            return res;
        }






    }

}