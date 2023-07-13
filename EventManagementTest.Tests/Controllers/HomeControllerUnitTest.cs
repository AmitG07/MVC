using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EventManagement.Controllers;
using System.Web.Mvc;
using EventManagement.Context;
using EventManagement.Models;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;

namespace EventManagementTest.Tests.Controllers
{
    [TestClass]
    public class HomeControllerUnitTest
    {
        EventModel e1;
        EventModel e2;
        HomeController home ;
        EventController eventctrl;
        AccountsController uctrl;
        Mock<LoginContext> entity;
       DbSet<EventModel> eventList;
        List<UserModel> userList;
        UserModel u1;
        List<EventModel> declaredProducts = new List<EventModel>();
        Mock<DbSet<EventModel>> mockEventSet ;
        public HomeControllerUnitTest()
        {
            u1 = new UserModel { Email = "Parth@gmail.com", password = "kbjacskjbakjsc", FullName = "PArth", Id = 4 };
            e1 = new EventModel {
                EventID = 1,
                User = u1,
                UserId ="1",Title="parth",Date= new DateTime(2023,5,17),Location="SHikohabad",StartTime= new DateTime(2023, 5, 17,6,6,6)
      ,Type=EventManagement.Shared.EventType.PUBLIC,Duration=2,Description="",OtherDetails="",InviteByEmail="abc@gmail.com"
      ,Count=1,CommentAdded="fdfchgcchg" };
            e2 = new EventModel
            {   EventID=2,
                User=u1,
                UserId = "1",
                Title = "parthgfdfg",
                Date = new DateTime(2023, 6, 17),
                Location = "Noida",
                StartTime = new DateTime(2023, 5, 17, 8, 6, 6)
     ,
                Type = EventManagement.Shared.EventType.PUBLIC,
                Duration = 3,
                Description = "",
                OtherDetails = "",
                InviteByEmail = "abc@gmail.com"
     ,
                Count = 1,
                CommentAdded = "jhvhj"
            };

            mockEventSet = new Mock<DbSet<EventModel>>();
            entity = new Mock<LoginContext>();
           
            entity.Setup(u => u.Users.Add(u1)).Callback((UserModel item) =>
            {
                userList.Add(u1);
            });
            
            uctrl = new AccountsController(entity.Object);
            
        }

        /*public void TestMethod1()
        {
           
            ViewResult result = home.Index() as ViewResult;
            
            var model = result.Model as List<EventModel>;
            Assert.IsNotNull(result);
            CollectionAssert.Contains(dummy, e1);
            CollectionAssert.Contains(model, e2);
        }*/
        [TestMethod]
        public void TestMethod2()
        {
            mockEventSet.Setup(u => u.Add(e1)).Callback((EventModel item) =>
            {
                eventList.Add(e1);
            });

            entity.Setup(u=>u.Events).Returns(() => mockEventSet.Object);
            var dummy = entity.Object.Events.FirstOrDefaultAsync();
            eventctrl.Create(e1);
            Assert.IsTrue(eventList.Find(e1)!=null?true:false);
        }
    }
}
