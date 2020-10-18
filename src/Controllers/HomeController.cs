using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using ReactDemoNC.Models;

namespace ReactDemoNC.Controllers
{
   
    public class HomeController : Controller
    {
        static readonly IList<CommentModel> _comments;

        static HomeController()
        {
            _comments = new List<CommentModel>
            {
                new CommentModel
                {
                    Id = 1,
                    Author = "Daniel Lo Nigro",
                    Comment = "Hello ReactJS.NET World!"
                },
            };
        }
        public IActionResult Index()
        {
            return View(_comments);
        }

        [Route("comments")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Comments()
        {
            return Json(_comments);
        }

        [Route("comments/new")]
        [HttpPost]
        public ActionResult AddComment(CommentModel myComment)
        {
            // Create a fake ID for this comment
            myComment.Id = _comments.Count + 1;
            _comments.Add(myComment);
            return Content("Success :)");
        }

    }
}