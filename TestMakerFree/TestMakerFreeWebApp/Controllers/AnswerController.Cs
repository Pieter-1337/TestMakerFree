using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestMakerFreeWebApp.ViewModels;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestMakerFreeWebApp.Controllers
{
    public class AnswerController : Controller
    {
        [Route("api/answer/All")]
        //Get api/answer/all
        [HttpGet("All/{questionId}")]
        public IActionResult All(int QuestionId)
        {
            var sampleAnswers = new List<AnswerViewModel>();

            //add a first answer
            sampleAnswers.Add(new AnswerViewModel()
            {
                Id = 1,
                QuetionId = QuestionId,
                Text = "Friends and family",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            });

            //Add a bunch of other answers
            for(var i = 2; i <= 5; i++)
            {
                sampleAnswers.Add(new AnswerViewModel()
                {
                    Id = i,
                    QuetionId = QuestionId,
                    Text = String.Format($"Sample answer {i}"),
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }

            //Output the result in a Json Format
            return new JsonResult(sampleAnswers,
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }

    }
}
