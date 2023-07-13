using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventManagement.Context;
using EventManagement.Shared;
using EventManagement.Models;
namespace EventManagement.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        LoginContext entity = new LoginContext();
        public HomeController()
        {
        }
        public HomeController(LoginContext _entity)
        {
            entity = _entity;
        }
        
        [AllowAnonymous]
        public ActionResult Index()
        {
            var events = entity.Events.ToList();

            if (HttpContext.Session["Email"] != null)
            {
                if (HttpContext.Session["Email"].ToString() == "myadmin@bookevents.com")
                {
                    return View(events);
                }
            }

            List<EventModel> eventList = new List<EventModel>();
            foreach(var item in events)
            {
                if(item.Type==EventType.PUBLIC)
                {
                    eventList.Add(item);

                }
            }
            return View(eventList);
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var obj = entity.Events.Where(e => e.EventID.Equals(id)).FirstOrDefault();
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(obj);
        }
        public ActionResult Edit(int id)
        {
            var events = entity.Events.Where(e => e.EventID == id).FirstOrDefault();

            return View(events);
        }

        [HttpPost]
        public ActionResult Edit(EventModel e)
        {
            var ev = entity.Events.Where(u => u.EventID.Equals(e.EventID)).FirstOrDefault();
            if (ev == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                entity.Events.Remove(ev);
                entity.Events.Add(e);
                entity.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(ev);
        }

        public ActionResult GoToUrl()
        {
            var authorizationRequest = "http://helpdesk.nagarro.com";
            // assuming that you are in the controller.                    
            return Redirect(authorizationRequest);
        }

    }
}