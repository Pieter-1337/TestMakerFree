﻿using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestMakerFreeWebApp.ViewModels;
using System.Collections.Generic;
using System.Linq;


namespace TestMakerFreeWebApp.Controllers
{
    [Route("api/[controller]")]
    public class QuizController : Controller
    {
        #region RESTful Convention methods
        /// <summary>
        /// GET: api/quiz/{}id
        /// Retrieves the Quiz with the given {id}
        /// </summary>
        /// <param name="id">The ID of an existing Quiz</param>
        /// <returns>the Quiz with the given {id}</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //Create a sample Quiz to match the given request
            var v = new QuizViewModel()
            {
                Id = id,
                Title = String.Format($"Sample quiz with id {id}"),
                Description = "Not a real quiz: it's just a sample",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            };

            //Output the result in a Json Format
            return new JsonResult(v, 
                new JsonSerializerSettings
                    {
                        Formatting = Formatting.Indented
                    });
        }
        #endregion


        #region Attribute-based Routing methods
        /// <summary>
        /// GET: api/quiz/latest
        /// Retrieves the {num} latest Quizzes
        /// </summary>
        /// <param name="num">the number of quizzes to retrieve</param>
        /// <returns>the {num} latest Quizzes</returns>
        [HttpGet("Latest/{num}")]
        public IActionResult Latest(int num = 10)
        {
            var sampleQuizzes = new List<QuizViewModel>();
            // add a first sample quiz
            sampleQuizzes.Add(new QuizViewModel()
            {
                Id = 1,
                Title = "Which Shingeki No Kyojin character are you?",
                Description = "Anime-related personality test",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            });
            // add a bunch of other sample quizzes
            for (int i = 2; i <= num; i++)
            {
                sampleQuizzes.Add(new QuizViewModel()
                {
                    Id = i,
                    Title = String.Format("Sample Quiz {0}", i),
                    Description = "This is a sample quiz",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }

             // output the result in JSON format
                return new JsonResult(sampleQuizzes, new JsonSerializerSettings()
                {   
                    Formatting = Formatting.Indented
                });
        }
        #endregion

        /// <summary>
        /// GET: api/quiz/ByTitle
        /// Retrieves the {num} Quizzes sorted by Title (A to Z)
        /// </summary>
        /// <param name="num">the number of quizzes to retrieve</param>
        /// <returns>{num} Quizzes sorted by Title</returns>
        [HttpGet("ByTitle/{num:int?}")]
        public IActionResult ByTitle(int num = 10)
        {
            var sampleQuizzes = ((JsonResult)Latest(num)).Value as List<QuizViewModel>;

            return new JsonResult(sampleQuizzes.OrderBy(q => q.Title),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }

        /// <summary>
        /// GET: api/quiz/mostViewed
        /// Retrieves the {num} random Quizzes
        /// </summary>
        /// <param name="num">the number of quizzes to retrieve</param>
        /// <returns>{num} random Quizzes</returns>
        [HttpGet("Random/{num:int?}")]
        public IActionResult Random(int num = 10)
        {

            var sampleQuizzes = ((JsonResult)Latest(num)).Value as List<QuizViewModel>;

            return new JsonResult(sampleQuizzes.OrderBy(q => Guid.NewGuid()),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }
    }
}