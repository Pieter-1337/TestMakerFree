using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestMakerFreeWebApp.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestMakerFreeWebApp.Controllers
{
    [Route("api/[controller]")]
    public class QuestionController : Controller
    {
        //Get api/question/all
        [HttpGet("All/{quizId}")]
        public IActionResult All(int QuizId)
        {
            var sampleQuestions = new List<QuestionViewModel>();

            //add a first sample question
            sampleQuestions.Add(new QuestionViewModel()
            {
                Id = 1,
                QuizId = QuizId,
                Text = "What do you value most in life?",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            });

            //Create a bunch of other questions
            for(var i = 2; i <= 5; i++)
            {
                sampleQuestions.Add(new QuestionViewModel()
                {
                    Id = i,
                    QuizId = QuizId,
                    Text = String.Format($"Sample Question {i}"),
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }

            return new JsonResult( sampleQuestions, 
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
            
        }
    }
}
