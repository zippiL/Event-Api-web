//using Microsoft.AspNetCore.Mvc;
//using WebApi.Controllers;

//namespace webApiTest
//{
//    public class contollersUnitTest
//    {
//        private readonly EventController _eventController;
//        public contollersUnitTest()
//        {
//            var contextFake = new DataContextFake();
//            _eventController = new EventController(contextFake);
//        }
//        [Fact]
//        public void GetById_ReturnsOk()
//        {
//            //AAA

//            //Arrange
//            var id = 1;
//            //Act
//            var result = _eventController.Get(id);
//            //Assert
//            Assert.IsType<OkObjectResult>(result);
//        }

//        [Fact]
//        public void GetById_ReturnsNotFound()
//        {
//            //AAA

//            //Arrange
//            var id = 2;
//            //Act

//            var result = _eventController.Get(id);
//            //Assert
//            Assert.IsType<NotFoundResult>(result);
//        }
//    }
//}