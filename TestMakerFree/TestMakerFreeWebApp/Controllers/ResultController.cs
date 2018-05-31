using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestMakerFreeWebApp.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestMakerFreeWebApp.Controllers
{
    [Route("api/[controller]")]
    public class ResultController : Controller
    {
        //Get Api/question/All
        [HttpGet("All/{QuizId}")]
        public IActionResult All(int QuizId)
        {
            var sampleResults = new List<ResultViewModel>();

            //add a first sample result
            sampleResults.Add(new ResultViewModel()
            {
                Id = 1,
                QuizId = QuizId,
                Text = "What do you value most in your life?",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            });

            //add a bunch of other sample results
            for(var i = 2; i <= 5; i++)
            {
                sampleResults.Add(new ResultViewModel()
                {
                    Id = i,
                    QuizId = QuizId,
                    Text = String.Format($"Sample Question {i}"),
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }

            //Output the result in Json Format
            return new JsonResult(sampleResults,
                new JsonSerializerSettings()
                {
                   Formatting = Formatting.Indented
                });
        }
    }
   
}
