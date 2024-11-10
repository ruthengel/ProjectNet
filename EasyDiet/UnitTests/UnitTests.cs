using EasyDiet;
using EasyDiet.Controllers;
using EasyDietCore.Classes;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests
{
    public class UnitTests
    {
        
        
        private readonly CoachController controller;
        public UnitTests()
        {
            controller= new CoachController(new DataFake());
        }

        [Fact]
     
        public void GetById_ReturnsOk()
        {            
            var id = 1;
            var result =controller.Get(id);
            Assert.IsType<OkResult>(result);
        }

        [Fact]

        public void Get_ReturnsIsList()
        {
            var result = controller.Get();
            Assert.IsType<List<Coach>>(result);
        }
        [Fact]
        public void Put_ReturnsOk()
        {
            var result = controller.Put(2,"ruth","bb","0534150116",true);
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void Delete_ReturnsOk()
        {
            var id = 0;
            var result = controller.Delete(id);
            Assert.IsType<NotFoundResult>(result);
        }



    }
}