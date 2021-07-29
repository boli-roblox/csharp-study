using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CsharpStudyPro
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        //static void Main()
        //{
        //    double r = 2.50;
        //    double s = Math.PI * r * r;
        //    Console.WriteLine($"The area is :{s}");

        //    var fabonacciNumbers = new List<int> { 1, 1 };
        //    var previous1 = fabonacciNumbers[fabonacciNumbers.Count - 2];
        //    var previois2 = fabonacciNumbers[fabonacciNumbers.Count - 1];
        //    while( previois2 < 10000)
        //    {
        //        fabonacciNumbers.Add(previous1 + previois2);
        //        previous1 = fabonacciNumbers[fabonacciNumbers.Count - 2];
        //        previois2 = fabonacciNumbers[fabonacciNumbers.Count - 1];
        //    }

        //    foreach( var n in fabonacciNumbers)
        //    {
        //        Console.WriteLine(n);
        //    }
        //    Console.ReadKey();
        //}

        //static void Main()
        //{

        //    const string name = "Hello";
        //    const string name1 = "GGGGGGGGGGGGGGG";
        //    test(name, name1);

        //}

        //private static void test(string name, string name1)
        //{

        //    Console.WriteLine($"|{name,-9}|{"Left",-7}|{"Right",7}|");
        //    Console.WriteLine($"{name} world", name1);
        //    Console.WriteLine("{0} world", name);

        //}

       

        
    }
}
