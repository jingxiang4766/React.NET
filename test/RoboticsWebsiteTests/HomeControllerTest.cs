using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ReactDemoNC.Controllers;
using ReactDemoNC.Models;
using System.Collections.Generic;

namespace RoboticsWebsiteTests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void HomeControllerTest__Index()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void HomeControllerTest_Comments()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ActionResult result = controller.Comments();
            // Assert
            Assert.IsInstanceOfType(result, typeof(JsonResult));
            JsonResult routeResult = result as JsonResult;
            Assert.AreEqual(JsonConvert.SerializeObject(routeResult.Value), "[{\"Id\":1,\"Author\":\"Daniel Lo Nigro\",\"Comment\":\"Hello ReactJS.NET World!\"}]");
        }

        [TestMethod]
        public void HomeControllerTest__AddComments()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            CommentModel comment = new CommentModel();
            ActionResult result = controller.AddComment(comment);
            // Assert
            Assert.IsInstanceOfType(result, typeof(ContentResult));
            ContentResult routeResult = result as ContentResult;
            Assert.AreEqual(routeResult.Content, "Success :)");
        }
    }
}
